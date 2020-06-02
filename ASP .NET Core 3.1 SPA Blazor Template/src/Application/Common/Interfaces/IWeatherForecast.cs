using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Application.Common.Interfaces
{
    public interface IWeatherForecast
    {
        DateTime Date { get; set; }

        int TemperatureC { get; set; }

        int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        string Summary { get; set; }
    }
}
