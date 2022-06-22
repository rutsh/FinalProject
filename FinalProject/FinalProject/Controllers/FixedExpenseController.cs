using BL;
using DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FixedExpenseController : ControllerBase
    {
        private readonly IFixedExpenseBL _FixedExpenseBL;

        public FixedExpenseController(IFixedExpenseBL FixedExpenseBL)
        {
            _FixedExpenseBL = FixedExpenseBL;
        }

       
        [HttpGet]
        [Route("GetByUserId/{id}")]
        public async Task<ActionResult<List<FixedExpenseDTO>>> GetByUserId(int id)
        {
            List<FixedExpenseDTO> list =await _FixedExpenseBL.GetByUserId(id);
            if (list == null)
                return Unauthorized();
            return Ok(list);
        }

      
        [HttpGet]
        [Route("GetByCategory/{categoryid}/{userId}")]
        public async Task<ActionResult<List<FixedExpenseDTO>>> GetByCategory(int categoryId,int userId)
        {
            return await _FixedExpenseBL.GetByCategory(categoryId, userId);
        }

      
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FixedExpenseDTO value)
        {
           await _FixedExpenseBL.AddFixedExpense(value);
            return Ok();
        }

      
    }
}
