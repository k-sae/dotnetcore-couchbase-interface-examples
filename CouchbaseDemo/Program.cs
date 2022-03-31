// See https://aka.ms/new-console-template for more information
// using System.Threading.Tasks;
// using Couchbase;
// using CouchbaseDemo.Examples;

// await mutationExamples.CreateSearchIndex();



// await queryingExamples.Search("swanky");


using System;
using System.Threading.Tasks;
using Couchbase;
using CouchbaseDemo.Examples;

namespace CouchbaseDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
           
            var cluster = await Cluster.ConnectAsync("couchbase://localhost", "Administrator", "password");

            var queryingExamples =  new QueryingExamples(cluster);
            await queryingExamples.FetchUsingKey("0");

            await queryingExamples.FetchListUsingQuery();

            var mutationExamples =  new MutationExamples(cluster);

            await mutationExamples.InsertUser();

        }
    }
}
