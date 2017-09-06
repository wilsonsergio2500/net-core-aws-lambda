using Dynamo.DAL.Client;
using Dynamo.DAL.Interfaces;
using Dynamo.DAL.Repository;
using Dynamo.Models;
using Dynamo.Models.Configs;
using Dynamo.TokenReader;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Dynamo.DAL.TEST
{
    [TestClass]
    public class StartUp
    {
        public static IServiceProvider ServiceProvider { get; set; }
        public static IConfigurationRoot Configuration { get; set; }

        [AssemblyInitialize]
        public static void Init(TestContext context)
        {
            string corePath = Directory.GetCurrentDirectory();
            string debug = Directory.GetParent(corePath).FullName;
            string bin = Directory.GetParent(debug).FullName;
            string Path = Directory.GetParent(bin).FullName;

            var builder = new ConfigurationBuilder()
            .SetBasePath(Path)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();
            Configuration = builder.Build();

            ServiceProvider = RegisterServiceCollection();


        }

        public static IServiceProvider RegisterServiceCollection()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddOptions();

            services.Configure<AwsConfig>(Configuration.GetSection("AwsConfig"));
            services.AddScoped<IJwTokenReader, JwtTokenReader>();
            services.AddSingleton<IDynamoClient, DynamoClient>();
            services.AddSingleton<IDynamoDb, DynamoDb>();
            services.AddSingleton<IBaseRepository<Message>, MessageRepository>();
            
            

            return services.BuildServiceProvider();
        }
    }
}
