using Dynamo.DAL.Interfaces;
using Dynamo.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Extensions.DependencyInjection;


namespace Dynamo.DAL.TEST.Respository
{
    [TestClass]
    public class MessageRepositoryTest
    {
        [TestMethod]
        public void Add() {
            IServiceProvider sp = StartUp.ServiceProvider;

            IBaseRepository<Message> messageRepo = sp.GetService<IBaseRepository<Message>>();

            Message newMessage = new Message { Email = "gioboy@gmail.com", Content = "hello World" };

            Message retrievedMessage = messageRepo.Add(newMessage);

            Assert.IsNotNull(retrievedMessage);

        }

        [TestMethod]
        public void Get()
        {
            IServiceProvider sp = StartUp.ServiceProvider;

            IBaseRepository<Message> messageRepo = sp.GetService<IBaseRepository<Message>>();

            Message retrievedMessage = messageRepo.Get(1);

            Assert.IsNotNull(retrievedMessage);
        }
    }
}
