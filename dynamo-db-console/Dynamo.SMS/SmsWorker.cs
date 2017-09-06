using Dynamo.Models.Configs;
using Dynamo.Models.sms;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Dynamo.SMS
{
    public class SmsWorker : ISmsWorker
    {
        private readonly string Key;
        public SmsWorker(IOptions<SmsConfig> smsConfig)
        {
            Key = smsConfig.Value.Key;

        }

        public SmsResponse SendSMS(string phone, string content) {

            SmsResponse smsResponse = default(SmsResponse);

            using (HttpClient client = new HttpClient()) {

                FormUrlEncodedContent encodedContent = new FormUrlEncodedContent(new[] {
                    new KeyValuePair<string, string>("phone", phone),
                    new KeyValuePair<string, string>("message", content),
                    new KeyValuePair<string, string>("key", Key),
                });

                HttpResponseMessage message =  client.PostAsync("https://textbelt.com/text", encodedContent).Result;
                if (message.IsSuccessStatusCode)
                {
                    string response = message.Content.ReadAsStringAsync().Result;
                    smsResponse = JsonConvert.DeserializeObject<SmsResponse>(response);
                }
                else {
                    smsResponse = new SmsResponse { success = false };
                }

                return smsResponse;
            }

        }

    }
}
