using CourierSystemDataLayer.Interfaces;
using CourierSystemDataLayer.Model;
using CourierSystemDataLayer.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierSystemBusinessLayer.Services
{
    public class AuthAdminService
    {
        public readonly IAdminAuth adminAuth;

        public AuthAdminService(IAdminAuth adminAuth)
        {
              this.adminAuth = adminAuth;
        }

        
        public async Task<AdminClass> LoginAdmin(string username,string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException("Please insert your username");

            }
            else
            {
              return await adminAuth.Login(username,password);
            }
        }
    }
}
