using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Dummy.Controllers;
using Dummy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Telerik.JustMock;
using Newtonsoft.Json;
using NSubstitute;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        

        [SetUp]
        public void Setup()
        {
            
            
        }

        [Test]
        public void InitTest()
        {
            //Arrange
            var context = Telerik.JustMock.Mock.Create<DummyContext>();
        DummyModelsController dummyController = new DummyModelsController(context);

        //Act
        string result = dummyController.Init();

           
            //Assert
            Assert.AreEqual("Intial Test works", result);
        }



        [Test]
        public async Task RegisterTestAsync()
        {
            var context = Telerik.JustMock.Mock.Create<DummyContext>();
            DummyModelsController dummyController = new DummyModelsController(context);

            var dummyModel = Telerik.JustMock.Mock.Create<DummyModel>();
            dummyModel.FirstName = "Mpinane";
            dummyModel.LastName = "Mohale";
            dummyModel.Password = "nane";
            dummyModel.Username = "mpi";
            dummyModel.Id = 5;


            //Act
            var registeredUser = await dummyController.Register(dummyModel);

            //int x = 0;
            //Assert
           // Assert.AreEqual(context.UserTest.Find(, registeredUser);
            Assert.AreEqual("Microsoft.AspNetCore.Mvc.ActionResult`1[Dummy.Models.DummyModel]", registeredUser.ToString());

            
        }


        
        [Test]
        public async Task CreateBlog_saves_a_blog_via_contextAsync()
        {
            var context = Telerik.JustMock.Mock.Create<DummyContext>();
            DummyModelsController dummyController = new DummyModelsController(context);


            var mockSet = new Moq.Mock<DbSet<DummyModel>>();

            var mockContext = new Moq.Mock<DummyContext>();
            mockContext.Setup(m => m.UserTest).Returns(mockSet.Object);

            var controller = new DummyModelsController(mockContext.Object);
            await controller.Register(new DummyModel { FirstName = "Mpinane", LastName = "Mohale", Username = "mpi", Password = "nane" });

            int x = 0;
            mockSet.Verify(m => m.Add(It.IsAny<DummyModel>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
        








        /*   HttpClient _client = new HttpClient();
          HttpListener _httpListener = new HttpListener();

          [Test]
          public async Task RegisterTest()
          {

              //Arrange

              var dummyModel = new DummyModel { FirstName = "Mpinane", LastName = "Mohale", Username = "mpi", Password = "nane" };

              var stringContent = new StringContent(JsonConvert.SerializeObject(dummyModel));

              _httpListener.Prefixes.Add("http://localhost:44312/");
              _httpListener.Start();

              //Act
              var response = await _client.PostAsync("http://localhost:44312/users/register", stringContent);
             // _httpListener.Stop();
              var x = response;

              // Check if status code is OK
              Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
              // Get JSON  of the dummyModel from response
              var jsonResponse = await response.Content.ReadAsStringAsync();
              // Deserialize response JSON to Empoyee class
              var EmployeeResponse = JsonConvert.DeserializeObject<DummyModel>(jsonResponse);
              // Check if the Employee is the same

              Assert.AreEqual(dummyModel.FirstName, EmployeeResponse.FirstName);
              Assert.AreEqual(dummyModel.LastName, EmployeeResponse.LastName);
              Assert.AreEqual(dummyModel.Username, EmployeeResponse.Username);
              Assert.AreEqual(dummyModel.Password, EmployeeResponse.Password);
              */

        //private DummyContext _context = ;

        /*   Mock<DummyContext> dummyContext = new Mock<DummyContext>();

                [SetUp]
                public void Setup()
                {

                }


                */






    }
}