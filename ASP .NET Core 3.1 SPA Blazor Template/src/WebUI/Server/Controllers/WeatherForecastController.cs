using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Template.Application.WeatherForecasts.Queries.GetWeatherForecasts;
using WebUI.Shared.Models.WeatherForecast;

namespace WebUI.Server.Controllers
{
    public class WeatherForecastController : ApiController
    {
        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            var result = await Mediator.Send(new GetWeatherForecastsQuery());
            return result;
        }
    }
}
