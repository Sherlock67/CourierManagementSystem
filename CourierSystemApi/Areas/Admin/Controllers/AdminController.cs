using CourierSystemBusinessLayer.Services;
using CourierSystemDataLayer.Data;
using CourierSystemDataLayer.Migrations;
using CourierSystemDataLayer.Model;
using CourierSystemDataLayer.Viewmodels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourierSystemApi.Areas.Admin.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ShipmentInfoService shipmentInfoService;
        private readonly ApplicationDbContext db;
        public AdminController(ShipmentInfoService shipmentInfoService, ApplicationDbContext db)
        {
            this.shipmentInfoService = shipmentInfoService;
            this.db = db;
        }

        [HttpPost("CreateNewShipmentInfo")]
        public async Task<object> CreateNewShipmentInfo([FromBody] ShipmentInfo shipmentInfo)
        {
            try
            {
                await shipmentInfoService.AddNewShipmentInfo(shipmentInfo);
                return shipmentInfo;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        [HttpGet("GetAllShipmentInfo")]
        public List<ShipmentInfo> GetAllShipmentInfo()
        {
            var data = shipmentInfoService.GetAllShipmentInfo();

            return data.ToList();
        }
        [HttpGet("GetShipmentInfoById")]
        public ShipmentInfo GetShipmentInfoById(string id)
        {
            try
            {
                return shipmentInfoService.GetShipmentInfoById(id);

            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpDelete("DeleteShipmentInfo")]
        public bool DeleteShipmentInfo(string id)
        {
            try
            {
                shipmentInfoService.DeleteShipmentInfo(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        [HttpPut("UpdateShipmentInfo")]
        public bool UpdateShipmentInfo(ShipmentInfo shipmentInfo)
        {
            try
            {
                shipmentInfoService.UpdateShipmentInfo(shipmentInfo);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        [HttpGet("GetDetailsofOrder")]
        public async Task<ActionResult<Order>> GetDetailsofOrder(int consignmentnumber)
        {

            var order = await db.orders.FirstOrDefaultAsync(o => o.ConsignmentNumber == consignmentnumber);

            if (order == null)
            {
                return NotFound();
            }

            return order;

        }
        [HttpGet("GetById")]
        public Order GetById(string Id)
        {
            return db.orders.Where(x => x.OrderId == Id).SingleOrDefault();
        }
        [HttpPut("UpdateOrder")]
        public void UpdateOrder(Order entity)
        {
            db.orders.Update(entity);
            db.SaveChanges();
        }





    }
}
