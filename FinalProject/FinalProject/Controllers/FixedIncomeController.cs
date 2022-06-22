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
    public class FixedIncomeController : ControllerBase
    {
        private readonly IFixedIncomeBL _FixedIncomeBL;
        public FixedIncomeController(IFixedIncomeBL FixedIncomeBL)
        {
            _FixedIncomeBL = FixedIncomeBL;
        }


       
        [HttpGet]
        [Route("GetByUserId/{id}")]
        public async Task<ActionResult<List<FixedIncomeDTO>>> GetByUserId(int id)
        {
            List<FixedIncomeDTO> list =await _FixedIncomeBL.GetByUserId(id);
            if (list == null)
                return Unauthorized();
            return Ok(list);
        }

        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FixedIncomeDTO value)
        {
           await _FixedIncomeBL.AddFixedIncome(value);
            return Ok();
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] FixedIncomeDTO value,int id)
        {
            await _FixedIncomeBL.putIncome(value,id);
            return Ok();
        }

    }
}
