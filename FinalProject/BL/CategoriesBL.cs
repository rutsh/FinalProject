using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DAL;
using DAL.Models;
using DTO;
namespace BL
{
    public class CategoriesBL : ICategoriesBL
    {
        private readonly ICategoriesDAL categoriesDAL;
        IMapper mapper;

        public CategoriesBL(ICategoriesDAL _categoriesDAL)
        {
            categoriesDAL = _categoriesDAL;
            // config זה מופע של המחלקה AutoMapperProfile שנמצא ב-DTO 
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();

            });
            mapper = config.CreateMapper();
        }
        //get
        public async Task<List<CategoriesDTO>> GetCategories()
        {
            List<Categories> c =await categoriesDAL.GetCategories();
            return mapper.Map<List<Categories>, List<CategoriesDTO>>(c);
        }

        //post
        public async Task AddCategory(CategoriesDTO c)
        {
            // Categories cat = ConvertToCategory(c);
          await categoriesDAL.AddCategory(mapper.Map<CategoriesDTO, Categories>(c));
        }
    }
}
