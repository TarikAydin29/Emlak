using Emlak.Entity.Concrete;
using Emlak.UI.Models.AgentVMs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Emlak.UI.Controllers
{
    public class AdminAgentController : Controller
    {
        private readonly IHttpClientFactory httpClient;

        public AdminAgentController(IHttpClientFactory httpClient)
        {
            this.httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = httpClient.CreateClient();
            var responseMessaege = await client.GetAsync("https://localhost:7090/api/Agent/GetList");
            if (responseMessaege.IsSuccessStatusCode)
            {
                var jsonData = await responseMessaege.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<Agent>>(jsonData);
                return View(values);
            }
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateAgentVM vm)
        {
            var clientt = httpClient.CreateClient();
            var jsonData = JsonConvert.SerializeObject(vm);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await clientt.PostAsync("https://localhost:7090/api/Agent/Add", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            AgentWithPropertiesVM vm = new AgentWithPropertiesVM();

            var client = httpClient.CreateClient();
            var responseMessaege = await client.GetAsync($"https://localhost:7090/api/Agent/GetById/{id}");
            if (responseMessaege.IsSuccessStatusCode)
            {
                var jsonData = await responseMessaege.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<Agent>(jsonData);
                if (value.Properties != null)
                {
                    foreach (var item in value!.Properties!)
                    {
                        vm.Properties.Add(item);
                    }
                }
                vm.Agent = value;
                return View(vm);
            }
            return View();
        }
        public IActionResult Deneme()
        {
            return View();
        }

    }
}
