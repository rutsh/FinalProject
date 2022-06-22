using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using BL;
using DTO;
namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

     private readonly ICategoriesBL categoriesBL;

        public CategoriesController(ICategoriesBL _categoriesBL)
        {
            categoriesBL = _categoriesBL;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<ActionResult<List<CategoriesDTO>>> Get()
        {
           List<CategoriesDTO> currentc=await categoriesBL.GetCategories();
            if (currentc == null)
                return NotFound();
            return Ok(currentc);

        }

        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoriesDTO c)
        {
          await categoriesBL.AddCategory(c);
            return Ok();
        }

        //// PUT api/<CategoriesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<CategoriesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
