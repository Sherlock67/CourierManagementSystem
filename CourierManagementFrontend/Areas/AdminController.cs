﻿using CourierSystemDataLayer.Model;
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
        public IActionResult AdminLogin()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AdminLogin(AdminLogin login)
        {
            bool custommsg = false;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var responseMsg = await client.PostAsJsonAsync("/api/v1/Admin/AdminLogin", login);

                if (responseMsg != null)
                {
                    var res = responseMsg.Content.ReadAsStringAsync().Result;
                    custommsg = JsonConvert.DeserializeObject<bool>(res);
                }
                if (custommsg == true)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("UserLogin", "User");
                }
            }
        }

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
        public async Task<IActionResult> AllShippingInfo()
        {
            List<ShipmentInfo> infos = new List<ShipmentInfo>();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var responseMsg = await client.GetAsync("/api/v1/Admin/GetAllShipmentInfo");
                if (responseMsg != null)
                {
                    var infolist = responseMsg.Content.ReadAsStringAsync().Result;
                    infos = JsonConvert.DeserializeObject<List<ShipmentInfo>>(infolist);
                }
            }

            return View(infos);

        }
        public async Task<ActionResult> DeleteShipmentInfo(string? id)
        {
            string custommsg = string.Empty;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var responseMsg = await client.DeleteAsync("/api/v1/Admin/DeleteShipmentInfo?id=" + id);
                if (responseMsg.IsSuccessStatusCode)
                {
                    var res = responseMsg.Content.ReadAsStringAsync().Result;
                    custommsg = JsonConvert.DeserializeObject<string>(res);
                }
            }
            return RedirectToAction("AllShippingInfo");

        }
        [HttpGet]
        public async Task<IActionResult> UpdateShipmentInfo(string id)
        {
            ShipmentInfo info = new ShipmentInfo();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var prescriptionId = await client.GetAsync("/api/v1/Admin/GetShipmentInfoById?id=" + id);
                if (prescriptionId.IsSuccessStatusCode)
                {
                    var infos = prescriptionId.Content.ReadAsStringAsync().Result;
                    info = JsonConvert.DeserializeObject<ShipmentInfo>(infos);
                }

            }
            return View(info);

        }
        [HttpPost]
        public async Task<IActionResult> UpdateShipmentInfo(ShipmentInfo shipmentInfo)
        {

            string custommsg = string.Empty;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var responseMsg = await client.PutAsJsonAsync("/api/v1/Admin/UpdateShipmentInfo", shipmentInfo);
                if (responseMsg.IsSuccessStatusCode)
                {
                    var res = responseMsg.Content.ReadAsStringAsync().Result;
                    custommsg = JsonConvert.DeserializeObject<string>(res);
                }
            }
            
            return RedirectToAction("AllShippingInfo");

        }

        public async Task<IActionResult> GetOrderDetailsByConsignmentNumber(int consignmentnumber)

        {
            Order listOfOrder = new Order();
            //List<Order> listOfOrder = new List<Order>();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var responseMsg = await client.GetAsync("/api/v1/Admin/GetDetailsofOrder?consignmentnumber=" + consignmentnumber);
                if (responseMsg != null)
                {
                    var orderList = responseMsg.Content.ReadAsStringAsync().Result;
                    listOfOrder = JsonConvert.DeserializeObject<Order>(orderList);
                }
            }
            // return PartialView("_orderlist", listOfOrder);
            return View("GetOrderDetailsByConsignmentNumber", listOfOrder);
        }
        [HttpGet]
        public async Task<IActionResult> UpdateOrder(string id )
        {
            Order o = new Order();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var o_id = await client.GetAsync("/api/v1/Admin/GetById?id=" + id);
                if (o_id.IsSuccessStatusCode)
                {
                    var infos = o_id.Content.ReadAsStringAsync().Result;
                    o = JsonConvert.DeserializeObject<Order>(infos);
                }

            }
            return View(o);

        }
        [HttpPost]
        public async Task<IActionResult> UpdateOrder(Order order)
        {

            string custommsg = string.Empty;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var responseMsg = await client.PutAsJsonAsync("/api/v1/Admin/UpdateOrder", order);
                if (responseMsg.IsSuccessStatusCode)
                {
                    var res = responseMsg.Content.ReadAsStringAsync().Result;
                    custommsg = JsonConvert.DeserializeObject<string>(res);
                }
            }

            return RedirectToAction("AllShippingInfo");

        }
        [HttpGet]
        public IActionResult CreateNewShipperInfo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewShipperInfo(ShipperInfo shipperinfo)
        {
            ShipperInfo _shipperinfo;
            
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var responseMsg = await client.PostAsJsonAsync("/api/v1/Admin/CreateNewShipperInfo", shipperinfo);
                if (responseMsg != null)
                {

                    var res = responseMsg.Content.ReadAsStringAsync().Result;
                    _shipperinfo = JsonConvert.DeserializeObject<ShipperInfo>(res);
                }
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateShipperInfo(string id)
        {
            ShipperInfo info = new ShipperInfo();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var shipperId = await client.GetAsync("/api/v1/Admin/GetShipperInfoById?id=" + id);
                if (shipperId.IsSuccessStatusCode)
                {
                    var infos = shipperId.Content.ReadAsStringAsync().Result;
                    info = JsonConvert.DeserializeObject<ShipperInfo>(infos);
                }

            }
            return View(info);

        }
        [HttpPost]
        public async Task<IActionResult> UpdateShipperInfo(ShipperInfo info)
        {

            string custommsg = string.Empty;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var responseMsg = await client.PutAsJsonAsync("/api/v1/Admin/UpdateShipperInfo", info);
                if (responseMsg.IsSuccessStatusCode)
                {
                    var res = responseMsg.Content.ReadAsStringAsync().Result;
                    custommsg = JsonConvert.DeserializeObject<string>(res);
                }
            }

            return RedirectToAction("AllShipperInfo");

        }
        public async Task<IActionResult> AllShipperInfo()
        {
            List<ShipperInfo> infos = new List<ShipperInfo>();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var responseMsg = await client.GetAsync("/api/v1/Admin/GetAllShipperInfo");
                if (responseMsg != null)
                {
                    var infolist = responseMsg.Content.ReadAsStringAsync().Result;
                    infos = JsonConvert.DeserializeObject<List<ShipperInfo>>(infolist);
                }
            }

            return View(infos);

        }
        public async Task<ActionResult> DeleteShipperInfo(string? id)
        {
            string custommsg = string.Empty;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var responseMsg = await client.DeleteAsync("/api/v1/Admin/DeleteShipperInfo?id=" + id);
                if (responseMsg.IsSuccessStatusCode)
                {
                    var res = responseMsg.Content.ReadAsStringAsync().Result;
                    custommsg = JsonConvert.DeserializeObject<string>(res);
                }
            }
            return RedirectToAction("AllShipperInfo");

        }


    }
}
