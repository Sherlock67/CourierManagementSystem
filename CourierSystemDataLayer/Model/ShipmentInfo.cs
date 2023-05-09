using System.ComponentModel.DataAnnotations;

namespace CourierSystemDataLayer.Model
{
    public class ShipmentInfo
    {
        [Key]
        public string ShipmentId { get; set; }

        public string ShipmentMethod { get; set; }

        public string ShippingTerms { get; set; }

        public string ShipVia { get; set; }

        public string PaymentStatus { get; set; }

        public DateTime DeliveryDate { get; set; }
    }
}
