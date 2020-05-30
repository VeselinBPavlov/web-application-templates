using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Template.Application.WeatherForecasts.Queries.GetWeatherForecasts;

namespace Template.WebUI.Controllers
{
    public class WeatherForecastController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View(await Mediator.Send(new GetWeatherForecastsQuery())); 
        }
    }
}
