using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EvolentHealthBusinessLayer;
using Moq;
using EvolentHealthExerciseApi.Controllers;
using EvolentHealthExerciseApi.Models;
using System.Web.Http;
using System.Net;
using EvolentHealthDataModel;
using System.Collections.Generic;

namespace EvolentHealthExerciseApi.Tests
{
    [TestClass]
    public class EvolentHealthUnitTest
    {
        private List<Contact> returnResult = new List<Contact>();
        public EvolentHealthUnitTest()
        {
            returnResult.Add(new Contact
            {
                Email = "testmail@gmail.com",
                FirstName = "test",
                LastName = "test",
                PhoneNumber = "12345",
                Status = true,
                Id = 1
            });
            returnResult.Add(new Contact
            {
                Email = "testmail1@gmail.com",
                FirstName = "test1",
                LastName = "test1",
                PhoneNumber = "123456",
                Status = false,
                Id = 2
            });
        }


        [TestMethod]
        public void GetAllContactes()
        {
            var mockRepository = new Mock<IContactBL>();
            mockRepository.Setup(service => service.GetContactes(null))
            .Returns(returnResult);

            var controller = new EvolentHealthController(mockRepository.Object);
            var result = controller.GetContacts();
            Assert.AreEqual(HttpStatusCode.OK, result.HttpStatus);
        }

        [TestMethod]
        public void GetAllActiveContactes()
        {

            var mockRepository = new Mock<IContactBL>();
            mockRepository.Setup(service => service.GetContactes(true))
            .Returns(returnResult);

            var controller = new EvolentHealthController(mockRepository.Object);
            var result = controller.GetContacts(true);

            Assert.AreEqual(HttpStatusCode.OK, result.HttpStatus);
        }

        [TestMethod]
        public void GetAllInActiveContactes()
        {

            var mockRepository = new Mock<IContactBL>();
            mockRepository.Setup(service => service.GetContactes(false))
            .Returns(returnResult);

            var controller = new EvolentHealthController(mockRepository.Object);
            var result = controller.GetContacts(false);
            Assert.AreEqual(HttpStatusCode.OK, result.HttpStatus);
        }

        [TestMethod]
        public void GetContactById()
        {
            int id = 2;
            var mockRepository = new Mock<IContactBL>();
            mockRepository.Setup(service => service.GetContactById(id))
            .Returns(returnResult.Find(f => f.Id == id));

            var controller = new EvolentHealthController(mockRepository.Object);
            var result = controller.GetContactById(id);
            Assert.AreEqual(HttpStatusCode.OK, result.HttpStatus);
        }


        [TestMethod]
        public void SaveContact()
        {
            bool isSave = false;
            var contact = new Contact
            {
                Email = "testmail1@gmail.com",
                FirstName = "test2",
                LastName = "test2",
                PhoneNumber = "1234567",
                Status = false,
                Id = 3
            };
            var mockRepository = new Mock<IContactBL>();
            mockRepository.Setup(service => service.AddContact(contact))
            .Returns(isSave);

            var controller = new EvolentHealthController(mockRepository.Object);
            var result = controller.AddContact(contact);
            Assert.AreEqual(HttpStatusCode.OK, result.HttpStatus);
        }

        [TestMethod]
        public void UpdateContact()
        {
            bool isSave = false;
            var contact = new Contact
            {
                Email = "testmail1@gmail.com",
                FirstName = "test2",
                LastName = "test2",
                PhoneNumber = "1234567",
                Status = false,
                Id = 3
            };
            var mockRepository = new Mock<IContactBL>();
            mockRepository.Setup(service => service.EditContact(contact))
            .Returns(isSave);

            var controller = new EvolentHealthController(mockRepository.Object);
            var result = controller.EditContact(contact);
            Assert.AreEqual(HttpStatusCode.OK, result.HttpStatus);
        }

        [TestMethod]
        public void DeleteContact()
        {
            bool isSave = false;
            int id = 3;
            var mockRepository = new Mock<IContactBL>();
            mockRepository.Setup(service => service.DeleteContact(id))
            .Returns(isSave);

            var controller = new EvolentHealthController(mockRepository.Object);
            var result = controller.DeleteContact(id);
            Assert.AreEqual(HttpStatusCode.OK, result.HttpStatus);
        }


    }
}
