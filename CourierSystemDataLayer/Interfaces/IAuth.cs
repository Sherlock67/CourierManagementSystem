using CourierSystemDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierSystemDataLayer.Interfaces
{
    public interface IAuth<T>
    {
        Task<T> RegisterUser(T user, string password);
        Task<T> Login(string username, string password);
        Task<bool> UserExist(string username);
    }
}
