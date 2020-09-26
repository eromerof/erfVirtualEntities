using DataProvider;
using DataProvider.Models;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace erf.DataProvider
{
    public class RetrieveMultiple : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            var context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);
            ITracingService tracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
            QueryExpression InputQe;
            if (context.InputParameters.Contains("Query") && context.InputParameters["Query"] is QueryExpression)
                InputQe = (QueryExpression)context.InputParameters["Query"];
            else
                return;

            BusinessFunctions Actions = new BusinessFunctions();

            context.OutputParameters["BusinessEntityCollection"] = Actions.getFriendsAndQuotes(InputQe);

        }
 
    }


}
