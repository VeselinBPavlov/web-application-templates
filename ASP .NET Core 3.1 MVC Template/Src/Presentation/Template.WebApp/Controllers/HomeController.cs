namespace Template.WebApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    using Models;
    using Template.Application.Managers.Queries.GetAllManagers;
    using System.Threading.Tasks;

    public class HomeController : BaseController
    {
        [HttpGet]
        [Route("/")]
        [Route("Home/Index")]
        public async Task<IActionResult> Index()
        {
            var result = await Mediator.Send(new GetAllManagersListQuery());
            return this.View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
