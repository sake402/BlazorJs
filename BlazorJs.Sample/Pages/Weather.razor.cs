using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace BlazorJs.Sample.Pages
{
    public partial class Weather : ComponentBase
    {
        private WeatherForecast[] forecasts;

        protected override async Task OnInitializedAsync()
        {
            // Simulate asynchronous loading to demonstrate streaming rendering
            await Task.Delay(500);

            var startDate = DateTime.Now;
            var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
            forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = new Random().Next(-20, 55),
                Summary = summaries[new Random().Next(summaries.Length)]
            }).ToArray();
        }

        private class WeatherForecast
        {
            public DateTime Date { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }
            public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        }

    }
}
