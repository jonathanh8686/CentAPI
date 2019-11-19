using System;
using System.Collections.Generic;

namespace ClassMatchAPI.Models
{
    public partial class Course
    {
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public bool Spring { get; set; }
        public bool Fall { get; set; }
    }
}
