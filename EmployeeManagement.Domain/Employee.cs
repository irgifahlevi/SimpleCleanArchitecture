﻿using EmployeeManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Domain
{
    public class Employee : BaseModel
    {
        public int EmployeNumber { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int PhoneNumber{ get; set; }
        public string Country { get; set; }
    }
}