using CourierSystemDataLayer.Interfaces;
using CourierSystemDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierSystemBusinessLayer.Services
{
  
    public class ShipmentInfoService
    {
        public readonly IShipmentInfo shipmentInfo;
        public ShipmentInfoService(IShipmentInfo shipmentInfo)
        {
            this.shipmentInfo = shipmentInfo;
        }
        public async Task<ShipmentInfo> AddNewShipmentInfo(ShipmentInfo info)
        {
            return await shipmentInfo.Create(info);
        }
        public IEnumerable<ShipmentInfo> GetAllShipmentInfo()
        {
            try
            {
                return shipmentInfo.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ShipmentInfo GetShipmentInfoById(string id)
        {
            return shipmentInfo.GetById(id);
        }
        public async Task UpdatePrescription(ShipmentInfo obj)
        {
            try
            {

                shipmentInfo.Update(obj);


            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task DeletePrescription(string id)
        {

            try
            {
                var DataList = shipmentInfo.GetById(id);
                shipmentInfo.Delete(DataList);

            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
