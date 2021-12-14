using Microsoft.EntityFrameworkCore;
using SharedModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BETOnlineShopAPI.Models
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<ProductType> AddProductType(ProductType productType)
        {
            var result = await _db.ProductTypes.AddAsync(productType);
            await _db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteProductType(int Id)
        {
            var result = await _db.ProductTypes.FirstOrDefaultAsync(x=>x.Id==Id);
            if (result != null)
            {
                _db.ProductTypes.Remove(result);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ProductType>> GetAllProductTypes()
        {
            return await _db.ProductTypes.ToListAsync();
        }

        public async Task<ProductType> GetProductTypeById(int Id)
        {
            return await _db.ProductTypes.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<ProductType> UpDateProductType(ProductType productType)
        {
            ProductType pType = new ProductType();
            pType = await GetProductTypeById(productType.Id);
            if (pType != null)
            {
                pType.ProdType = productType.ProdType;
                 _db.ProductTypes.Update(pType);
                await _db.SaveChangesAsync();
            }
            return pType;
        }
    }
}
