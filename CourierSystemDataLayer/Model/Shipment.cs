using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierSystemDataLayer.Model
{
    public class Shipment
    {
        [Key]
        public string ShipmentId { get; set; }

        public DateTime ShipmentSentDate { get; set; }
        public DateTime ShipmentArrivedDate { get; set;  }
        public string ShipmentType { get; set; }
        //customer -> one to many relationship 
        //shipment info -> normal property
        //delivery boy info 
        public string ShipmentDescription { get; set; }
    }
}
