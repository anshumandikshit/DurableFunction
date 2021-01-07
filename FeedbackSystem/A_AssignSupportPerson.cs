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

namespace FeedbackSystem
{
    public static class A_AssignSupportPerson
    {
        [FunctionName("A_AssignSupportPerson")]
        public static async Task<IActionResult> Run(
             [ActivityTrigger] int feedbackID,
            ILogger log)
        {
           

            return new OkObjectResult("This will be returned");
        }
    }
}
