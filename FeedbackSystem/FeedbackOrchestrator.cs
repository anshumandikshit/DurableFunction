using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FeedbackSystem.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;


namespace FeedbackSystem
{
    public static class FeedbackOrchestrator
    {
        [FunctionName("FeedbackOrchestrator")]
        public static async Task<long> RunOrchestrator(
            [OrchestrationTrigger] IDurableOrchestrationContext context,
            ILogger log)
        {
            var feedbackMsg = context.GetInput<MessageFeedbackForm>();
            long feedbackId = 0;
            try
            {

                if (feedbackMsg != null)
                {
                   // log.LogInformation(feedbackMsg.ToString());

                    //Store the data in sqlserver and return ID 
                    feedbackId = await context.CallActivityAsync<Int64>("A_SaveFeedback", feedbackMsg);

                    if (feedbackId > 0)
                    {
                        //send email to the feedbacksender 
                    }


                    //Call the EmailSendToUser Funcion (Activity functions) ;
                }

            }
            catch (Exception ex)
            {
                Exception actualException = ex;
                while (actualException.InnerException != null)
                {
                    actualException = actualException.InnerException;

                }
                log.LogError(actualException.ToString());
            }

            return feedbackId;

        }



    }
}