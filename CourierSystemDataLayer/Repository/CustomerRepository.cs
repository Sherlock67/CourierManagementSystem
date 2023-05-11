using CourierSystemDataLayer.Data;
using CourierSystemDataLayer.Interfaces;
using CourierSystemDataLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierSystemDataLayer.Repository
{
    public class CustomerRepository : ICustomer
    {
        private readonly ApplicationDbContext db;
        public CustomerRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<Customer> Create(Customer entity)
        {
            var obj = await db.customers.AddAsync(entity);
            db.SaveChanges();
            return obj.Entity;
        }

        public void Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        
        public Customer GetById(string Id)
        {
            var obj = db.customers.SingleOrDefault(x => x.CustomerId == Id);
            return obj;
        }
        public async Task<Customer> GetCustomerByEmailId(string EmailId)
        {
            var obj = await db.customers.SingleOrDefaultAsync(x => x.CustomerEmail == EmailId);
            return obj;
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
