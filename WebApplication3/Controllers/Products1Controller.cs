using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using System.Web.Http.OData.Routing;
using ODataService.Models;
using Microsoft.Data.OData;

namespace WebApplication3.Controllers
{
    /*
    Puede que la clase WebApiConfig requiera cambios adicionales para agregar una ruta para este controlador. Combine estas instrucciones en el método Register de la clase WebApiConfig según corresponda. Tenga en cuenta que las direcciones URL de OData distinguen mayúsculas de minúsculas.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using ODataService.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Product>("Products1");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class Products1Controller : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();

        private List<Product> products = new List<Product>()
        {
            new Product()
            {
                ID = 1,
                Name = "Bread",
            }
        };
        // GET: odata/Products1
        public IHttpActionResult GetProducts1(ODataQueryOptions<Product> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

             return Ok<IEnumerable<Product>>(products);
            //return StatusCode(HttpStatusCode.NotImplemented);
        }

        // GET: odata/Products1(5)
        public IHttpActionResult GetProduct([FromODataUri] int key, ODataQueryOptions<Product> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            // return Ok<Product>(product);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PUT: odata/Products1(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Product> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Put(product);

            // TODO: Save the patched entity.

            // return Updated(product);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // POST: odata/Products1
        public IHttpActionResult Post(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Add create logic here.

            // return Created(product);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PATCH: odata/Products1(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Product> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Patch(product);

            // TODO: Save the patched entity.

            // return Updated(product);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // DELETE: odata/Products1(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            // TODO: Add delete logic here.

            // return StatusCode(HttpStatusCode.NoContent);
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}
