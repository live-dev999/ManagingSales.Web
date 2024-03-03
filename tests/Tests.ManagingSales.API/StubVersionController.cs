/*
 *   Copyright (c) 2024 Dzianis Prokharchyk

 *   This program is free software: you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation, either version 3 of the License, or
 *   (at your option) any later version.

 *   This program is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *   GNU General Public License for more details.

 *   You should have received a copy of the GNU General Public License
 *   along with this program.  If not, see <https://www.gnu.org/licenses/>.
 */

using ManagingSales.API.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace Tests.ManagingSales.API
{
    public class StubVersionController : VersionController
    {
        public string VersionString { get; init; }

#pragma warning disable CS8618
        public StubVersionController(IWebHostEnvironment environment,
#pragma warning restore CS8618
            // ReSharper disable once ContextualLoggerProblem
            ILogger<VersionController> logger)
            : base(environment, logger)
        {
        }

        protected override Version GetVersion() => Version.Parse(VersionString);
    }
}