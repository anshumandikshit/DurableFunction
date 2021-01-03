using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AzureCommonHelper
{
    public static class EmailHelper
    {

        public static async Task<bool> SendEmail(List<string> toEmailAddress,
            string fromEmailAddress = null,
            string emailSubject = null,
            string emailPlainTextBody=null,
            string emailHTMLBody = null,
            bool displayRecipients = false)
        {
            var apiKey = Environment.GetEnvironmentVariable("SendGridAPIKey");
            var fromAddress = fromEmailAddress ?? Environment.GetEnvironmentVariable("EmailFromAddress");


            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(fromAddress);
            List<EmailAddress> toAddress = new List<EmailAddress>();
            toEmailAddress.ForEach(address => toAddress.Add(new EmailAddress(address, address)));

            // create you owen custom code for Parsing the HTML and send an Email
            var subject = emailSubject;
            var htmlContent = emailHTMLBody;
            var textContent = emailPlainTextBody;
            // set this to true if you want recipients to see each others mail id 
            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, toAddress, subject, textContent, htmlContent, displayRecipients);
            var response = await client.SendEmailAsync(msg);

            return response.IsSuccessStatusCode;
        }
    }
}
