using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class WeatherController : Controller
    {
        public async Task<IActionResult> Index(string cityName)
        {
            if (!string.IsNullOrEmpty(cityName))
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://the-weather-api.p.rapidapi.com/api/weather/{cityName}"),
                    Headers =
                {
                    { "X-RapidAPI-Key", "986ab9c5ebmshe70e9b79beed08dp170b3bjsnb772ae6a2801" },
                    { "X-RapidAPI-Host", "the-weather-api.p.rapidapi.com" },
                },
                };

                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var weatherData = Newtonsoft.Json.JsonConvert.DeserializeObject<WeatherModel.Rootobject>(body);
                    return View(weatherData);
                }
            }
            else
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://the-weather-api.p.rapidapi.com/api/weather/denizli"),
                    Headers =
                {
                    { "X-RapidAPI-Key", "986ab9c5ebmshe70e9b79beed08dp170b3bjsnb772ae6a2801" },
                    { "X-RapidAPI-Host", "the-weather-api.p.rapidapi.com" },
                },
                };

                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var weatherData = Newtonsoft.Json.JsonConvert.DeserializeObject<WeatherModel.Rootobject>(body);
                    return View(weatherData);
                }
            }

        }
    }
}
