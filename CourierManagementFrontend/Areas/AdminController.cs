using CourierSystemDataLayer.Model;
using CourierSystemDataLayer.Viewmodels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CourierManagementFrontend.Areas
{
    public class AdminController : Controller
    {
        private static string url = "https://localhost:7133/";
        [HttpGet]
        public IActionResult CreateNewShipmentInfo()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateNewShipmentInfo(ShipmentInfo shipmentinfo)
        {
            ShipmentInfo _shipmentinfo;
            //string custommsg = string.Empty;
            //ShipmentInfoViewModel custommsg;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var responseMsg = await client.PostAsJsonAsync("/api/v1/Admin/CreateNewShipmentInfo", shipmentinfo);
                if (responseMsg != null)
                {

                    var res = responseMsg.Content.ReadAsStringAsync().Result;
                    _shipmentinfo = JsonConvert.DeserializeObject<ShipmentInfo>(res);
                }
            }
            return View();
        }
    }
}
