namespace Template.WebApp.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using Application.Managers.Queries.GetAllManagers;
    using Application.Managers.Queries.GetManagerById;
    using Application.Managers.Commands.Create;
    using Template.Application.Managers.Commands.Update;
    using Template.Application.Managers.Commands.Delete;

    public class ManagersController : BaseController
    {
        //GET: api/Managers/GetAll
        [HttpGet]
        public async Task<ActionResult<ManagersListViewModel>> GetAll()
        {
            var result = await Mediator.Send(new GetAllManagersListQuery {});
            return Ok(result);
        }

        //GET: api/Managers/Get/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ManagerViewModel>> Get(string id)
        {
            var result = await Mediator.Send(new GetManagerByIdQuery { Id = id });
            return Ok(result);
        }

        // POST: api/Managers/Create
        [HttpPost]
        public async Task<ActionResult> Create(CreateManagerCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }


        // PUT: api/Managers/Update
        [HttpPut]
        public async Task<ActionResult> Update(UpdateManagerCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        // DELETE: api/Managers/Delete/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await Mediator.Send(new DeleteManagerCommand { Id = id });

            return NoContent();
        }
    }
}
