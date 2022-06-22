using System;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL
{
    public class CategoriesDAL : ICategoriesDAL
    {
       private readonly EconomyContext _context;
        public CategoriesDAL(EconomyContext context) 
        {
            _context = context;
        }

        public async Task<List<Categories>> GetCategories()
        {
            List<Categories> categories =await _context.Categories.ToListAsync();
            return categories;
        }

        public async Task AddCategory(Categories c)
        {
            //c.CategoryId = _context.Categories.Max(x => x.CategoryId) + 1;
           _context.Categories.Add(c);
          await  _context.SaveChangesAsync();
        }

    }
}
