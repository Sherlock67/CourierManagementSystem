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
        //public IEnumerable<Order> SearchByConsignmentNumber(string consignmentNumber);
    }
}
