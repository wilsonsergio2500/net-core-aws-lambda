using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Linq;
using Amazon.Lambda.Core;
using Amazon.Lambda.DynamoDBEvents;
using Amazon.DynamoDBv2.Model;
using Microsoft.Extensions.DependencyInjection;
using Dynamo.Models;
using System.Reflection;
using System.Collections.Generic;
using Dynamo.DI;
using Dynamo.DAL.Interfaces;
using Dynamo.SMS;
using Dynamo.Models.sms;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
[assembly: DynamoDI()] 

namespace DynamoLambdaResponder
{
    public class Function
    {
        

        public void FunctionHandler(DynamoDBEvent dynamoEvent, ILambdaContext context)
        {
            context.Logger.LogLine($"Beginning to process {dynamoEvent.Records.Count} records...");

            IServiceProvider sp = DI.ServiceProvider;
            IBaseRepository<Message> messageRepo = sp.GetService<IBaseRepository<Message>>();
            ISmsWorker smsWorker = sp.GetService<ISmsWorker>();

            foreach (var record in dynamoEvent.Records)
            {
                //because the stream parser strategy seems an overkill 
                //to be introduced of all object
                long Id = Convert.ToInt64(record.Dynamodb.Keys.First().Value.N);
                context.Logger.LogLine($"Requesting record Id  : {Id}");

                Message msg = messageRepo.Get(Id);

                context.Logger.LogLine(JsonConvert.SerializeObject(msg));

                if (msg.Phone != null) {
                   SmsResponse smsResponse =  smsWorker.SendSMS(msg.Phone, msg.Content);
                    string log = smsResponse.success ? $"SMS Message send : {msg.Phone}" : "SMS Message was unable to be sent";
                    context.Logger.LogLine(log);
                }


            }

            context.Logger.LogLine("Stream processing complete.");
        }

        
    }
}