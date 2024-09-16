using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FirstAppController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "world";
        }
    }
}
