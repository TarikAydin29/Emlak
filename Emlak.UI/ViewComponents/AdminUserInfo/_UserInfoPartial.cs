using Emlak.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace Emlak.UI.ViewComponents.AdminUserInfo
{
    public class _UserInfoPartial :ViewComponent
    {
        private readonly IHttpClientFactory httpClient;

        public _UserInfoPartial(IHttpClientFactory httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task< IViewComponentResult> InvokeAsync()
        {
            var user = HttpContext.Session.GetString("userName");

            var client = httpClient.CreateClient();
            var responseMessaege2 = await client.GetAsync($"https://localhost:7090/api/Agent/GetByName/{user}");

            var jsonData2 = await responseMessaege2.Content.ReadAsStringAsync();
            var agent = JsonConvert.DeserializeObject<Agent>(jsonData2);
            return View(agent);
        }
    }
}
