using Microsoft.AspNetCore.Mvc;
using Sum_Minus.Services;
using Sum_Minus.Entities;

namespace Sum_Minus.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OperationController : ControllerBase
    {
        private readonly IOperationService _operationService;
        private readonly IApiCallService _apiCallService;

        public OperationController(IOperationService operationService, IApiCallService apiCallService)
        {
            _operationService = operationService;
            _apiCallService = apiCallService;
        }

        [HttpPost("sum")]
        public IActionResult Sum([FromBody] OperationRequest request)
        {
            var result = _operationService.Sum(request);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("minus")]
        public IActionResult Minus([FromBody] OperationRequest request)
        {
            var result = _operationService.Minus(request);
            return StatusCode(result.StatusCode, result);
        }

        //For testing
        [HttpGet("call-api")]
        public async Task<IActionResult> CallExternalApi()
        {
            var result = await _apiCallService.CallApiAsync();
            return StatusCode(result.StatusCode, result);
        }
    }
}
