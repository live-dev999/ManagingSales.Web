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
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ManagingSales.API.Core;
using ManagingSales.API.DTOs;
using ManagingSales.API.Mappings;
using ManagingSales.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ManagingSales.API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class OrderController: BaseApiController
    {

        #region Fields

        private readonly IOrderService orderService;
        private readonly ILogger logger;

        #endregion


        #region Ctors

        public OrderController(IOrderService orderService, ILogger<OrderController> logger)
		{
            this.orderService = orderService;
            this.logger = logger;
        }

        #endregion


        #region Methods

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllAsync()
        {
            return HandleResult(await Task.Run(async () =>
            {
                var models = await orderService.GetAllAsync(CancellationToken.None);

                return Result<IReadOnlyCollection<OrderDto>>.Success(models.ToViewModel());
            }));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id, CancellationToken ct)
        {
            return HandleResult(await Task.Run(async () =>
            {
                var certificate = await orderService.GetByIdAsync(id, ct);

                return Result<OrderDto>.Success(certificate.ToViewModel());
            }));
        }

        [HttpPut]
        [Route("id")]
        public async Task<IActionResult> UpdateAsync(long id, OrderDto model, CancellationToken ct)
        {
            return HandleResult(await Task.Run(async () =>
            {
                var certificate = await orderService.UpdateAsync(model.ToModel(), ct);

                return Result<OrderDto>.Success(certificate.ToViewModel());
            }));
        }

        [HttpPost]
        [HttpPut]
        [Route("")]
        public async Task<IActionResult> AddAsync(OrderDto model, CancellationToken ct)
        {
            return HandleResult(await Task.Run(async () =>
            {
                var certificate = await orderService.AddAsync(model.ToModel(), ct);

                return Result<CreatedAtActionResult>.Success(
                    CreatedAtAction(nameof(GetByIdAsync), new { id = certificate.Id }, certificate));
            }));
        }

        [HttpDelete]
        [Route("id")]
        public async Task<IActionResult> RemoveAsync(long id, CancellationToken ct)
        {
            return HandleResult(await Task.Run(async () =>
            {
                await orderService.RemoveAsync(id, ct);

                return Result<NoContentResult>.Success(NoContent());
            }));
        }

        #endregion

    }
}

