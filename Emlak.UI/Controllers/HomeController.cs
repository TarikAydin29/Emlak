using Emlak.Entity.Concrete;
using Emlak.UI.Models;
using Emlak.UI.Models.PropertyVMs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;

namespace Emlak.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory httpClient;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClient)
        {
            _logger = logger;
            this.httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Details(string id)
        {
            var client = httpClient.CreateClient();
            var responseMessaege = await client.GetAsync($"https://localhost:7090/api/Property/GetById/{id}");
            if (responseMessaege.IsSuccessStatusCode)
            {
                var jsonData = await responseMessaege.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<PropertyDetailsVM>(jsonData);


                var client2 = httpClient.CreateClient();
                var responseMessaege2 = await client2.GetAsync($"https://localhost:7090/api/Agent/GetById/{value.AgentId}");
                if (responseMessaege2.IsSuccessStatusCode)
                {
                    var jsonData2 = await responseMessaege2.Content.ReadAsStringAsync();
                    var value2 = JsonConvert.DeserializeObject<Agent>(jsonData2);
                    value.Agent = value2;
                }
                return View(value);
            }
            return View();
        }

        public async Task<IActionResult> FiltredProperty(string adres)
        {
            List<PropertListVM> list = new List<PropertListVM>();
            var client = httpClient.CreateClient();

            var responseMessaege = await client.GetAsync("https://localhost:7090/api/Property/GetList");

            if (responseMessaege.IsSuccessStatusCode)
            {
                var jsonData = await responseMessaege.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<PropertListVM>>(jsonData);
                foreach (var item in values)
                {
                    if (item.Adress.Contains(adres))
                    {
                        list.Add(item);
                    }
                }
                return View(list.Take(6));
            }
            return View();
        }
    }
}