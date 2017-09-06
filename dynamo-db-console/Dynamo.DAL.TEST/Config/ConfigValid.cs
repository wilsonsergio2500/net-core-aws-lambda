using Dynamo.Models.Configs;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace Dynamo.DAL.TEST.Config
{
    [TestClass]
    public class ConfigValid
    {
        [TestMethod]
        public void AwsConfigExist() {
            IServiceProvider sp = StartUp.ServiceProvider;
            IOptions<AwsConfig> config = sp.GetService<IOptions<AwsConfig>>();
            Assert.IsNotNull(config.Value);
        }
        [TestMethod]
        public void SmsConfigExist() {
            IServiceProvider sp = StartUp.ServiceProvider;
            IOptions<SmsConfig> config = sp.GetService<IOptions<SmsConfig>>();
            Assert.IsNotNull(config.Value);
        }
    }
}
