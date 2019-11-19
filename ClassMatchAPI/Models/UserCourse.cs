using System;
using System.Collections.Generic;

namespace ClassMatchAPI.Models
{
    public partial class UserCourse
    {
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public string CourseId { get; set; }
        public int Period { get; set; }
        public string Term { get; set; }
        public string Teacher { get; set; }
    }
}
