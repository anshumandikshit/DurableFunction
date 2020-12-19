using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Host;
using FeedbackSystem.Models;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Core;

namespace FeedbackSystem
{
    public static class StarterFunction
    {
        [FunctionName("StarterFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [DurableClient] IDurableClient starter,
            ILogger log)
        {
            string responseMessage = String.Empty;
            string orchestratorId = String.Empty;
            log.LogInformation("Starter function get triggered");

            //Parse the Http request and get the feedbak message 

            var messageBody = await new StreamReader(req.Body).ReadToEndAsync();
            MessageFeedbackForm message = JsonConvert.DeserializeObject<MessageFeedbackForm>(messageBody);

            if (message != null)
            {
                //Call the Orchestrator function 
                orchestratorId = await starter.StartNewAsync<MessageFeedbackForm>("FeedbackOrchestrator", message);
                log.LogInformation($"Orchastrator function started with Id-{orchestratorId}");

            } 

            return (!string.IsNullOrEmpty(orchestratorId)) ? new OkObjectResult($"Orchastrator function stated with Id-{orchestratorId}") : new OkObjectResult($"Orchastrator function could not start");
        }
    }
}
