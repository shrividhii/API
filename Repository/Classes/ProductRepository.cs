using Common.DBEntityClass;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Classes
{
    public class ProductRepository : IProductRepository
    {

        private readonly ElectronicsStoreContextNew _context;

        public ProductRepository(ElectronicsStoreContextNew context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task Add(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var product =  _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChangesAsync();
           // return "Product deletion successful";
        }
        public async Task<bool> ProductNameExists(string productName)
        {
            return await _context.Products.AnyAsync(p => p.ProductName == productName);
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
