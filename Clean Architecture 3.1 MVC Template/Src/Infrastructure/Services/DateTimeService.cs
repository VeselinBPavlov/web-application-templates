using Template.Application.Common.Interfaces;
using System;

namespace Template.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
