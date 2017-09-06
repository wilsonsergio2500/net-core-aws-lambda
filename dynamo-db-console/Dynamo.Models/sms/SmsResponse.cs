using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamo.Models.sms
{
    public class SmsResponse
    {
        public bool success { get; set; }
        public string textId { get; set; }
        public int quotaRemaining { get; set; }
    }
}
