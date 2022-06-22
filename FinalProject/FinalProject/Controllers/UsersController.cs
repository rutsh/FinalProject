using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using System.IO;
using DTO;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;
using DAL.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        
        private readonly IUsersBL _userBL;
     
      //  private readonly ILogger _logger;
       

        public UsersController(IUsersBL userBL)
        {
            _userBL = userBL;
           // _logger = logger;
        }
        [HttpGet]
        [Route("GetUser/{password}/{email}")]
        public async Task<ActionResult<UsersDTO>> GetUser([FromRoute][Required] string password, [FromRoute][Required] string email)
        {
           // _logger.LogInformation("enter to login function" + password +" "+ email);
            if (password == null && email == null)
                return BadRequest("name and password is null");

            UsersDTO currentUser =await _userBL.GetUser(password, email);
            if (currentUser == null)
                return Unauthorized();
            return Ok(currentUser);
        }
     
        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<ActionResult<UsersDTO>> GetById(int id)
        {

            if (id== null)
                return BadRequest("name and password is null");

            UsersDTO currentUser =await _userBL.GetById(id);
       
            if (currentUser == null)
                return Unauthorized();
            return Ok(currentUser);
        }


        [HttpPost]

        public async Task<ActionResult<UsersDTO>> Post([FromBody] UsersDTO user)
        {
            try
            {
                UsersDTO u=await _userBL.AddUser(user);
                return Ok(u);
            }catch(Exception ex)
            {
                //סטטוס קוד של שיגאה שמירת הנתונים ב DB
                return StatusCode(501,ex);
            }
        }

        
        [HttpPut]
        [Route("updateUser/{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UsersDTO user)
        {
            try
            {
                return Ok(await _userBL.UpdateUser(user, id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpDelete]
        [Route("deleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                return Ok(await _userBL.DeleteUser(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
