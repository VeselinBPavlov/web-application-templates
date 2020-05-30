using Template.Application.Common.Exceptions;
using Template.Application.Common.Interfaces;
using Template.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Template.Application.TodoLists.Commands.DeleteTodoList
{
    public class DeleteTodoListCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteTodoListCommandHandler : IRequestHandler<DeleteTodoListCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteTodoListCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteTodoListCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TodoLists
                .Include(l => l.Items)
                .Where(l => l.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(TodoList), request.Id);
            }

            if (entity.Items != null)
            {
                _context.TodoItems.RemoveRange(entity.Items);
            }

            _context.TodoLists.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            bool isAnySelected = _context.TodoLists.Any(l => l.IsSelected == true && l.Id != request.Id);

            if (!isAnySelected)
            {
                var list = _context.TodoLists.FirstOrDefault(l => l.Id != request.Id);

                if (list != null)
                {
                    list.IsSelected = true;
                    _context.TodoLists.Update(list);
                }
            }

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
