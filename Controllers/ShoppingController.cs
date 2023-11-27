using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SuperMarket_ShoppingCart.Shared.Models;

namespace SuperMarket_ShoppingCart.Controllers
{
    public class ShoppingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async void ShoppingDetails(ShoppingDetails SD)
        {
            var json = JsonConvert.SerializeObject(SD, Formatting.Indented);
            var stringContent = new StringContent(json);            
            string url = "/api/ShoppingDetails/";
            using (HttpClient client = new HttpClient())
            {
                await client.PostAsync(url, stringContent);
            }
        }
    }
}
