﻿using System;
using System.Collections.Generic;

namespace ClassMatchAPI.Models
{
    public partial class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
