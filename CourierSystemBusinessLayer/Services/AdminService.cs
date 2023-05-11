using CourierSystemDataLayer.Interfaces;
using CourierSystemDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierSystemBusinessLayer.Services
{
    public class AdminService
    {
        private readonly IAdmin admin;

        public AdminService(IAdmin admin)
        {
            this.admin = admin;

        }
        public async Task<bool> VerifyAdmin(AdminLogin login)
        {
            var obj = await admin.GetAdminByUserName(login.Username);
            if (obj != null)
            {
                if (obj.Password == login.Password)
                {
                    return true;

                }
            }
            return false;

        }
    }
}
