using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider
{
    public class QueryVisitor : QueryExpressionVisitorBase
    {
        public Dictionary<string, string> SearchKeyWords { get; set; }
        public QueryVisitor()
        {
            SearchKeyWords = new Dictionary<string, string>();
        }
        public override QueryExpression Visit(QueryExpression query)
        {
            // Very simple visitor that extracts search keywords
            var filter = query.Criteria;
            if (filter.Conditions.Count > 0)
            {
                foreach (ConditionExpression condition in filter.Conditions)
                {
                    if (condition.Values.Count > 0)
                    {
                        string FieldName = condition.AttributeName;
                        string exprVal = (string)condition.Values[0];
                        if (condition.Operator != ConditionOperator.Equal)
                            throw new InvalidPluginExecutionException($"Operador {condition.Operator.ToString()} no soportado");
                        if (exprVal.Length > 0)
                        {
                            //this.SearchKeyWords += " " + exprVal.Substring(1, exprVal.Length - 2);
                            if (!SearchKeyWords.ContainsKey(FieldName))
                                SearchKeyWords.Add(FieldName, exprVal);
                        }
                    }
                }
                return query;
            }
            return base.Visit(query);
        }


    }
}
