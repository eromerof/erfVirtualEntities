using System;

namespace ProductService.Models
{
    public class Employees
    {
        public Guid ID { get; set; }

        public string CompanyName { get; set; }

        public string EmployeeName { get; set; }

        public DateTime dateOfBirth { get; set; }

        public string phoneNumber { get; set; }

        public int InternalEmployeeID { get; set; }
    }
}