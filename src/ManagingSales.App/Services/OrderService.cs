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
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ManagingSales.API.Services;
using ManagingSales.App.Config;
using ManagingSales.App.DTOs;
using Microsoft.Extensions.Logging;

namespace ManagingSales.App.Services
{
    public class OrderService : IOrderService
    {
        #region Fields

        private readonly ILogger<OrderService> logger;
        private readonly UrlsConfig config;
        private HttpClient httpClient;

        #endregion

        #region Ctors

        public OrderService(HttpClient httpClient, ILogger<OrderService> logger, UrlsConfig config)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            this.config = config ?? throw new ArgumentNullException(nameof(config));
        }

        #endregion


        #region Methods

        public async Task<List<OrderDto>> GetAllAsync(CancellationToken ct)
        {
            var response = await httpClient.GetAsync($"api/order", ct);
            return await response.Content.ReadAsAsync<List<OrderDto>>(ct);
        }

        public async Task<OrderDto> GetAsync(long id, CancellationToken ct)
        {
            var response = await httpClient.GetAsync($"api/order/{id}", ct);
            return await response.Content.ReadAsAsync<OrderDto>(ct);
        }

        #endregion
    }
}

