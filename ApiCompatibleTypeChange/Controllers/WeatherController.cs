using Microsoft.AspNetCore.Mvc;

namespace ApiCompatibleTypeChange.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherController : ControllerBase
{
    [HttpPost(Name = "PostWeather")]
    public IActionResult Post(Weather weather)
    {
        return Accepted();
    }
}
