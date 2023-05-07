using CourierSystemDataLayer.Interfaces;
using CourierSystemDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierSystemDataLayer.Repository
{
    public class OrderRepository : IOrder
    {
        public Task<Order> CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public Task SearchByConsignmentNumber(string consignmentNumber)
        {
            throw new NotImplementedException();
        }
    }
}
