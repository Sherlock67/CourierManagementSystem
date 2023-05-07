using CourierSystemDataLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierSystemDataLayer.Viewmodels
{
    public class OrderViewModel
    {

       
        public DateTime OrderPlacingDate { get; set; }

        public string ProductName { get; set; }

        public DateTime FinalDateToReachDestination { get; set; } 

        public string CurrentPlace { get; set; }

        public string RecipantName { get; set; }

        public string Address { get; set; }

        public string MobileNumber { get; set; }
        
        public string ConsignmentNumber { get;set; }
    }
}
