
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace CourierSystemDataLayer.Model
{
    public class ShipperInfo
    {
        [Key]
        public string ShipperId { get; set; }

        public string ShipperName { get; set; }

        public string ShipperPhoneNumber { get; set; }

      
    }
}
