using Microsoft.EntityFrameworkCore;
using SharedModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BETOnlineShopAPI.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _db;
        public OrderRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task AddOrder(Order order)
        {
            _db.Orders.Add(order);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteOrder(int Id)
        {
            Order order = await _db.Orders.Include(o => o.orderDetails).FirstOrDefaultAsync(x => x.Id == Id);
            _db.Orders.Remove(order);
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _db.Orders.ToListAsync();
        }

        public async Task<Order> GetOrderId(int Id)
        {
            return await _db.Orders.FirstOrDefaultAsync(o=>o.Id==Id);
        }

        public async Task<Order> UpDateOrder(Order order)
        {
            Order orderToUpdate = await _db.Orders.FirstOrDefaultAsync(o => o.Id == order.Id);
            if (orderToUpdate != null)
            {
                orderToUpdate.Name = order.Name;
                orderToUpdate.MobileNumber = order.MobileNumber;
                orderToUpdate.Address = order.Address;
                orderToUpdate.IsProcessed = order.IsProcessed;
                _db.Orders.Update(orderToUpdate);
                await _db.SaveChangesAsync();
            }
            return orderToUpdate;
        }
        public string GetOrderNumber()
        {
            int count = _db.Orders.ToList().Count() + 1;
            return count.ToString("000");
        }
    }
}
