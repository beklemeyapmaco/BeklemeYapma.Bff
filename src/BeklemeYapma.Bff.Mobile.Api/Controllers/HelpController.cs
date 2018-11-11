using Microsoft.AspNetCore.Mvc;

namespace BeklemeYapma.Bff.Mobile.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/healthcheck")]
    public class HelpController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}