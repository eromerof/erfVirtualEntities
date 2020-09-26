using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erf.DataProvider
{
    public class Retrieve : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            var context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);
            ITracingService tracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));


            Entity returnEntity = new Entity(context.PrimaryEntityName, context.PrimaryEntityId);

            BusinessFunctions Actions = new BusinessFunctions();
            var returnEntities = Actions.getFriendsAndQuotes(new QueryExpression());
            returnEntity = returnEntities.Entities.Where(o => o.Id == context.PrimaryEntityId).FirstOrDefault();

            // Set output parameter
            context.OutputParameters["BusinessEntity"] = returnEntity;
        }
    }
}
