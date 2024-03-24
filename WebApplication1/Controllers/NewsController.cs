using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class NewsController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://news-api14.p.rapidapi.com/top-headlines?country=tr&language=tr&pageSize=10&category=all%20categories&sortBy=timestamp"),
                Headers =
                {
                    { "X-RapidAPI-Key", "986ab9c5ebmshe70e9b79beed08dp170b3bjsnb772ae6a2801" },
                    { "X-RapidAPI-Host", "news-api14.p.rapidapi.com" },
                },
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var newsData = JsonConvert.DeserializeObject<NewsModel.Rootobject>(body);
                return View(newsData);
            }
        }
    }
}
