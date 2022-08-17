using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VortexdeCodeBL;

namespace VortexdeCodeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityGuardController : ControllerBase
    {
        private Interface1 _Interface1;

        public SecurityGuardController(Interface1 interface1)
        {
            _Interface1 = interface1;
        }

        [HttpGet(Name = "TestMethod")]
        public IEnumerable<WeatherForecast> Get()
        {

            _Interface1.testMethod();
            return null;
        }
    }
}
