using CandidateManagement_BusinessObject;
using CandidateManagement_Service;
using Microsoft.AspNetCore.Mvc;

namespace CandidateManagement_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private IHRAccountService _hraccountService;
        private ICandidateProfileService _candidateProfileService;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _hraccountService = new HRAccountService();
            _candidateProfileService = new CandidateProfileService();
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet("account")]
        public ActionResult<List<Hraccount>> GetAllAccount()
        {
            return Ok(_hraccountService.GetAccounts());
        }
        [HttpGet("candidate-profile")]
        public ActionResult<List<CandidateProfile>> GetAllCandidateProfile()
        {
            return Ok(_candidateProfileService.GetCandidateProfiles());
        }
    }
}
