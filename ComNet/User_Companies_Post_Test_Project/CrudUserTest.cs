using BusinessLogicLayer;
using DataAccessLayer;
using IBusinessLogicLayer;
using IBusinessLogicLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace User_Companies_Post_Test_Project
{
  [TestClass]
  public class CrudUserTest
  {
  
    public CrudUserTest()
    {

    }

    [TestMethod]
    public void CreateUser_Fill_All_Fields_With_No_Error_Retun_200()
    {
      var mockSet = new Mock<DbSet<User>>();

      var mockContext = new Mock<Darrel_ComNetEntities>();
      mockContext.Setup(a => a.Users).Returns(mockSet.Object);

      ICRUD_Users userService = new CRUD_Users(mockContext.Object);

      var result = userService.Create(new UserModels()
      {
        Email = "netzon.darrel@gmail.com",
        FirstName = "Darrel",
        LastName = "LastName",
        MiddleName = "Demeray",
        UserStatus = 1        
      });

      Assert.IsNotNull(result);

      mockSet.Verify(a => a.Add(It.IsAny<User>()), Times.Once());
      mockContext.Verify(m => m.SaveChanges(), Times.Once());
    }

    [TestMethod]
    public void CreateUser_Keep_Some_Required_Fields_Blank_400()
    {

      var mockSet = new Mock<DbSet<User>>();

      var mockContext = new Mock<Darrel_ComNetEntities>();
      mockContext.Setup(a => a.Users).Returns(mockSet.Object);

      ICRUD_Users userService = new CRUD_Users(mockContext.Object);

      var result = userService.Create(new UserModels()
      {
        Email = "netzon.darrel@gmail.com",
        FirstName = "Darrel",
        LastName = "LastName",
        MiddleName = "Demeray",
        UserStatus = 1
      });

      Assert.IsNotNull(result);

      mockSet.Verify(a => a.Add(It.IsAny<User>()), Times.Once());
      mockContext.Verify(m => m.SaveChanges(), Times.Once());
    }

    [TestMethod]
    public void Invalid_Email_Format_Should_Return_400()
    {
      Assert.Fail();
    }

    [TestMethod]
    public void RemoveUser()
    {
      Assert.Fail();
    }

    [TestMethod]
    public void UpdateUser()
    {
      Assert.Fail();
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


  }
}
