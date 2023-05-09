using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierSystemDataLayer.Model
{
    public class AdminClass
    {
        [Key]
        public int AdminId { get; set; }

        public string AdminName { get; set; }

        public string Password { get; set; }

        public string Username { get; set; }

        
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
