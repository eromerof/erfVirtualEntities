using System;
using System.Collections.Generic;
using System.Net.Http;
using DataProvider;
using DataProvider.Models;
using erf.DataProvider;
using FakeXrmEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Newtonsoft.Json;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private XrmFakedContext context { get; set; }
        private IOrganizationService service { get; set; }
        [TestInitialize]
        public void InitializeTest()
        {
             context = new XrmFakedContext();
             service = context.GetOrganizationService();
        }
        [TestMethod]
        public void testQueryVisitor()
        {
            // Define Condition Values
            var QEcontact_firstname = "Enrique";

            // Instantiate QueryExpression QEcontact
            var QEcontact = new QueryExpression("contact");
            QEcontact.TopCount = 50;

            // Add all columns to QEcontact.ColumnSet
            QEcontact.ColumnSet.AllColumns = true;

            // Define filter QEcontact.Criteria
            QEcontact.Criteria.AddCondition("firstname", ConditionOperator.Equal, QEcontact_firstname);

            QueryVisitor qe = new QueryVisitor();
            qe.Visit(QEcontact);


        }
        [TestMethod]
        public void TestService()
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync($"https://friends-quotes-api.herokuapp.com/quotes").GetAwaiter().GetResult();
            var result = response.Content.ReadAsStringAsync().Result;

        }

        [TestMethod]
        public void RetrieveMultipleTest()
        {
            QueryExpression Query = new QueryExpression("erf_friendquote");
            Query.ColumnSet.AddColumn("erf_friendquoteid");
            Query.ColumnSet.AddColumn("erf_friend");
            FilterExpression filter = new FilterExpression(LogicalOperator.And);
            filter.AddCondition(new ConditionExpression("erf_friend", ConditionOperator.Equal, "Ross"));
            Query.Criteria.AddFilter(filter);

            ParameterCollection parameters = new ParameterCollection();
            parameters.Add(new KeyValuePair<string, object>("query", Query));
            XrmFakedPluginExecutionContext ctx = new XrmFakedPluginExecutionContext();
            ctx.InputParameters = parameters;

            context.ExecutePluginWith<RetrieveMultiple>(ctx);
        }
    }
}
