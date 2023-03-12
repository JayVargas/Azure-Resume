using System.Net.Http;

using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Text;
using Newtonsoft.Json;

namespace Company.Function
{
    public static class HttpTrigger1
    {
        
        [FunctionName("HttpTrigger1")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [CosmosDB(databaseName:"AzureResume", collectionName: "Counter", ConnectionStringSetting = "AzureresumeConnectionString", Id = "1", PartitionKey = "1")] Counter Counter,
            [CosmosDB(databaseName:"AzureResume", collectionName: "Counter", ConnectionStringSetting = "AzureresumeConnectionString", Id = "1", PartitionKey = "1")] out Counter updatedCounter,
            ILogger log)
        {
           // Here is where the counter gets updated.
           log.LogInformation("C# HTTP trigger function processed a request.");

            updatedCounter = Counter; 

            updatedCounter.Count += 1;

            var jsonToReturn = JsonConvert.SerializeObject(Counter);
            return new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent(jsonToReturn, Encoding.UTF8, "application/json")
            };
        }
    }
}
