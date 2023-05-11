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
    public class AdminRepository : IAdmin
    {
        private readonly ApplicationDbContext db;
        public AdminRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public Task<AdminClass> Create(AdminClass entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(AdminClass entity)
        {
            throw new NotImplementedException();
        }

        public async Task<AdminClass> GetAdminByUserName(string username)
        {
            var obj = await db.admins.SingleOrDefaultAsync(x => x.Username == username);
            return obj;
        }

        public IEnumerable<AdminClass> GetAll()
        {
            throw new NotImplementedException();
        }

        public AdminClass GetById(string Id)
        {
            throw new NotImplementedException();
        }

        public void Update(AdminClass entity)
        {
            throw new NotImplementedException();
        }
    }
}
