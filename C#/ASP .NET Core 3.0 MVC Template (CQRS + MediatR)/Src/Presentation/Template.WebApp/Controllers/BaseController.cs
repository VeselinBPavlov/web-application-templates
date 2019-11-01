namespace Template.WebApp.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;

    public abstract class BaseController : Controller
    {
        private IMediator mediator;

        protected IMediator Mediator => this.mediator ?? (this.mediator = HttpContext.RequestServices.GetService<IMediator>());
    }
}