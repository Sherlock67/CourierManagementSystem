using CourierSystemDataLayer.Model;
using CourierSystemDataLayer.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierSystemDataLayer.Interfaces
{
    public interface IOrder
    {

        public Task<OrderViewModel> CreateOrder(OrderViewModel order);
        public Task SearchByConsignmentNumber(string consignmentNumber);
    }
}
