using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Electronics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProController : ControllerBase
    {
        [HttpGet]
        public IActionResult Print()
        {
            return Ok();
        }
    }
}
