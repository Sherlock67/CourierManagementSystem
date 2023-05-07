using CourierSystemDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierSystemDataLayer.Viewmodels
{
    public class OrderViewModel
    {
        public string ConsignmentNumber { get; set; }

        public DateTime OrderPlacingDate { get; set; }

        public string ProductName { get; set; }

        public DateTime FinalDateToReachDestination { get; set; } = DateTime.Now + TimeSpan.FromDays(3);

        public string CurrentPlace { get; set; }

        public string RecipantName { get; set; }

        public string Address { get; set; }

        public string MobileNumber { get; set; }
    }
}
