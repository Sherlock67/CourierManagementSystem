using CourierSystemDataLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierSystemDataLayer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {



        }

        public DbSet<Customer> customers { get; set; }

        public DbSet<Order> orders { get; set; }
        public DbSet<Recipant> recipants { get; set; }
        public DbSet<Shipment> shipments { get; set; }
        public DbSet<ShipperInfo> shippers { get; set; }
        public DbSet<ShipmentInfo> shipmentInfos { get; set; }
        public DbSet<AdminClass> admins { get; set; }

    }
}
