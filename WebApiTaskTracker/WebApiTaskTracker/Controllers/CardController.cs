using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiTaskTracker.Domain.DTO;
using WebApiTaskTracker.Domain.Interfaces.Services;

namespace WebApiTaskTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController(ICardService cardService, IValidatorService validatorService) : ControllerBase
    {
        private ICardService _cardService = cardService;

        [HttpPost("card")]
        public async Task<IActionResult> AddCard([FromBody] AddCardRequest addCardRequest)
        {
            var validationResult = validatorService.ValidationEntity(addCardRequest);
            if (validationResult.Any())
            {
                return BadRequest(validationResult);
            }

            try
            {
                await cardService.AddCard(addCardRequest.SectionId, addCardRequest.CreatorId, addCardRequest.Name,
                    addCardRequest.position);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
