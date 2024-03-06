using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ManagingSales.API.DTOs;
using ManagingSales.Business.Models;

namespace ManagingSales.API.Mappings
{
    public static class OrderMappings
	{
        public static OrderDto ToDto(this Order model)
        {
            if (model == null)
                return null;

            var viewModel = new OrderDto();

            //Bindings
            viewModel.Id = model.Id;
            viewModel.Name = model.Name;

            return viewModel;
        }

        public static Order ToModel(this OrderDto viewModel)
        {
            if (viewModel == null)
                return null;

            var model = new Order();

            //Bindings
            model.Id = viewModel.Id;
            model.Name = viewModel.Name;

            return model;
        }

        public static IReadOnlyCollection<OrderDto> ToDto(
            this IReadOnlyCollection<Order> models)
        {
            if (models.Count == 0)
            {
                return Array.Empty<OrderDto>();
            }

            var orders = new OrderDto[models.Count];
            var i = 0;
            foreach (var model in models)
            {
                orders[i] = ToDto(model);
                ++i;
            }

            return new ReadOnlyCollection<OrderDto>(orders);
        }
    }
}

