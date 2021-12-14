using SharedModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BETOnlineShopAPI.Models
{
    public interface IOrderDetailsRepository
    {
        Task<IEnumerable<OrderDetails>> GetAllOrderDetails();
        Task<OrderDetails> GetOrderDetailsById(int Id);
        Task<OrderDetails> AddOrderDetails(OrderDetails orderDetails);
        Task<OrderDetails> UpDateOrderDetails(Order orderDetails);
        Task DeleteOrderDetails(int Id);
    }
}
