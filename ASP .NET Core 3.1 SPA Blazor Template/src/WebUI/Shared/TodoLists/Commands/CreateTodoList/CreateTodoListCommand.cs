using Template.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Template.WebUI.Shared.Common.Interfaces;
using Template.WebUI.Shared.Common.Models;

namespace Template.WebUI.Shared.TodoLists.Commands.CreateTodoList
{
    public partial class CreateTodoListCommand : IRequest<ApiResponse<int>>
    {
        public string Title { get; set; }
    }

    public class CreateTodoListCommandHandler : IRequestHandler<CreateTodoListCommand, ApiResponse<int>>
    {
        private readonly IApplicationDbContext _context;

        public CreateTodoListCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse<int>> Handle(CreateTodoListCommand request, CancellationToken cancellationToken)
        {
            var entity = new TodoList();

            entity.Title = request.Title;

            _context.TodoLists.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id.ToApiResponse();
        }
    }
}
