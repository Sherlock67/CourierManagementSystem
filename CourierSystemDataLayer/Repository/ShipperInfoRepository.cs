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
    public class ShipperInfoRepository : IShipperInfo
    {
        public readonly ApplicationDbContext db;
        public ShipperInfoRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<ShipperInfo> Create(ShipperInfo entity)
        {
            var obj = await db.shippers.AddAsync(entity);
            db.SaveChanges();
            return obj.Entity;
        }

        public void Delete(ShipperInfo entity)
        {
            db.Remove(entity);
            db.SaveChanges();
        }

        public IEnumerable<ShipperInfo> GetAll()
        {
            try
            {
                return db.shippers.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ShipperInfo GetById(string Id)
        {
            return db.shippers.Where(x => x.ShipperId == Id).SingleOrDefault();
        }

        public void Update(ShipperInfo entity)
        {
            db.shippers.Update(entity);
            db.SaveChanges();
        }
    }
}
