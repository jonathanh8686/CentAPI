using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassMatchAPI.Models;

namespace ClassMatchAPI.Interfaces
{
    public interface IClassService
    {
        Object GetClasses();

        Object GetUserCourses(string email);

        void AddUserCourse(string courseId, string userEmail, int boxId, string teacherName);

        Object GetCourseUsers(string courseId, int period, string teacherName, string term);

        Object GetAllTeachers();

    }
}
