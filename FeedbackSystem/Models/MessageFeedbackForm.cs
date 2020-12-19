using System;
using System.Collections.Generic;
using System.Text;

namespace FeedbackSystem.Models
{
    public class MessageFeedbackForm
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string FeedbackMessage { get; set; }
    }
}
