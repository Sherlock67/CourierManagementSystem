using CourierSystemDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierSystemDataLayer.Interfaces
{
    public interface IAdmin : IRepository<AdminClass>
    {
        Task<AdminClass> GetAdminByUserName(string username);
    }
}
