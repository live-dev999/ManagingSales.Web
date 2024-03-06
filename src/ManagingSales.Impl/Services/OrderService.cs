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
using ManagingSales.Data;
using ManagingSales.Impl.Mappings;
using Microsoft.EntityFrameworkCore;

namespace ManagingSales.Impl.Services
{
    //TODO: maybe you need to reconsider using IQueryable
    public class OrderService: IOrderService
	{
        #region Fields

        private readonly MSDbContext _context;

        #endregion


        #region Ctors

        public OrderService(MSDbContext context)
        {
            _context = context;
        }

        #endregion


        #region Methods

        public async Task<IReadOnlyCollection<Order>> GetAllAsync(CancellationToken ct)
        {
            var Orders = await _context.Orders.AsNoTracking().OrderBy(_ => _.Id).ToListAsync();
            return Orders.ToService();
        }

        public async Task<Order> GetByIdAsync(long id, CancellationToken ct)
        {
            var Orders = await _context.Orders.AsNoTracking().SingleAsync(x => x.Id == id, ct);
            return Orders.ToService();
        }

        public async Task<Order> UpdateAsync(Order order, CancellationToken ct)
        {
            var updatedorderEntity = _context.Orders.Update(order.ToEntity());
            await _context.SaveChangesAsync(ct);
            return updatedorderEntity.Entity.ToService();
        }

        public async Task<Order> AddAsync(Order order, CancellationToken ct)
        {
            var addedorderEntity = await _context.Orders.AddAsync(order.ToEntity(), ct);
            await _context.SaveChangesAsync(ct);
            return addedorderEntity.Entity.ToService();
        }

        public async Task RemoveAsync(long id, CancellationToken ct)
        {
            var entityToRemove = await _context.Orders.SingleOrDefaultAsync(_ => _.Id == id, ct);
            _context.Orders.Remove(entityToRemove);
            await _context.SaveChangesAsync(ct);
        }

        #endregion
    }
}

