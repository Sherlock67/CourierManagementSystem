using CourierSystemDataLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CourierManagementFrontend.Controllers
{
    public class CustomerController : Controller
    {
        private static string url = "https://localhost:7133/";
        [HttpGet]
        public IActionResult CustomerRegistration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CustomerRegistration(Customer customer)
        {
            string custommsg = string.Empty;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var responseMsg = await client.PostAsJsonAsync("/api/v1/CustomerRegistrationApi/CustomerRegistration", customer);
                if (responseMsg != null)
                {
                    var res = responseMsg.Content.ReadAsStringAsync().Result;
                    custommsg = JsonConvert.DeserializeObject<string>(res);
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult CustomerLogin()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CustomerLogin(Customer c)
        {
            bool custommsg = false;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var responseMsg = await client.PostAsJsonAsync("/api/v1/CustomerRegistrationApi/CustomerLogin", c);

                if (responseMsg != null)
                {
                    var res = responseMsg.Content.ReadAsStringAsync().Result;
                    custommsg = JsonConvert.DeserializeObject<bool>(res);
                }
                if (custommsg == true)
                {
                    return RedirectToAction("PlaceOrder", "OrderPlace");
                }
                else
                {
                    return RedirectToAction("CustomerLogin", "Customer");
                }
            }
        }
    }
}
