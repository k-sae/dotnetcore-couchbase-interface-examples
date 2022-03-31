using System;
using System.Threading.Tasks;
using Couchbase;
using Couchbase.Search.Queries.Simple;
using CouchbaseDemo.Models;

namespace CouchbaseDemo.Examples
{

    public class QueryingExamples
    {
        private readonly ICluster _cluster;

        public QueryingExamples(ICluster cluster)
        {
            this._cluster = cluster;
        }


        public async Task FetchUsingKey(string key)
        {
            var bucket = await _cluster.BucketAsync("travel-sample");
            Console.WriteLine("loaded bucket");
            // get a user-defined collection reference
            var scope = await bucket.ScopeAsync("tenant_agent_00");
            Console.WriteLine("loaded scope");
            var collection = await scope.CollectionAsync("users");
            Console.WriteLine("loaded collection");
            var getResult = await collection.GetAsync(key);
            var user = getResult.ContentAs<User>();
            Console.WriteLine("User fetched with Name: " + user?.name);
        }


        public async Task Search(string keyword)
        {
            // TODO need to create full text search index first
            var result = await _cluster.SearchQueryAsync(
                "travel-sample-index-hotel-description",
                new MatchQuery(keyword),
                options => { options.Limit(10); }
            );
        }


        public async Task FetchListUsingQuery()
        {
            const string query = "SELECT t.* FROM `travel-sample` t WHERE t.type=$type";

            Console.WriteLine("Performing the query: " + query);
            var result = await _cluster.QueryAsync<Travel>(
                query,
                options => options.Parameter("type", "landmark")
            );

            // iterate over rows
            var resultCount = 0;
            await foreach (var travel in result)
            {
                // Console.WriteLine($"{travel.name},{travel.address}");
                resultCount++;
            }

            Console.WriteLine("Fetched: " + resultCount);
        }
    }
}