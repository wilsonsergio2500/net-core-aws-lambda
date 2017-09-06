using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Text;
using Dynamo.SMS;
using Dynamo.Models.sms;

namespace Dynamo.DAL.TEST
{
    [TestClass]
    public class SmsWorkerTest
    {
        [TestMethod]
        public void SmsWorkerWorks() {

            IServiceProvider sp = StartUp.ServiceProvider;
            ISmsWorker smsWorker = sp.GetService<ISmsWorker>();

            SmsResponse response =  smsWorker.SendSMS("4023509079", "test");

            Assert.IsTrue(response.success);
        }
    }
}
