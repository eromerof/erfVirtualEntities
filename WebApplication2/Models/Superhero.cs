using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Employee
    {
        public Guid ID { get; set; }

        public string CompanyName { get; set; }

        public string EmployeeName { get; set; }

        public DateTime dateOfBirth { get; set; }

        public string phoneNumber { get; set; }

        public int InternalEmployeeID { get; set; }

    }
}