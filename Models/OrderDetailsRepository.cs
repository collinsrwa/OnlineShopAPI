using Microsoft.EntityFrameworkCore;
using SharedModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BETOnlineShopAPI.Models
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        private readonly ApplicationDbContext _db;
        public OrderDetailsRepository(ApplicationDbContext db)
        {
            _db = db;  
        }
        public Task<OrderDetails> AddOrderDetails(OrderDetails orderDetails)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteOrderDetails(int Id)
        {
            OrderDetails orderDetail= await _db.OrderDetails.Include(p => p.Product).Include(o => o.Order).FirstOrDefaultAsync(r => r.Id == Id);
            if (orderDetail != null)
            {
               _db.OrderDetails.Remove(orderDetail);
            }
        }

        public async Task<IEnumerable<OrderDetails>> GetAllOrderDetails()
        {
            return await _db.OrderDetails.Include(p => p.Product).Include(o => o.Order).ToListAsync();
        }

        public async Task<IEnumerable<OrderDetails>> GetOrderDetailsByOrderId(int Id)
        {
            return await _db.OrderDetails.Include(p => p.Product).Include(o => o.Order).Where(r=>r.OrderId==Id).ToListAsync();
        }

        public Task<OrderDetails> UpDateOrderDetails(Order orderDetails)
        {
            throw new NotImplementedException();
        }
    }
}
