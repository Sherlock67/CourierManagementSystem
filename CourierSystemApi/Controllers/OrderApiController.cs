using CourierSystemBusinessLayer.Services;
using CourierSystemDataLayer.Data;
using CourierSystemDataLayer.Model;
using CourierSystemDataLayer.Viewmodels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourierSystemApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderApiController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        private readonly OrderPlaceService orderPlace;
       
        public OrderApiController(OrderPlaceService orderPlace, ApplicationDbContext db)
        {
            this.orderPlace = orderPlace;
            this.db = db;
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
        public async Task<ActionResult<Order>> GetDetailsofOrder(int consignmentnumber)
        {

            var order = await db.orders.FirstOrDefaultAsync(o => o.ConsignmentNumber == consignmentnumber);

            if (order == null)
            {
                return NotFound();
            }

            return order;

        }
    }
}
