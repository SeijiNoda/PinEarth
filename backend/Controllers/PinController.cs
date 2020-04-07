using Microsoft.AspNetCore.Mvc;


namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PinController : Controller
    {
        public PinController()
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("{idPin}")]
        public IActionResult Get(int idPin)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult post()
        {
            return Ok();
        }

        [HttpPut("{idPin}")]
        public IActionResult put(int idPin)
        {
            return Ok();
        }
        
        [HttpDelete("{idPin}")]
        public IActionResult delete(int idPin)
        {
            return Ok();
        }
    }
}