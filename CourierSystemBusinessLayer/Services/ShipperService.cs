using CourierSystemDataLayer.Interfaces;
using CourierSystemDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierSystemBusinessLayer.Services
{
    public class ShipperService
    {
        public readonly IShipperInfo shipper;
        public ShipperService(IShipperInfo shipper)
        {
            this.shipper = shipper;
        }
        public async Task<ShipperInfo> AddNewShipperInfo(ShipperInfo info)
        {
            return await shipper.Create(info);
        }
        public IEnumerable<ShipperInfo> GetAllShipperInfo()
        {
            try
            {
                return shipper.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ShipperInfo GetShipperById(string id)
        {
            return shipper.GetById(id);
        }
        public async Task UpdateShipperInfo(ShipperInfo obj)
        {
            try
            {

                shipper.Update(obj);


            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task DeleteShipperInfo(string id)
        {

            try
            {
                var DataList = shipper.GetById(id);
                shipper.Delete(DataList);

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
