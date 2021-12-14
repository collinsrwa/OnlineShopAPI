using SharedModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BETOnlineShopAPI.Models
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllOrders();
        Task<Order> GetOrderId(int Id);
        Task AddOrder(Order order);
        Task<Order> UpDateOrder(Order order);
        Task DeleteOrder(int Id);
        string GetOrderNumber();
    }
}
