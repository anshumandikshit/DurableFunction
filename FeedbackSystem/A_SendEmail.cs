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
using AzureCommonHelper;
using System.Collections.Generic;
using System.Linq;

namespace FeedbackSystem
{
    public static class A_SendEmail
    {
        [FunctionName("A_SendEmail")]
        public static async Task<bool> SendEmailToUser(
            [ActivityTrigger] int feedbackID,
            ILogger log)
        {
            log.LogInformation("C# Activity function for SendEmail got invoked");

            var toemailString = Environment.GetEnvironmentVariable("ToEmailAddress");
            var toEmailIds = toemailString.Split(",").ToList();
            var emailSubject = "Feedback mail";
            var emailTextplaiinBody = $"Thank you for your Feedback .for your reference please contact support team with given feedbackId :  {feedbackID}";
            var emailSent =await EmailHelper.SendEmail(toEmailIds, null, emailSubject, emailTextplaiinBody);

            return emailSent;
            
        }
    }
}
