using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ClassMatchAPI.Models;
using ClassMatchAPI.Interfaces;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClassMatchAPI.Controllers
{
    public class UserCoursePostObject
    {
        public string courseId;
        public string userEmail;
        public int boxId;
        public string teacherName;
    }

    [Route("api/[controller]/[action]")]
    public class ClassController : Controller
    {
        IClassService _service;
        public ClassController(IClassService service)
        {
            _service = service;
        }


        // GET api/<controller>/5
        [HttpGet("{email}")]
        [ActionName("GetUserCourses")]
        public Object GetUserCourses(string email)
        {
            return _service.GetUserCourses(email);
        }

        [HttpGet]
        [ActionName("GetAll")]
        public Object GetAll()
        {
            return _service.GetClasses();
        }

        [HttpGet]
        [ActionName("GetAllTeachers")]
        public Object GetAllTeachers()
        {
            return _service.GetAllTeachers();
        }

        [HttpPost]
        [ActionName("AddUserCourse")]
        public void AddUserCourse([FromBody] UserCoursePostObject uco)
        {
            _service.AddUserCourse(uco.courseId, uco.userEmail, uco.boxId, uco.teacherName);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {

        }

        [HttpGet("{courseId}/{period}/{teacherName}/{term}")]
        [ActionName("GetCourseUsers")]
        [Authorize]
        public object GetCourseUsers(string courseId, int period, string teacherName, string term)
        {
            return _service.GetCourseUsers(courseId.Replace("`", "/"), period, teacherName, term);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
