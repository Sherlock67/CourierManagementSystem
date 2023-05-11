using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierSystemDataLayer.Model
{
    public class Customer
    {
        [Key]
        public string CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string CustomerUsername { get; set; }
        public string CustomerPassword { get; set; }
        public string CustomerEmail { get; set; }
        public string ConfirmPassword { get; set; }
        //public string ProductName { get; set; }





    }
}
