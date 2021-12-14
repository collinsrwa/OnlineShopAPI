using SharedModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BETOnlineShopAPI.Models
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(int Id);
        Task<Product> AddProduct(Product product);
        Task<Product> UpDateProduct(Product product);
        Task DeleteProduct(int Id);
    }
}
