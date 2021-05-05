using Microsoft.AspNetCore.Mvc;

namespace WorldWideImporters.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HealthzController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
