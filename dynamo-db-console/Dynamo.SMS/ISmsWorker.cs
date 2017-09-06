using Dynamo.Models.sms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamo.SMS
{
    public interface ISmsWorker
    {
        SmsResponse SendSMS(string phone, string content);
    }
}
