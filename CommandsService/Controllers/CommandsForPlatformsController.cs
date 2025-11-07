using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsForPlatformsController : ControllerBase
    {
        public CommandsForPlatformsController() { }

        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("--> Inbound POST # Command Service");
            return Ok("Inbound test from Platforms Controller");
        }
    }
}
