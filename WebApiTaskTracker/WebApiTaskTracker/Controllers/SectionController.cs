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
        public async Task<IActionResult> UpdatePositionSection(Guid idSection,
            [FromBody] int sectionPosition)
        {
            try
            {
                await sectionService.UpdatePositionSectionAsync(idSection, sectionPosition);
                return Ok(); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("/boards/{idBoard}/sections")]
        public async Task<IActionResult> GetSectionWithCardsBoardAsync(Guid idBoard)
        {
            try
            {
                var result = await sectionService.GetSectionWithCardsBoardAsync(idBoard);
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
