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

using SimpleIdentityServer.WebSite.Api.Core.Models;
using SimpleIdentityServer.WebSite.Api.Core.Parameters;
using SimpleIdentityServer.WebSite.Api.Host.DTOs.Requests;
using SimpleIdentityServer.WebSite.Api.Host.DTOs.Responses;

namespace SimpleIdentityServer.WebSite.Api.Host.Extensions
{
    internal static class MappingExtensions
    {
        #region To Parameter

        public static AddProfileParameter ToParameter(this PostProfileRequest postProfileRequest)
        {
            return new AddProfileParameter
            {
                Name = postProfileRequest.Name
            };
        }

        #endregion

        #region ToResponse

        public static ProfileResponse ToResponse(this Profile profile)
        {
            return new ProfileResponse
            {
                AuthorizationServerUrl = profile.AuthorizationServerUrl,
                Name = profile.Name,
                IsActive = profile.IsActive,
                ManagerWebSiteApiUrl  = profile.ManagerWebSiteApiUrl,
                ManagerWebSiteUrl = profile.ManagerWebSiteUrl,
                Picture = profile.Picture,
                Subject = profile.Subject
            };
        }

        #endregion
    }
}
