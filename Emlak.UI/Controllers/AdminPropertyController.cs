using AutoMapper;
using Emlak.Entity.Concrete;
using Emlak.UI.Models.PropertyVMs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Emlak.UI.Controllers
{
    public class AdminPropertyController : Controller
    {

        private readonly IHttpClientFactory httpClient;
        private readonly IMapper mapper;

        public AdminPropertyController(IHttpClientFactory httpClient, IMapper mapper)
        {
            this.httpClient = httpClient;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var user = HttpContext.Session.GetString("userName");

            var client = httpClient.CreateClient();
            var responseMessaege2 = await client.GetAsync($"https://localhost:7090/api/Agent/GetByName/{user}");

            var jsonData2 = await responseMessaege2.Content.ReadAsStringAsync();
            var agent = JsonConvert.DeserializeObject<Agent>(jsonData2);
            HttpContext.Session.SetString("agentId", agent.AgentId);

            var responseMessaege = await client.GetAsync($"https://localhost:7090/api/Property/GetByAgentIdList/{agent.AgentId}");


            if (responseMessaege.IsSuccessStatusCode)
            {
                var jsonData = await responseMessaege.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<PropertListVM>>(jsonData);
                return View(values);
            }
            return View();
        }


        public IActionResult Add()
        {
            //var client = httpClient.CreateClient();
            //var responseMessaege = await client.GetAsync("https://localhost:7090/api/Agent");
            //if (responseMessaege.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessaege.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<List<Agent>>(jsonData);
            //    ViewBag.agents = new SelectList(values, "AgentId", "Name");
            //}
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreatePropertyVM vm)
        {
            vm.AgentId = HttpContext.Session.GetString("agentId");

            var clientt = httpClient.CreateClient();
            var jsonData = JsonConvert.SerializeObject(vm);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await clientt.PostAsync("https://localhost:7090/api/Property/Add", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var agentId = HttpContext.Session.GetString("agentId");

            var client = httpClient.CreateClient();

            var responseMessaege = await client.GetAsync($"https://localhost:7090/api/Property/GetById/{id}");


            if (responseMessaege.IsSuccessStatusCode)
            {
                var jsonData = await responseMessaege.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdatePropertyVM>(jsonData);
                value.AgentId = agentId;
                return View(value);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdatePropertyVM vm)
        {
            vm.AgentId = HttpContext.Session.GetString("agentId");

            var clientt = httpClient.CreateClient();
            var jsonData = JsonConvert.SerializeObject(vm);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await clientt.PutAsync($"https://localhost:7090/api/Property/Update/{vm.PropertyID}", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var client = httpClient.CreateClient();
            var responseMessaege = await client.DeleteAsync($"https://localhost:7090/api/Property/Delete/{id}");
            if (responseMessaege.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
