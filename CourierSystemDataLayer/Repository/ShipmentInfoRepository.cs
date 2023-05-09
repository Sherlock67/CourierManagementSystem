using CourierSystemDataLayer.Data;
using CourierSystemDataLayer.Interfaces;
using CourierSystemDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierSystemDataLayer.Repository
{
    public class ShipmentInfoRepository : IShipmentInfo
    {
        public readonly ApplicationDbContext db;
        public ShipmentInfoRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<ShipmentInfo> Create(ShipmentInfo entity)
        {
            var obj = await db.shipmentInfos.AddAsync(entity);
            db.SaveChanges();
            return obj.Entity;
        }

        public void Delete(ShipmentInfo entity)
        {
            db.Remove(entity);
            db.SaveChanges();
        }

        public IEnumerable<ShipmentInfo> GetAll()
        {
            try
            {
                return db.shipmentInfos.ToList();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public ShipmentInfo GetById(string Id)
        {
            return db.shipmentInfos.Where(x => x.ShipmentId == Id).SingleOrDefault();
        }

        public void Update(ShipmentInfo entity)
        {
            db.shipmentInfos.Update(entity);
            db.SaveChanges();
        }
    }
}
