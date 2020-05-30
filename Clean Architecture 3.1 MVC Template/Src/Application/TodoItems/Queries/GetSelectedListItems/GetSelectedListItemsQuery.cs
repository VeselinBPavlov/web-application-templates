using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Template.Application.Common.Interfaces;

namespace Template.Application.TodoItems.Queries.GetSelectedListItems
{
    public class GetSelectedListItemsQuery : IRequest
    {
        public int Id { get; set; }
    }

    public class GetSelectedListItemsQueryHandler : IRequestHandler<GetSelectedListItemsQuery>
    {
        private readonly IApplicationDbContext _context;

        public GetSelectedListItemsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(GetSelectedListItemsQuery request, CancellationToken cancellationToken)
        {
            var lists = _context.TodoLists;

            foreach (var list in lists)
            {
                list.IsSelected = list.Id == request.Id ? true : false;
            }

            _context.TodoLists.UpdateRange(lists);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
