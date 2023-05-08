using CourierSystemBusinessLayer.Services;
using CourierSystemDataLayer.Model;
using CourierSystemDataLayer.Viewmodels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourierSystemApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderApiController : ControllerBase
    {
        private readonly OrderPlaceService orderPlace;
        private IEnumerable<Order>? result;
        public OrderApiController(OrderPlaceService orderPlace)
        {
            this.orderPlace = orderPlace;
        }
        [HttpPost("CreateNewOrder")]
        public async Task<object> CreateNewOrder([FromBody] OrderViewModel orderViewModel)
        {
            try
            {
                await orderPlace.PlaceOrder(orderViewModel);
                return orderViewModel;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        [HttpGet("GetDetailsofOrder")]
        
        public IEnumerable<Order> GetDetailsofOrder(string consignmentnumber)
        {
            
            try
            {
                result = orderPlace.TrackOrder(consignmentnumber);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
    }
}
