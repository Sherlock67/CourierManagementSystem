using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierSystemDataLayer.Model
{
    public class Recipant 
    {
        [Key]
        public string RecipantId { get; set; }

        public string RecipantName { get; set; }

        public string Address { get; set; }

        public string MobileNumber { get; set; }
    }
}
