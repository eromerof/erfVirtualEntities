using Microsoft.AspNet.OData;
using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ODataService.Controllers
{
    public class EmployeesController : ODataController
    {
        private List<Employees> Employees = new List<Employees> {
                new Employees() {EmployeeName = "Enrique Romero", CompanyName = "Innovar", dateOfBirth = new DateTime(1991, 07, 29), ID = new Guid("0b172690-14c4-43c1-8706-730c61e2122e"), InternalEmployeeID = 0, phoneNumber = "653342432123"},
                new Employees() {EmployeeName = "Pablo Peralta", CompanyName = "Tech Marathons", dateOfBirth = new DateTime(1980, 08, 29), ID = new Guid("cac96041-fb9f-44fb-be9b-24de13a03bda"), InternalEmployeeID = 1, phoneNumber = "1152"},
                new Employees() {EmployeeName = "Mariana Techeira", CompanyName = "Tech Marathons", dateOfBirth = new DateTime(1985, 09, 07), ID = new Guid("e17bdacf-d574-4c1d-bd42-381899d20cdd"), InternalEmployeeID = 2, phoneNumber = "144545"},
                new Employees() {EmployeeName = "Tony Stark", CompanyName = "Stark Industries", dateOfBirth = new DateTime(1970, 01, 20), ID = new Guid("46ec191d-1395-4844-aa8c-c332ee8a27ce"), InternalEmployeeID = 3, phoneNumber = "+554566"},
                new Employees() {EmployeeName = "Marilyn Manson", CompanyName = "Metal", dateOfBirth = new DateTime(1969, 10, 19), ID = new Guid("0fcf11cb-47b9-429e-89df-01d839681af9"), InternalEmployeeID = 4, phoneNumber = "54645"},
                new Employees() {EmployeeName = "Jack Sparrow", CompanyName = "Black Pearl", dateOfBirth = new DateTime(1920, 05, 9), ID = new Guid("c0483bca-7180-4876-982d-168c9a6e9df5"), InternalEmployeeID = 5, phoneNumber = "65465"},
        };

        public List<Employees> Get()
        {
            return Employees;
        }
    }
}