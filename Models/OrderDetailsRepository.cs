using SharedModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BETOnlineShopAPI.Models
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        public Task<OrderDetails> AddOrderDetails(OrderDetails orderDetails)
        {
            throw new NotImplementedException();
        }

        public Task DeleteOrderDetails(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderDetails>> GetAllOrderDetails()
        {
            throw new NotImplementedException();
        }

        public Task<OrderDetails> GetOrderDetailsById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDetails> UpDateOrderDetails(Order orderDetails)
        {
            throw new NotImplementedException();
        }
    }
}
