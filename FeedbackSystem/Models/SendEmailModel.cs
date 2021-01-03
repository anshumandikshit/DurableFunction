using System;
using System.Collections.Generic;
using System.Text;

namespace FeedbackSystem.Models
{
    public class SendEmailModel
    {
        public List<string> ToEmailAddress { get; set; }

        public string Subject { get; set; }

        public string HtmlContent { get; set; }

        public string EmailPlainTextBody { get; set; }

        public bool DisplayReceipt { get; set; }
    }
}
