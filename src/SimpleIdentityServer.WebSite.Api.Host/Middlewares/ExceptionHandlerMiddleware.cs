﻿#region copyright
// Copyright 2015 Habart Thierry
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#endregion

using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using SimpleIdentityServer.WebSite.Api.Core.Exceptions;
using SimpleIdentityServer.WebSite.Api.Host.DTOs.Responses;
using SimpleIdentityServer.WebSite.Api.Host.Extensions;
using System;
using System.Net;
using System.Threading.Tasks;

namespace SimpleIdentityServer.WebSite.Api.Host.Middlewares
{
    internal class ExceptionHandlerMiddleware
    {
        private const string UnhandledExceptionCode = "unhandled_error";

        private readonly RequestDelegate _next;

        #region Constructor

        public ExceptionHandlerMiddleware(
            RequestDelegate next)
        {
            if (next == null)
            {
                throw new ArgumentNullException(nameof(next));
            }

            _next = next;
        }

        #endregion

        #region Public methods

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                var identityServerException = exception as IdentityServerException;
                if (identityServerException == null)
                {
                    identityServerException = new IdentityServerException(UnhandledExceptionCode, exception.Message);
                }

                var code = identityServerException.Code;
                var message = identityServerException.Message;
                context.Response.Clear();
                var error = new ErrorResponse();
                PopulateError(error, identityServerException);
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.ContentType = "application/json";
                var serializedError = error.SerializeWithDataContract();
                await context.Response.WriteAsync(serializedError);
            }
        }

        #endregion

        #region Private static methods

        private static void PopulateError(ErrorResponse errorResponse, IdentityServerException exception)
        {
            errorResponse.Error = exception.Code;
            errorResponse.ErrorDescription = exception.Message;
        }

        #endregion
    }
}
