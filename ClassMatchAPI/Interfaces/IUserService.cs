using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassMatchAPI.Interfaces
{
    public interface IUserService
    {
        Object GetUsers();

        Object GetUser(int id);

        void AddUser(string firstName, string lastName, string email);

        bool CheckUser(string email);

        
    }
}
