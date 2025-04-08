using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using WebApiTaskTracker.Domain.DTO;
using WebApiTaskTracker.Domain.Interfaces.Services;

namespace WebApiTaskTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardController(IBoardServices boardServices, IValidatorService validatorService) : ControllerBase
    {
        [HttpPost("/addBoard")]
        public async Task<IActionResult> AddBoard([FromBody] AddBoardRequest addBoardRequest)
        {
            try
            {
                // Валидация йоу
                var validationResult = validatorService.ValidationEntity(addBoardRequest);
                if (validationResult.Any())
                {
                    return BadRequest(validationResult);
                }
                
                var result = await boardServices.AddBoard(addBoardRequest.Name, addBoardRequest.Description, addBoardRequest.IdOwner);
                if (result != null)
                {
                    return Ok(result);
                }
                return BadRequest("Не удалось создать доску");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("/addUserInBoard")]
        public async Task<IActionResult> AddUserInBoard([FromBody] AddUserInBoardRequest addUserInBoardRequest)
        {
            try
            {
                await boardServices.AddUserInBoard(addUserInBoardRequest.IdUser, addUserInBoardRequest.IdBoard, addUserInBoardRequest.Role);
                return Ok("Пользователь успешно добавлен в доску");
            }
            catch (Exception ex) when (ex.InnerException is DbUpdateException)
            {
                if(ex.InnerException.InnerException is PostgresException)
                {
                    return BadRequest("Пользователь уже добавлен в доску");
                }

                return BadRequest(ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
