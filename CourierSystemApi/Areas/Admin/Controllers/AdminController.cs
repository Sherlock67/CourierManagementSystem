using CourierSystemBusinessLayer.Services;
using CourierSystemDataLayer.Model;
using CourierSystemDataLayer.Viewmodels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourierSystemApi.Areas.Admin.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ShipmentInfoService shipmentInfoService;
        public AdminController(ShipmentInfoService shipmentInfoService)
        {
            this.shipmentInfoService = shipmentInfoService;
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
        [HttpPut("UpdatePrescription")]
        public bool UpdatePrescription(ShipmentInfo shipmentInfo)
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




    }
}
