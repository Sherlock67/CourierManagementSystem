using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierSystemDataLayer.Viewmodels
{
    public class ShipmentInfoViewModel
    {
        public string ShipmentMethod { get; set; }

        public string ShippingTerms { get; set; }

        public string ShipVia { get; set; }

        public string PaymentStatus { get; set; }

        public DateTime DeliveryDate { get; set; }
    }
}
