using Microsoft.AspNetCore.Mvc;

namespace ContactManagerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PingController : ControllerBase
    {
        public PingController()
        {
        }

        [HttpGet]
        public IActionResult GetPing()
        {
            return Ok("pong");
        }
    }
}
