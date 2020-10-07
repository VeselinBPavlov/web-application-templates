using System;
using Template.WebUI.Shared.Common.Interfaces;

namespace Template.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
