using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class EmployeeController : ApiController
    {
        // GET api/values
        public List<Employee> Get()
        {

            return new List<Employee> {
                new Employee() {EmployeeName = "Enrique Romero", CompanyName = "Innovar", dateOfBirth = new DateTime(1991, 07, 29), ID = Guid.NewGuid(), InternalEmployeeID = 0, phoneNumber = "653342432123"},
                new Employee() {EmployeeName = "Pablo Peralta", CompanyName = "Tech Marathons", dateOfBirth = new DateTime(1980, 08, 29), ID = Guid.NewGuid(), InternalEmployeeID = 1, phoneNumber = "1152"},
                new Employee() {EmployeeName = "Mariana Techeira", CompanyName = "Tech Marathons", dateOfBirth = new DateTime(1985, 09, 07), ID = Guid.NewGuid(), InternalEmployeeID = 2, phoneNumber = "144545"},
                new Employee() {EmployeeName = "Tony Stark", CompanyName = "Stark Industries", dateOfBirth = new DateTime(1970, 01, 20), ID = Guid.NewGuid(), InternalEmployeeID = 3, phoneNumber = "+554566"},
                new Employee() {EmployeeName = "Marilyn Manson", CompanyName = "Metal", dateOfBirth = new DateTime(1969, 10, 19), ID = Guid.NewGuid(), InternalEmployeeID = 4, phoneNumber = "54645"},
                new Employee() {EmployeeName = "Jack Sparrow", CompanyName = "Black Pearl", dateOfBirth = new DateTime(1920, 05, 9), ID = Guid.NewGuid(), InternalEmployeeID = 5, phoneNumber = "65465"},
            }; ;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

      
    }
}
