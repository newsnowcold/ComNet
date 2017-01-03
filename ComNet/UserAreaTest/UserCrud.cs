using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DataAccessLayer;
using System.Data.Entity;
using ComNet.Areas.Users.Controllers;
using ComNet.Areas.Users.Models;
using System.Web.Http.Results;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UserAreaTest
{
  [TestClass]
  public class UserCrud
  {

    [TestMethod]
    public void CreateUser()
    {
      try
      {

        var mockUsers = new Mock<DbSet<User>>();

        var mockDBContext = new Mock<Darrel_ComNetEntities>();
        mockDBContext.Setup(a => a.Users).Returns(mockUsers.Object);

        var controller = new UsersController(mockDBContext.Object);
        controller.Request = new HttpRequestMessage();
        controller.Request.SetConfiguration(new HttpConfiguration());

        var task = controller.CreateUser(new UserModel()
        {
          Email = "darrel.abello@gmail.com",
          FirstName = "Darrel",
          LastName = "Abello",
          MiddleName = "Demeray"
        });
        task.Wait();

        var response = task.Result;

        mockUsers.Verify(m => m.Add(It.IsAny<User>()), Times.Once());
        mockDBContext.Verify(m => m.SaveChanges(), Times.Once());

        Assert.IsNotNull(response);

        Assert.AreEqual(HttpStatusCode.OK, response);
        string uid;
        Assert.IsTrue(response.TryGetContentValue(out uid));
      }
      catch (Exception e)
      {
        throw;
      }
    }

    [TestMethod]
    public void GetUsers()
    {
      Assert.Fail();
    }

    [TestMethod]
    public void GetUser()
    {
      Assert.Fail();
    }

    [TestMethod]
    public void EditUser()
    {
      Assert.Fail();
    }

    [TestMethod]
    public void RemoveUser()
    {
      Assert.Fail();
    }

  }
}
