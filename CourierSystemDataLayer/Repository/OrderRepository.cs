using CourierSystemDataLayer.Data;
using CourierSystemDataLayer.Interfaces;
using CourierSystemDataLayer.Model;
using CourierSystemDataLayer.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;

namespace CourierSystemDataLayer.Repository
{
    public class OrderRepository : IOrder
    {
        private readonly ApplicationDbContext db;
        public OrderRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<OrderViewModel> CreateOrder(OrderViewModel order)
        {
            Order o = new Order()
            {

                OrderId = Guid.NewGuid().ToString(),
                ProductName = order.ProductName,
                CurrentPlace = order.CurrentPlace,
                OrderPlacingDate = DateTime.Now,
                FinalDateToReachDestination = DateTime.Now.AddDays(3),
                ConsignmentNumber = new Random().Next(1, 1000000),
                OrderStatus = false,
            };
            Recipant recipant = new Recipant()
            {
                RecipantId = Guid.NewGuid().ToString(),
                RecipantName = order.RecipantName,
                Address = order.Address,
                MobileNumber = order.MobileNumber
            };
            db.orders.Add(o);
            db.recipants.Add(recipant);
            db.SaveChanges();
            return order;
            
        }

        //public IEnumerable<Order> SearchByConsignmentNumber(string consignmentNumber)
        //{
        //    IQueryable<Order> query = db.orders;

        //    if (!string.IsNullOrEmpty(consignmentNumber))
        //    {
        //        query = query.Where(e => e.ConsignmentNumber == consignmentNumber);
        //    }
        //    return query.ToList();
        //}


        //public Task SearchByConsignmentNumber(string consignmentNumber)
        //{
        //    OrderViewModel orderViewModel = new OrderViewModel();

        //}
    }
}
