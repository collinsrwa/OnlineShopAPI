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
            //if (order.orderDetails != null)
            //{
            //    _db.Entry(order.orderDetails).State = EntityState.Unchanged;
            //}
            _db.Orders.Add(order);
            await _db.SaveChangesAsync();
        }

        public Task DeleteOrder(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderId(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Order> UpDateOrder(Order order)
        {
            throw new NotImplementedException();
        }
        public string GetOrderNumber()
        {
            int count = _db.Orders.ToList().Count() + 1;
            return count.ToString("000");
        }
    }
}
