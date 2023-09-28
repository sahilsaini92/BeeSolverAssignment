using BeeSolverAssignment.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeeSolverAssignment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardsController : Controller
    {
        public ICardService _cardService;
        public CardsController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpGet(Name = "GetAllCards")]
        public async Task<IActionResult> GetAllCards([FromQuery] string? name, [FromQuery] string[] colours, [FromQuery] string[] types)
        {
            try
            {
                var data = await _cardService.GetAllCards(name, colours, types);
                return Ok(data);
            }
            catch(Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }
    }
}
