namespace Template.WebApp.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using Application.Managers.Commands.Create;
    using Application.Managers.Commands.Update;
    using Template.Application.Managers.Queries.GetManagerById;
    using Template.WebApp.Models;
    using Template.Application.Managers.Commands.Delete;

    public class ManagerController : BaseController
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateManagerCommand command)
        {
            await Mediator.Send(command);

            return this.Redirect("/");
        }

        [HttpGet]
        public async Task<ActionResult<ManagerViewModel>> Edit([FromQuery]string managerId)
        {
            var manager = await Mediator.Send(new GetManagerByIdQuery { Id = managerId });
            var command = new UpdateManagerCommand();
            var managerUpdateDto = new ManagerUpdateDto
            {
                ManagerViewModel = manager,
                UpdateManagerCommand = command
            };
            return this.View(managerUpdateDto);
        }

        [HttpPost]
        public async Task<ActionResult> Edit([FromForm]UpdateManagerCommand command)
        {
            await Mediator.Send(command);

            return this.Redirect("/");
        }

        [HttpGet]
        public async Task<ActionResult<ManagerViewModel>> Delete([FromQuery]string managerId)
        {
            var manager = await Mediator.Send(new GetManagerByIdQuery { Id = managerId });
            var command = new DeleteManagerCommand();
            var managerUpdateDto = new ManagerDeleteDto
            {
                ManagerViewModel = manager,
                DeleteManagerCommand = command
            };
            return this.View(managerUpdateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm]DeleteManagerCommand command)
        {
            await Mediator.Send(command);

            return this.Redirect("/");
        }
    }
}
