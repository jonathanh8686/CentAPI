using ClassMatchAPI.Interfaces;
using ClassMatchAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassMatchAPI.Services
{
    public class UserService : IUserService
    {
        private readonly ClassMatchContext _dbContext;

        public UserService(ClassMatchContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddUser(string firstName, string lastName, string email)
        {
            User user = new User();
            user.Email = email;
            user.FirstName = firstName;
            user.LastName = lastName;
            user.Password = "temp";

            _dbContext.User.Add(user);
            _dbContext.SaveChanges();
        }

        public object GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public bool CheckUser(string email)
        {
            return _dbContext.User.Where(x => x.Email == email).Any();
        }

        public object GetUsers()
        {
            return _dbContext.User;
        }
    }
}
