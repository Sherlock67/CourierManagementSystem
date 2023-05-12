using CourierSystemBusinessLayer.Services;
using CourierSystemDataLayer.Interfaces;
using CourierSystemDataLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourierSystemApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomerRegistrationApiController : ControllerBase
    {
        private readonly CustomerService customerService;

        public CustomerRegistrationApiController(CustomerService customerService)
        {
            this.customerService = customerService;
        }
        [HttpPost("CustomerRegistration")]
        public async Task<Object> CustomerRegistration([FromBody] Customer c)
        {
            try
            {
                await customerService.RegisterCustomer(c);
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        [HttpPost("CustomerLogin")]
        public async Task<bool> CustomerLogin(CustomerLogin customer)
        {
            return await customerService.VerifyUserAsync(customer);

        }
    }
}
