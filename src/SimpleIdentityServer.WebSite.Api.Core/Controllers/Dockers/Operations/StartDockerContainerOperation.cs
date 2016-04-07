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

using Docker.DotNet;
using SimpleIdentityServer.WebSite.Api.Core.Validators;
using System;

namespace SimpleIdentityServer.WebSite.Api.Core.Controllers.Dockers.Operations
{
    public interface IStartDockerContainerOperation
    {

    }

    internal sealed class StartDockerContainerOperation : IStartDockerContainerOperation
    {
        private readonly IContainerValidator _containerValidator;

        #region Constructor

        public StartDockerContainerOperation(IContainerValidator containerValidator)
        {
            _containerValidator = containerValidator;
        }

        #endregion

        #region Public methods

        public void Execute(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            _containerValidator.CheckContainerExist(name);

            var dockerClient = new DockerClientConfiguration(new Uri("http://ubuntu-docker.cloudapp.net:4243"))
                .CreateClient();
            
        }

        #endregion
    }
}
