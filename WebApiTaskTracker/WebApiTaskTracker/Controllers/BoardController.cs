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
    public class BoardController(IBoardServices _boardServices) : ControllerBase
    {
        [HttpPost("/addBoard")]
        public async Task<IActionResult> AddBoard([FromBody] AddBoardRequest addBoardRequest)
        {
            try
            {
                var result = await _boardServices.AddBoard(addBoardRequest.Name, addBoardRequest.Description, addBoardRequest.IdOwner);
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
                await _boardServices.AddUserInBoard(addUserInBoardRequest.IdUser, addUserInBoardRequest.IdBoard, addUserInBoardRequest.Role);
                return Ok("Пользователь успешно добавлен в доску");
            }
            catch (Exception ex) when (ex.InnerException is DbUpdateException)
            {
                //TODO: Фиксануть блять

                //if (ex.InnerException is PostgresException)
                //{
                //   return BadRequest($"Пользователь уже добавлен в эту доску {ex.InnerException.Message}");
                //}
                if(ex.InnerException.InnerException is PostgresException)
                {
                    return BadRequest("Пользователь уже добавлен в доску");
                }

                return BadRequest(ex.InnerException.Message);
            }
        }
    }
}
