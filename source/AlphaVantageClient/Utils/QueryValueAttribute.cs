using System;

namespace AlphaVantageClient.Utils
{
    [System.AttributeUsage(System.AttributeTargets.Field)]
    internal class QueryValueAttribute : Attribute
    {
        public string QueryValue { get; set; }

        public QueryValueAttribute(string queryValue)
        {
            QueryValue = queryValue;
        }
        public static implicit operator string(QueryValueAttribute q) => q.QueryValue;
        public override string ToString() => QueryValue;
    }
}