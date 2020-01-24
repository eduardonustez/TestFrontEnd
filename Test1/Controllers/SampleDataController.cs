using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Test1.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }
        [HttpGet("[action]")]
        public async Task<IEnumerable<Project>> ObtenerProyectos()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://localhost:44393/api/Project");
            var resul = JsonConvert.DeserializeObject<List<Project>>(json);
            //List<Project> resul = new List<Project>();
            //resul.Add(new Project { Id = 1, ProjectName = "Peajes", Location = "Bogota" });
            //resul.Add(new Project { Id = 1, ProjectName = "ECD", Location = "Bogota" });
            return resul;
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
        public class Project
        {
            public int Id { get; set; }
            public string ProjectName { get; set; }
            public string Location { get; set; }
           public bool IsEdit { get; set; }
        }
    }
}
