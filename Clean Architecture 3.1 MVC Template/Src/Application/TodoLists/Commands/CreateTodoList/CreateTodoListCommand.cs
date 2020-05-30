using Template.Application.Common.Interfaces;
using Template.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Template.Application.TodoLists.Commands.CreateTodoList
{
    public partial class CreateTodoListCommand : IRequest<int>
    {
        public string Title { get; set; }
    }

    public class CreateTodoListCommandHandler : IRequestHandler<CreateTodoListCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateTodoListCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateTodoListCommand request, CancellationToken cancellationToken)
        {
            var entity = new TodoList();

            entity.Title = request.Title;
            entity.IsSelected = true;

            _context.TodoLists.Add(entity);

            var lists = await _context.TodoLists.Where(l => l.Id != entity.Id).ToListAsync();

            if (lists != null)
            {
                foreach (var list in lists)
                {
                    list.IsSelected = false;
                }

                _context.TodoLists.UpdateRange(lists);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
