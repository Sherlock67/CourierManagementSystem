using CourierSystemDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierSystemDataLayer.Interfaces
{
    public interface IOrder
    {

        public Task<Order> CreateOrder(Order order);
        public Task SearchByConsignmentNumber(string consignmentNumber);
    }
}
