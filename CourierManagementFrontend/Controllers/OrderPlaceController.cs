using CourierSystemDataLayer.Model;
using CourierSystemDataLayer.Viewmodels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Net.Http.Headers;

namespace CourierManagementFrontend.Controllers
{
    public class OrderPlaceController : Controller
    {
        private static string url = "https://localhost:7133/";
        public IActionResult PlaceOrder()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>PlaceOrder(OrderViewModel orderViewModel)
        {
            OrderViewModel custommsg;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var responseMsg = await client.PostAsJsonAsync("/api/v1/OrderApi/CreateNewOrder", orderViewModel);
                if (responseMsg != null)
                {
                    
                    var res = responseMsg.Content.ReadAsStringAsync().Result;
                    custommsg = JsonConvert.DeserializeObject<OrderViewModel>(res);
                }
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetOrderDetailsByConsignmentNumber()
        
        
        {
            Order listOfOrder = new Order();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var responseMsg = await client.GetAsync("/api/v1/OrderApi/GetDetailsofOrder");
                if (responseMsg != null)
                {
                    var orderList = responseMsg.Content.ReadAsStringAsync().Result;
                    listOfOrder = JsonConvert.DeserializeObject<Order>(orderList);
                }
            }
            //return PartialView("_orderlist", listOfOrder);
            return View(listOfOrder);
        }
    }
}
