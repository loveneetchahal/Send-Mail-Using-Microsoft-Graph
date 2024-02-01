using System;
using Microsoft.Graph;

namespace Send_Mail_Using_Microsoft_Graph.Models
{
    public class GraphMail
    {
        public string FromEmail { get; set; }
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public BodyType ContentType { get; set; }
        public bool SaveToSentItems { get; set; }
    }
}

