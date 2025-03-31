using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiTaskTracker.Domain.DTO;
using WebApiTaskTracker.Domain.Interfaces.Services;

namespace WebApiTaskTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserServices _userServices;
        public UserController(IUserServices userServices)
        { 
            _userServices = userServices;
        }

        [HttpPost("/addUser")]
        public async Task<IActionResult> AddUser([FromBody] AddUserRequest userRequest)
        {
            try
            {
                var result = await _userServices.AddUserAsync(
                    userRequest.Login,
                    userRequest.Password,
                    userRequest.Username,
                    userRequest.Email
                    );
                if(result != null )
                {
                    return Ok(result);
                }
                return BadRequest();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
