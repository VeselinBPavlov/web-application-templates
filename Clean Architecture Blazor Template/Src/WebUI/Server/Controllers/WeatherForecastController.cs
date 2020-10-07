using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Template.WebUI.Shared.WeatherForecasts.Queries.GetWeatherForecasts;

namespace Template.WebUI.Server.Controllers
{
    [Authorize]
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
