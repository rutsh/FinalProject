using BL;
using DAL.Models;
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
    public class ExpenseController : ControllerBase
    {

        private readonly IExpenseBL expenseBL;

        public ExpenseController(IExpenseBL _expenseBL)
        {
            expenseBL = _expenseBL;
        }

        // GET: api/<Expense>
        [HttpGet]
        [Route("GetByUserId/{id}")]
        public async Task<ActionResult<List<ExpenseDTO>>> GetByUserId(int id)
        {
            List<ExpenseDTO> list =await expenseBL.GetByUserId(id);
            if (list == null)
               return Unauthorized();
            return Ok(list);
        }

        //// GET api/<Expense>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<Expense>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ExpenseDTO value)
        {
          await  expenseBL.AddExpense(value);
            return Ok();
        }

        //// PUT api/<Expense>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<Expense>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
