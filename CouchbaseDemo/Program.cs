// See https://aka.ms/new-console-template for more information
using System.Threading.Tasks;
using Couchbase;
using CouchbaseDemo.Examples;

var cluster = await Cluster.ConnectAsync("couchbase://192.168.0.151", "Administrator", "password");

var queryingExamples =  new QueryingExamples(cluster);
await queryingExamples.FetchUsingKey("0");

await queryingExamples.FetchListUsingQuery();

var mutationExamples =  new MutationExamples(cluster);

await mutationExamples.InsertUser();

// await mutationExamples.CreateSearchIndex();



// await queryingExamples.Search("swanky");