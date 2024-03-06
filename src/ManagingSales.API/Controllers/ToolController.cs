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
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ManagingSales.API.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ManagingSales.API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class ToolController: BaseApiController
    {
        #region Fields

        private readonly ILogger<ToolController> logger;

        #endregion


        #region Ctors

        public ToolController(ILogger<ToolController> logger)
		{
            this.logger = logger;
        }

        #endregion


        #region Methods

        [HttpPost]
        [HttpPut]
        [Route("Import")]
        public async Task<IActionResult> ImportAsync(IReadOnlyCollection<OrderDto> model, CancellationToken ct)
        {
            throw new NotImplementedException();
        }


        [HttpGet]
        [Route("Export")]
        public async Task<IActionResult> ExportAsync(IReadOnlyCollection<OrderDto> model, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

