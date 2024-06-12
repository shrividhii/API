using Common.DBEntityClass;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Classes
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ElectronicsStoreContextNew _context;

        public BrandRepository(ElectronicsStoreContextNew context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Brand>> GetAllBrands()
        {
            return await _context.Brands.ToListAsync();
        }

        public async Task<Brand> GetBrandById(int id)
        {
            return await _context.Brands.FindAsync(id);
        }

        public async Task AddBrand(Brand brand)
        {
            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBrand(Brand brand)
        {
            _context.Entry(brand).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public void  DeleteBrand(int id)
        {
            var brand =  _context.Brands.Find(id);
            _context.Brands.Remove(brand);
            _context.SaveChanges();
           // return "Brand deletion successful";
        }


        public async Task<bool> BrandExists(int id)
        {
            return await _context.Brands.AnyAsync(b => b.BrandId == id);
        }
        public async Task<bool> BrandNameExists(string brandName)
        {
            return await _context.Brands.AnyAsync(b => b.BrandName == brandName);
        }
    }
}
