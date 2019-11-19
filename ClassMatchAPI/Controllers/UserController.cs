using ClassMatchAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassMatchAPI.Controllers
{
    public class UserObject
    {
        public string firstName;
        public string lastName;
        public string email;
    }

    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        [ActionName("Get")]
        public object GetUsers()
        {
            return _service.GetUsers();
        }

        [HttpGet("{email}")]
        [ActionName("CheckUser")]
        public bool CheckUser(string email)
        {
            return _service.CheckUser(email);
        }

        // POST api/<controller>
        [HttpPost]
        [ActionName("AddUser")]
        public void AddUser([FromBody] UserObject uo)
        {
            _service.AddUser(uo.firstName, uo.lastName, uo.email);
        }

    }
}

