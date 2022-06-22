using DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface ICategoriesBL
    {
        Task AddCategory(CategoriesDTO c);
        Task<List<CategoriesDTO>> GetCategories();
    }
}