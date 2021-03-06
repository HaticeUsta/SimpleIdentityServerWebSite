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

using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using SimpleIdentityServer.WebSite.Api.Core.Controllers.Dockers;
using System;
using System.Threading.Tasks;

namespace SimpleIdentityServer.WebSite.Api.Host.Controllers
{
    [Route(Constants.RouteValues.Container)]
    public class ContainersController : Controller
    {
        private readonly IDockerOperations _dockerOperations;
        
        #region Constructor

        public ContainersController(IDockerOperations dockerOperations)
        {
            _dockerOperations = dockerOperations;
        }

        #endregion

        #region Public methods

        [HttpGet(Constants.DockerActions.Start)]
        [Authorize]
        public async Task<bool> GetStart(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            await _dockerOperations.StartContainer(name);
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            return true;
        }
        
        [HttpGet(Constants.DockerActions.Stop)]
        [Authorize]
        public async Task<bool> GetStop(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            await _dockerOperations.StopContainer(name);
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            return true;
        }

        #endregion
    }
}
