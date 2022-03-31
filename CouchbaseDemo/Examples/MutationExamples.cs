using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Couchbase;
using Couchbase.Core.Exceptions.KeyValue;
using CouchbaseDemo.Models;

namespace CouchbaseDemo.Examples
{

    public class MutationExamples
    {
        private readonly ICluster _cluster;

        public MutationExamples(ICluster cluster)
        {
            this._cluster = cluster;
        }

        public async Task InsertUser()
        {
            var bucket = await _cluster.BucketAsync("travel-sample");
            // get a user-defined collection reference
            var scope = await bucket.ScopeAsync("tenant_agent_00");
            var collection = await scope.CollectionAsync("users");

            Console.WriteLine("Creating a new User");
            var user = new User()
            {
                name = "new User Name",
                addresses = new List<Address>()
                {
                    new Address() {address = "test address", country = "Egypt"}
                }
            };
            try
            {
                var result = await collection.InsertAsync("40", user);
                // can use upsert to update or insert and update for update also
                Console.WriteLine("Created a new User");
            }
            catch (DocumentExistsException)
            {
                Console.WriteLine("Document already exists");
            }
        }

        public async Task createSearchIndex()
        {

        }
    }
}