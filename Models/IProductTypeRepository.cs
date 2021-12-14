using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharedModels.Models;

namespace BETOnlineShopAPI.Models
{
    public interface IProductTypeRepository
    {
        Task<IEnumerable<ProductType>> GetAllProductTypes();
        Task<ProductType> GetProductTypeById(int Id);
        Task<ProductType> AddProductType(ProductType productType);
        Task<ProductType> UpDateProductType(ProductType productType);
        Task DeleteProductType(int Id);

    }
}
