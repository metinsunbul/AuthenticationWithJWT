using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        private static readonly string[] Sehirler = new[]
        {
            "Erzurum", "Ordu", "Istanb", "Ankara", "Çanakale", "Bursa", "Adıyaman", "Edirne", "Keşan", "Sivas","Trabzon","Artvin"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("getforecast/{id}")]
        public IEnumerable<WeatherForecast> GetForecast(int id)
        {
            List<WeatherForecast> weatherForecasts = new List<WeatherForecast>();
            var rng = new Random();
            int i = 0;
            while (i < 30)
            {
                weatherForecasts.Add(new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(i),
                    TemperatureC = rng.Next(-20, 55),
                    Sehir = Sehirler[id]
                });
                i++;
            }
            return weatherForecasts;
        }
    }
}
