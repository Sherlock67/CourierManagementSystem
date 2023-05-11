﻿using CourierSystemDataLayer.Interfaces;
using CourierSystemDataLayer.Model;
using CourierSystemDataLayer.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierSystemBusinessLayer.Services
{
    public class CustomerService
    {

        private readonly ICustomer customer;
      
        public CustomerService(ICustomer customer)
        {
            this.customer = customer;
           
        }
        public async Task<Customer> RegisterCustomer(Customer c)
        {
            return await customer.Create(c);
        }
        public async Task<bool> VerifyUserAsync(Login login)
        {
            var obj = await customer.GetCustomerByEmailId(login.EmailId);
            if (obj != null)
            {
                if (obj.CustomerPassword == login.Password)
                {
                    return true;

                }
            }
            return false;

        }
       
    }
}
