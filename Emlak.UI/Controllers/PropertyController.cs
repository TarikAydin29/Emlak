using Emlak.DAL.Abstract;
using Emlak.Entity.Concrete;
using Emlak.UI.Models.AgentVMs;
using Emlak.UI.Models.PropertyVMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Emlak.UI.Controllers
{
    public class PropertyController : Controller
    {

        private readonly IHttpClientFactory httpClient;

        public PropertyController(IHttpClientFactory httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var client = httpClient.CreateClient();
            var responseMessaege = await client.GetAsync("https://localhost:7090/api/Property/GetList");
            if (responseMessaege.IsSuccessStatusCode)
            {
                var jsonData = await responseMessaege.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<PropertListVM>>(jsonData);
                return View(values);
            }
            return View();
        }


        public async Task<IActionResult> Add()
        {
            var client = httpClient.CreateClient();
            var responseMessaege = await client.GetAsync("https://localhost:7090/api/Agent");
            if (responseMessaege.IsSuccessStatusCode)
            {
                var jsonData = await responseMessaege.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<Agent>>(jsonData);
                ViewBag.agents = new SelectList(values, "AgentId", "Name");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreatePropertyVM vm)
        {
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
    }
}
