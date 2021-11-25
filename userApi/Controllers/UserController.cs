using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userApi.Interfaces;

namespace userApi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UserController : Controller
    {
        IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateUser([FromBody] User newUser)
        {
            try
            {
                await _userServices.AddUser(newUser);
                return new CreatedResult(newUser.Id, newUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> GetAllUsers()
        {
            var Users = await _userServices.Getusers();
            if (Users.Any())
            {
                return Ok(Users);
            }
            return NoContent();
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> GetUser([FromRoute] string id)
        {
            var User = await _userServices.Getuser(id);
            if (User == null)
            {
                return NoContent();
            }
            return Ok(User);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateUser([FromRoute] string id, [FromBody] User user)
        {
            try
            {
                var updatedUser = await _userServices.Update(id, user);
                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteUser([FromRoute] string id)
        {
            var User = await _userServices.Getuser(id);
            if (User == null)
            {
                return BadRequest("Usuario nao existe!");
            }

            await _userServices.DeleteUser(id);

            return Ok();
        }

    }
}
