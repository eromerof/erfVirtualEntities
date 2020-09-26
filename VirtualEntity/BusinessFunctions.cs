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
    public class BusinessFunctions
    {
        public EntityCollection getFriendsAndQuotes(QueryExpression inputQE)
        {
            QueryVisitor qeParams = new QueryVisitor();
            qeParams.Visit(inputQE);
            var Parameters = qeParams.SearchKeyWords;

            var WebServiceResponse = CallToWebService();
            var ListFriendQuote = JsonConvert.DeserializeObject<List<FriendQuote>>(WebServiceResponse);
            List<FriendQuote> FilterFriendQuotes = default;
            if (Parameters.Count > 0)
                FilterFriendQuotes = ListFriendQuote.Where(x => x.Character == Parameters.First().Value).ToList();
            else
                FilterFriendQuotes = ListFriendQuote;

            EntityCollection returnEntities = new EntityCollection();
            foreach (var item in FilterFriendQuotes)
            {
                returnEntities.Entities.Add(new Entity("erf_friendquote", CachedGuids.IDs[ListFriendQuote.FindIndex(x => x.Character == item.Character)])
                {
                    Attributes = new AttributeCollection()
                    {
                        new KeyValuePair<string, object>("erf_friend", item.Character),
                        new KeyValuePair<string, object>("erf_quote", item.Quote)
                    }
                });
            }
            return returnEntities;
        }
        private string CallToWebService()
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync($"https://friends-quotes-api.herokuapp.com/quotes").GetAwaiter().GetResult();
            var result = response.Content.ReadAsStringAsync().Result;
            return result;
        }
    }
}
