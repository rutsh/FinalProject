using DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL
{
    public interface ICategoriesDAL
    {
        Task AddCategory(Categories c);
       Task< List<Categories>> GetCategories();
    }
}