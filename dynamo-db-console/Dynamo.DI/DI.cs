using Dynamo.DAL;
using Dynamo.DAL.Client;
using Dynamo.DAL.Interfaces;
using Dynamo.DAL.Repository;
using Dynamo.Models;
using Dynamo.Models.Configs;
using Dynamo.TokenReader;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Dynamo.DI
{
    public class DI
    {
        public DI()
        {
            Inject();
        }

        public static IServiceProvider ServiceProvider { get; set; }
        private void Inject() {
            IServiceCollection services = new ServiceCollection();
            services.AddOptions();
            services.AddScoped<IJwTokenReader, JwtTokenReader>();

            Action<AwsConfig> IOptionAction = (AwsConfig aws) => {
                aws.awsKey = Environment.GetEnvironmentVariable("awsKey");
                aws.awsSecret = Environment.GetEnvironmentVariable("awsSecret");
            };


            services.Configure<AwsConfig>(IOptionAction);
            services.AddSingleton<IDynamoClient, DynamoClient>();
            services.AddSingleton<IDynamoDb, DynamoDb>();
            services.AddSingleton<IBaseRepository<Message>, MessageRepository>();


            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
