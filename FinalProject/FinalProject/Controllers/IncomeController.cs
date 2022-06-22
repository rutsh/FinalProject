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
    public class IncomeController : ControllerBase
    {
        private readonly IIncomeBL incomeBL;

        public IncomeController(IIncomeBL _incomeBL)
        {
            incomeBL = _incomeBL;
        }
       
        [HttpGet]
        [Route("GetByUserId/{id}")]
        public async Task<ActionResult<List<IncomeDTO>>> GetByUserId(int id)
        {
            List<IncomeDTO> list = await incomeBL.GetByUserId(id);
            if (list == null)
                return Unauthorized();
            return Ok(list);
        }

       
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] IncomeDTO value)
        {
           await incomeBL.AddIncome(value);
            return Ok();
        }

      
    }
}
