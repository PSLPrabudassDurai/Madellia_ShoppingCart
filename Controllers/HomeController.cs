using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SuperMarket_ShoppingCart.Models;
using SuperMarket_ShoppingCart.Shared.Models;
using System.Diagnostics;
using System.Text.Json.Serialization;
using static System.Net.WebRequestMethods;

namespace SuperMarket_ShoppingCart.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        string UserName = "abc";
        ShoppingDetails SD = new ShoppingDetails();
        string Messages = "";
        
        int shopID = 0;


        [HttpGet]
        public async Task<List<CartItemDetails>> ItemDetails()
        {
            List<CartItemDetails>? myShopList = new List<CartItemDetails>();
            string url = "/api/ShoppingDetails/";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                var CartItems = response.Content.ReadAsStringAsync().Result;
                myShopList = JsonConvert.DeserializeObject<List<CartItemDetails>>(CartItems);
                return myShopList;
            }
        } 
    }
}

