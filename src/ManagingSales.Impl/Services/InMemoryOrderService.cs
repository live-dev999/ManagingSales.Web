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
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ManagingSales.Business.Models;
using ManagingSales.Business.Services;

namespace ManagingSales.Impl.Services
{
    public class InMemoryOrderService: IOrderService
    {
        #region Fields

        private static readonly List<Order> Orders = new List<Order>()
        {
            new Order()
            {
                Id = 1, Name = "New York Building 1", State = StateArray.GetAbbreviation("New York")
            }
        };
        private long _currentId;

        #endregion


        #region Ctors

        public InMemoryOrderService()
        {
            _currentId = Orders.Count();
        }
        #endregion


        #region Methods

        public async Task<IReadOnlyCollection<Order>> GetAllAsync(CancellationToken ct)
        {
            await Task.Delay(3000, ct);
            return await Task.FromResult<IReadOnlyCollection<Order>>(Orders.AsReadOnly());
        }

        public async Task<Order> GetByIdAsync(long id, CancellationToken ct)
        {
            await Task.Delay(3000, ct);
            return await Task.FromResult(Orders.SingleOrDefault(g => g.Id == id));
        }

        public async Task<Order> UpdateAsync(Order Order, CancellationToken ct)
        {
            await Task.Delay(5000, ct);
            var toUpdate = Orders.SingleOrDefault(g => g.Id == Order.Id);
            if (toUpdate == null)
                return null;

            toUpdate.Name = Order.Name;

            return await Task.FromResult(toUpdate);
        }

        public async Task<Order> AddAsync(Order Order, CancellationToken ct)
        {
            await Task.Delay(3000, ct);
            Order.Id = ++_currentId;
            Orders.Add(Order);
            return await Task.FromResult(Order);
        }

        public Task RemoveAsync(long id, CancellationToken ct)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}

