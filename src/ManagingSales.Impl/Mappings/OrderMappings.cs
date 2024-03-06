using System.Collections.Generic;
using ManagingSales.Business.Models;
using ManagingSales.Data.Entites;

namespace ManagingSales.Impl.Mappings
{
    internal static class OrderMappings
    {
        public static Order ToService(this OrderEntity entity)
        {
            return entity != null ? new Order() { Id = entity.Id, Name = entity.Name } : null;
        }

        public static OrderEntity ToEntity(this Order model)
        {
            return model != null ? new OrderEntity() { Id = model.Id, Name = model.Name } : null;
        }

        public static IReadOnlyCollection<Order>
            ToService(this IReadOnlyCollection<OrderEntity> entities) =>
            entities.MapCollection(ToService);
    }
}

