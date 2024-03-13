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

using FakeItEasy;
using FluentAssertions;
using ManagingSales.API.Controllers;
using ManagingSales.API.DTOs;
using ManagingSales.Business.Models;
using ManagingSales.Business.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ManagingSales.API.Mappings;

namespace Tests.ManagingSales.API.Controller
{
    public class OrderControllerTests
	{
        #region Fields

        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;

        #endregion


        #region Ctors

        public OrderControllerTests()
        {
            _logger = A.Fake<ILogger<OrderController>>();
            _orderService = A.Fake<IOrderService>();
        }

        #endregion


        #region Methods

        [Fact]
        public async void OrderController_GetAllOrders_ReturnOk()
        { 
            //Arrange
            var orders = A.Fake<ICollection<OrderDto>>();
            var orderList = A.Fake<IReadOnlyCollection<Order>>();

            //Act
            A.CallTo(() => _orderService.GetAllAsync(CancellationToken.None)).Returns(Task.FromResult(orderList));
            var controller = new OrderController(_orderService, _logger);
            var result = await controller.GetAllAsync();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public async void OrderController_CreateOrder_ReturnOk()
        {
            //Arrange
            var order = A.Fake<OrderDto>();

            //Act
            var controller = new OrderController(_orderService, _logger);
            var result = await controller.AddAsync(order, CancellationToken.None);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }


        [Fact]
        public async void OrderController_GetOrder_ReturnOk()
        {
            //Arrange
            var order = new Order() { Id = 1, Name = "name_test", State = "state_test" };

            //Act
            A.CallTo(() => _orderService.GetByIdAsync(order.Id, CancellationToken.None))
                .Returns(Task.FromResult(order));
            var controller = new OrderController(_orderService, _logger);
            var result = await controller.GetByIdAsync(order.Id, CancellationToken.None);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public async void OrderController_UpdateOrder_ReturnOk()
        {
            //Arrange
            var order = new Order() { Id = 1, Name = "name_test", State = "state_test" };
            //A.CallTo(() => order.Id).Returns<long>(1);

            //Act
            A.CallTo(() => _orderService.UpdateAsync(order, CancellationToken.None))
                .Returns(Task.FromResult(order));
            var controller = new OrderController(_orderService, _logger);
            var result = await controller.UpdateAsync(order.Id, order.ToDto(), CancellationToken.None);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        #endregion

    }
}

