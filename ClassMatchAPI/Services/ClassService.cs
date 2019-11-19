using ClassMatchAPI.Interfaces;
using ClassMatchAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassMatchAPI.Services
{
    public class ClassService : IClassService
    {
        private readonly ClassMatchContext _dbContext;

        public ClassService(ClassMatchContext dbContext)
        {
            _dbContext = dbContext;
        }


        public object GetUserCourses(string email)
        {
            var a = from uc in _dbContext.UserCourse
                    join c in _dbContext.Course on uc.CourseId equals c.CourseId
                    where uc.UserEmail == email
                    select new { courseId = uc.CourseId, userEmail = uc.UserEmail, period = uc.Period, term = uc.Term, courseName = c.CourseName, teacher = uc.Teacher };
            //var a = _dbContext.Course.SelectMany(c => _dbContext.UserCourse.Where(uc => c.CourseId == uc.CourseId && uc.UserEmail == email).DefaultIfEmpty(), (c, uc) => new { courses = c, usercourse = uc });
            return a;
        }

        public object GetClasses()
        {
            return _dbContext.Course;
        }

        public void AddUserCourse(string courseId, string userEmail, int boxId, string teacherName)
        {
            int period = boxId <= 4 ? boxId : boxId - 4;
            string term = boxId >= 5 ? "S" : "F";
            var match = _dbContext.UserCourse.Where(x => x.UserEmail == userEmail && x.Period == period && x.Term == term).FirstOrDefault();

            if (match == null)
            {
                UserCourse uc = new UserCourse();
                uc.CourseId = courseId;
                uc.UserEmail = userEmail;

                uc.Term = term;
                uc.Period = period;
                uc.Teacher = teacherName;

                _dbContext.UserCourse.Add(uc);
                _dbContext.SaveChanges();
            }
            else
            {
                match.CourseId = courseId;
                match.Teacher = teacherName;
                _dbContext.SaveChanges();

            }
        }

        public object GetCourseUsers(string courseId, int period, string teacherName, string term)
        {
            var a = from uc in _dbContext.UserCourse
                    join u in _dbContext.User on uc.UserEmail equals u.Email
                    where uc.CourseId == courseId && uc.Period == period && uc.Teacher == teacherName && uc.Term == term
                    select new { firstName = u.FirstName, lastName = u.LastName };

            return a;

        }

        public object GetAllTeachers()
        {
            return _dbContext.Teacher;
        }
    }
}
