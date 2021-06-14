using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Beeline.QueryExporter.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var testValue = _configuration.GetValue<string>("APP_TEST_VALUE");
            return Content($"I'm hockey! With value from \"APP_TEST_VALUE\" environment value = {testValue}");
        }
    }
}
