using AutoMapper;
using AutoMapper.QueryableExtensions;
using Template.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Template.WebUI.Shared.Common.Interfaces;
using Template.WebUI.Shared.Common.Models;

namespace Template.WebUI.Shared.TodoLists.Queries.GetTodos
{
    public class GetTodosQuery : IRequest<ApiResponse<TodosVm>>
    {
    }

    public class GetTodosQueryHandler : IRequestHandler<GetTodosQuery, ApiResponse<TodosVm>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetTodosQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ApiResponse<TodosVm>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
        {
            var result = new TodosVm
            {
                PriorityLevels = Enum.GetValues(typeof(PriorityLevel))
                    .Cast<PriorityLevel>()
                    .Select(p => new PriorityLevelDto { Value = (int)p, Name = p.ToString() })
                    .ToList(),

                Lists = await _context.TodoLists
                    .ProjectTo<TodoListDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.Title)
                    .ToListAsync(cancellationToken)
            };

            return result.ToApiResponse();
        }
    }
}
