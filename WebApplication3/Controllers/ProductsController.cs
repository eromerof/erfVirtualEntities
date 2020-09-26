using ODataService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.OData;

namespace ODataService.Controllers
{
    [EnableQuery]
    public class ProductsController : ODataController
    {
        private List<Product> products = new List<Product>()
        {
            new Product()
            {
                ID = 1,
                Name = "Bread",
            }
        };
        public IHttpActionResult Get()
        {
            return Ok(products.AsQueryable());
        }





    }
}