using CourierSystemDataLayer.Interfaces;
using CourierSystemDataLayer.Model;
using CourierSystemDataLayer.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierSystemBusinessLayer.Services
{
    public class OrderPlaceService 
    {

        private readonly IOrder order;
        public OrderPlaceService(IOrder order)
        {
            this.order = order;
        }

        public async Task<OrderViewModel> PlaceOrder(OrderViewModel orderViewModel)
        {
            return await order.CreateOrder(orderViewModel);
        }
    }
}
