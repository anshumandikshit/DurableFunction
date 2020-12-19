using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.Http;
using System.Threading.Tasks;
using FeedbackSystem.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using FeedbackSystem.Models;

namespace FeedbackSystem
{
    public static class A_SaveFeedback
    {
        [FunctionName("A_SaveFeedback")]
        public static async Task<long> SendFeedbckIdToUser(
            [ActivityTrigger] MessageFeedbackForm feedbackMsg,
            ILogger log)
        {
            var sqlConnectionString = Environment.GetEnvironmentVariable("SqlConnectionString");
            long feedbackId = 0;
            if (feedbackMsg != null)
            {
                
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    conn.Open();
                    var sqlQuery = $"INSERT INTO [DBO].[FEEDBACKFORM] (FirstName,LastName,EmailAddress,FeedbackMessage) OUTPUT INSERTED.ID VALUES ('{feedbackMsg.FirstName}','{feedbackMsg.LastName}','{feedbackMsg.EmailAddress}','{feedbackMsg.FeedbackMessage}') ";
                    using(SqlCommand comm = new SqlCommand(sqlQuery, conn))
                    {
                         feedbackId = (Int64)await comm.ExecuteScalarAsync();
                        log.LogInformation($"feedbackId-{feedbackId} got inserted to table");
                        return feedbackId;
                    }
                }
            }

            return feedbackId;

        }


        
    }
}