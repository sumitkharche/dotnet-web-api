using Microsoft.AspNetCore.Mvc;

namespace demo_web_api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    private readonly IConfiguration _configuration;
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, 
        IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
    {
        _configuration = configuration;
        _logger = logger;
        _webHostEnvironment = webHostEnvironment;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)],
            DB = _configuration.GetValue<string>("Dbval")
        })
        .ToArray();
    }

    //[HttpGet(Name = "GetConfig")]
    //public IActionResult GetConfig()
    //{
      
    //    //string value = _configuration.GetValue<string>("Dbval");
    //    return Ok();
    //}


}
