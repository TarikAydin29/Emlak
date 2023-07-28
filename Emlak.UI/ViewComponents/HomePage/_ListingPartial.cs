using Emlak.Entity.Concrete;
using Emlak.UI.Models.PropertyVMs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Emlak.UI.ViewComponents.HomePage
{
    public class _ListingPartial : ViewComponent
    {
        private readonly IHttpClientFactory httpClient;

        public _ListingPartial(IHttpClientFactory httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var user = HttpContext.Session.GetString("userName");

            var client = httpClient.CreateClient();

            var responseMessaege = await client.GetAsync("https://localhost:7090/api/Property/GetList");

            if (responseMessaege.IsSuccessStatusCode)
            {
                var jsonData = await responseMessaege.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<PropertListVM>>(jsonData);
                return View(values.Take(6));
            }
            return View();
        }
    }
}
