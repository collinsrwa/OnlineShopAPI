using Microsoft.EntityFrameworkCore;
using SharedModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BETOnlineShopAPI.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Product> AddProduct(Product product)
        {
            if (product.productType != null) 
            {
                _db.Entry(product.productType).State = EntityState.Unchanged;
            }
            var result = await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteProduct(int Id)
        {
            var result = await _db.Products.FirstOrDefaultAsync(x => x.Id == Id);
            if (result != null)
            {
                _db.Products.Remove(result);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _db.Products.Include(x=>x.productType).ToListAsync();
        }

        public async Task<Product> GetProductById(int Id)
        {
            return await _db.Products.Include(c => c.productType).FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<Product> UpDateProduct(Product product)
        {
            Product prod = new Product();
            prod = await GetProductById(product.Id);
            if (prod != null)
            {
                prod.Image = product.Image;
                prod.Name = product.Name;
                prod.Price = product.Price;
                prod.ProductColor = product.ProductColor;
                prod.IsAvailable = product.IsAvailable;
                prod.ProductTypeId = product.ProductTypeId;
                prod.Quantity = product.Quantity;
                _db.Products.Update(prod);
                await _db.SaveChangesAsync();
            }
            return prod;
        }
    }
}
