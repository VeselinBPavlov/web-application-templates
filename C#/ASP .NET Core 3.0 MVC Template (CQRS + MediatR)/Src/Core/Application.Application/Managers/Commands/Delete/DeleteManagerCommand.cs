namespace Application.Application.Managers.Commands.Delete
{
    using MediatR;

    public class DeleteManagerCommand : IRequest
    {
        public string Id { get; set; }
    }
}
