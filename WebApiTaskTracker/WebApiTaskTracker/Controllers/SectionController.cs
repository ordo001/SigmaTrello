using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiTaskTracker.Application.Exceptions;
using WebApiTaskTracker.Domain.DTO;
using WebApiTaskTracker.Domain.Interfaces.Services;
using WebApiTaskTracker.Domain.Models;

namespace WebApiTaskTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController(ISectionServices sectionService, IValidatorService validatorService) : ControllerBase
    {
        [HttpPatch("/sections/{idSection}")]
        public async Task<IActionResult> UpdatePositionSection(
            [FromBody] UpdatePositionSectionRequest updateSectionRequest)
        {//TODO: СДЕЛАТЬ ПРАВИЛЬНО БЛЯ, ЧТОБЫ МОЖНО БЫЛО ИЗМЕНИТЬ ПОЗИЦИЮ ВСЕХ СЕКЦИЙ НА ДОСКЕ
            try
            {
                throw new Exception();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        [HttpGet("/boards/{idBoard}/sections")]
        public async Task<IActionResult> GetSectionBoard(Guid idBoard)
        {
            try
            {
                var result = await sectionService.GetSectionBoard(idBoard);
                return Ok(result);
            }
            catch (Exception ex) when(ex.GetType().IsGenericType &&
                                      ex.GetType().GetGenericTypeDefinition() == typeof(EntityNotFoundException<>))
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("/boards/{idBoard}/sections")]
        public async Task<IActionResult> AddSection([FromBody] AddSectionRequest addSectionRequest, Guid idBoard)
        {
            try
            {
                var result = validatorService.ValidationEntity(addSectionRequest);
                if (result.Any())
                {
                    return BadRequest(result);
                }


                var section = await sectionService.AddSectionAsync(addSectionRequest.Name,
                    addSectionRequest.Description,
                    addSectionRequest.Position,
                    idBoard);
                return Ok(section);

            }
            catch (Exception ex) when (ex.GetType().IsGenericType &&
                                       ex.GetType().GetGenericTypeDefinition() == typeof(EntityNotFoundException<>))
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        
    }
}
