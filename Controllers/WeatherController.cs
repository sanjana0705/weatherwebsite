
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using weatherapp.Models;

namespace weatherapp.Controllers
{
    public class WeatherController : Controller
    {
        private readonly string apiKey = "24372c09dc3c924006aefd69a4e86d30"; 
        public async Task<IActionResult> Index(string city)
        {
            WeatherModel weather = null;

            if (string.IsNullOrEmpty(city))
            {
                city = "Mumbai";
            }

            using (HttpClient client = new HttpClient())
            {
                string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    weather = JsonConvert.DeserializeObject<WeatherModel>(result);
                }
                else
                {
                    // Set error message to show on the same page
                    ViewBag.Error = "❌ City not found. Please enter a valid city name.";
                    weather = new WeatherModel
                    {
                        Name = "",
                        Main = new Main(),
                        Weather = new List<Weather> { new Weather() },
                        Wind = new Wind(),
                        Clouds = new Clouds(),
                        Sys = new Sys()
                    };
                }
            }

            // Always return the view, even if error occurred
            return View(weather);
        }
    }
}
