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

namespace SimpleIdentityServer.WebSite.Api.Core.Errors
{
    public static class ErrorDescriptions
    {
        public const string TheProfileDoesntExist = "the profile {0} doesn't exist";

        public const string TheProfileIsNotActive = "the profile {0} is not active";

        public const string TheProfileAlreadyExists = "the profile already exists";

        public const string TheContainerDoesntExist = "the container {0} doesn't exist";

        public const string TheCertificateIsMissing = "the certificate is missing";

        public const string TheUserCredentialsAreMissing = "the user credentials are missing";

        public const string TheDockerApiUriIsMissing = "the docker API URI is missing";
    }
}
