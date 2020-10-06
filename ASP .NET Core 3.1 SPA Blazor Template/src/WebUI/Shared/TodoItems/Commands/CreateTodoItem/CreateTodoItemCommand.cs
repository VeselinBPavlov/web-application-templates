﻿using Template.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Template.WebUI.Shared.Common.Interfaces;
using Template.WebUI.Shared.Common.Models;

namespace Template.WebUI.Shared.TodoItems.Commands.CreateTodoItem
{
    public class CreateTodoItemCommand : IRequest<ApiResponse<int>>
    {
        public int ListId { get; set; }

        public string Title { get; set; }
    }

    public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, ApiResponse<int>>
    {
        private readonly IApplicationDbContext _context;

        public CreateTodoItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse<int>> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var entity = new TodoItem
            {
                ListId = request.ListId,
                Title = request.Title,
                Done = false
            };

            _context.TodoItems.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id.ToApiResponse();
        }
    }
}
