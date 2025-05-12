using Microsoft.AspNetCore.Mvc;
using Sum_Minus.Services;
using Sum_Minus.Entities;  

namespace Sum_Minus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private readonly IOperationService _operationService;

        public OperationController(IOperationService operationService)
        {
            _operationService = operationService;
        }

        [HttpPost("sum")]
        public IActionResult Sum([FromBody] OperationRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid data.");
            }

            var result = _operationService.Sum(request.Number1, request.Number2);
            return Ok(new { result });
        }

        [HttpPost("minus")]
        public IActionResult Minus([FromBody] OperationRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid data.");
            }

            var result = _operationService.Minus(request.Number1, request.Number2);
            return Ok(new { result });
        }
    }
}
