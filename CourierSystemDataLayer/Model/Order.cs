using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierSystemDataLayer.Model
{
    public class Order 
    {
        [Key]
        public string OrderId { get; set; }

        public string ConsignmentNumber { get; set; }

        public DateTime OrderPlacingDate { get; set; }

        public string ProductName { get; set; }

        public DateTime FinalDateToReachDestination { get; set; } = DateTime.Now + TimeSpan.FromDays(3);

        public string CurrentPlace { get; set; }
        
      
        
    }
}
