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
        private readonly IUserServices _userServices;
        private readonly IValidatorService _validatorService;
        public UserController(IUserServices userServices, IValidatorService validatorService)
        { 
            _userServices = userServices;
            _validatorService = validatorService;
        }

        [HttpPost("/addUser")]
        public async Task<IActionResult> AddUser([FromBody] AddUserRequest userRequest)
        {
            try
            {
                // Валидация йоу
                var validationResult = _validatorService.ValidationEntity(userRequest);
                if (validationResult.Any())
                {
                    return BadRequest(validationResult);
                }
                
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
