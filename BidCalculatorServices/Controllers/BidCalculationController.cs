using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BidCalculatorServices.Services;
using BidCalculatorServices.DTOs;

namespace BidCalculatorServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidCalculationController : ControllerBase
    {
        private readonly IBidCalculatorService _bidCalculatorService;

        public BidCalculationController(IBidCalculatorService bidCalculatorService)
        {
            _bidCalculatorService = bidCalculatorService;
        }

        [HttpPost("calculate")]
        public IActionResult Calculate([FromBody] BidCalculationRequestDto request)
        {
            // Null Chekc for Request
            if (request == null)
            {
                return BadRequest();
            }

            var result = _bidCalculatorService.CalculateTotal(request);
            return Ok(result);
        }
    }
}
