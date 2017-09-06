using System;
using Amazon.Lambda.Core;
using Microsoft.Extensions.DependencyInjection;
using Dynamo.Models;
using Dynamo.TokenReader;
using Dynamo.TokenReader.Helper;
using System.Security.Claims;
using System.Collections.ObjectModel;
using Dynamo.DI;
using Dynamo.Models.Configs;
using Microsoft.Extensions.Options;
using Dynamo.DAL.Interfaces;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
[assembly: DynamoDI()] //for dependency injection

namespace DynamoLambda
{
    public class Function
    {
        
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public object FunctionHandler(LambdaRequest<Message> MessageInput, ILambdaContext context)
        {
            string AuthorizationHeader = MessageInput.headers["Authorization"];
            if (string.IsNullOrEmpty(AuthorizationHeader)) {
                throw new Exception("Unauthorized");
            }

            IServiceProvider sp = DI.ServiceProvider;
            IJwTokenReader tokenReader = sp.GetService<IJwTokenReader>();
            IBaseRepository<Message> messageRepo = sp.GetService<IBaseRepository<Message>>();

            ReadOnlyCollection<Claim> claims = tokenReader.ReadToken(AuthorizationHeader);
            Message newMessage = messageRepo.Add(MessageInput.body);


            return new { 
                ClientId = claims.GetClaimValue(ClaimList.GallupClientId),
                MessageId = newMessage.Id
            };

        }
    }
}
