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
    public class CategoryRepository : ICategoryRepository
    {

        private readonly ElectronicsStoreContextNew _context;

        public CategoryRepository(ElectronicsStoreContextNew context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task AddCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategory(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        //public async Task DeleteCategory(int id)
        //{
        //    var category = await _context.Categories.FindAsync(id);
        //    if (category != null)
        //    {
        //        _context.Categories.Remove(category);
        //        await _context.SaveChangesAsync();
        //    }
        //}
        public void DeleteCategory(int id)
        {
            var category =  _context.Categories.Find(id);
            _context.Categories.Remove(category);
             _context.SaveChangesAsync();
           // return "Category deletion successful";
        }



        public async Task<bool> CategoryExists(int id)
        {
            return await _context.Categories.AnyAsync(e => e.CategoryId == id);
        }

        public async Task<bool> CategoryNameExists(string brandName)
        {
            return await _context.Brands.AnyAsync(b => b.BrandName == brandName);
        }
    }
}
