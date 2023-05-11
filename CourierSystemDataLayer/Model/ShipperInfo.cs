
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace CourierSystemDataLayer.Model
{
    public class ShipperInfo
    {
        [Key]
        public string ShipperId { get; set; } = Guid.NewGuid().ToString();

        public string ShipperName { get; set; }

        public string ShipperPhoneNumber { get; set; }

        public string ShopName { get; set; }
        
        public string ShopAddress { get; set; }

        public string SellerName { get; set; }  

        public string SellerPhoneNumber { get; set; }   

        public string SellerEmail { get;set; }
    }
}
