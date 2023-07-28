using Emlak.UI.Models.UserVMs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Emlak.UI.Controllers
{
    public class UserController : Controller
    {

        private readonly IHttpClientFactory httpClient;

        public UserController(IHttpClientFactory httpClient)
        {
            this.httpClient = httpClient;
        }



        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM vm)
        {

            var clientt = httpClient.CreateClient();
            var jsonData = JsonConvert.SerializeObject(vm);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await clientt.PostAsync($"https://localhost:7090/api/User/Login", stringContent);
            var user = await responseMessage.Content.ReadAsStringAsync();
            if (responseMessage.IsSuccessStatusCode)
            {
                HttpContext.Session.SetString("userName", user);
                return RedirectToAction("Index", "AdminProperty");
            }
            return View();
        }
    }
}
