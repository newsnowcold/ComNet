using ComNet.Areas.Users.Models;
using ComNet.Factories;
using ComNet.Models;
using DataAccessLayer;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ComNet.Areas.Users.Controllers
{
  public class UsersController : ApiController
  {

    private Darrel_ComNetEntities _db;
    private ApplicationUserManager userManager;

    public UsersController()
    {
      _db = new Darrel_ComNetEntities();
      _db.Configuration.ProxyCreationEnabled = false;
    }

    public UsersController(Darrel_ComNetEntities db)
    {
      _db = db;
      _db.Configuration.ProxyCreationEnabled = false;
    }


    /// <summary>
    /// Get list of users
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<HttpResponseMessage> GetUsers()
    {

      var users = _db.Users.ToList();

      return Request.CreateResponse(HttpStatusCode.OK, users);
    }

    /// <summary>
    /// Get user
    /// </summary>
    /// <param name="uid"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<HttpResponseMessage> GetUser(string uid)
    {
      var user = _db.Users.Where(a => a.Id.ToString() == uid).FirstOrDefault();

      return Request.CreateResponse(HttpStatusCode.OK, user);
    }

    [HttpPost]
    public async Task<HttpResponseMessage> CreateUser(UserModel model)
    {
      var userManager = new UserManagerFactory(Request).GetInstance();

      var user = new ApplicationUser()
      {
        UserName = model.Email,
        Email = model.Email,
        EmailConfirmed = false
      };

      IdentityResult result = await userManager.CreateAsync(user, model.Password);

      if (!result.Succeeded)
      {
        return Request.CreateResponse(HttpStatusCode.InternalServerError, result.Errors);
      }

      var aspNetUser = await userManager.FindByEmailAsync(model.Email);
      Guid new_uid = Guid.NewGuid();

      _db.Users.Add(new User()
      {
        Email = model.Email,
        FirstName = model.FirstName,
        LastName = model.LastName,
        Id = new_uid,
        Status = 1,
        LoginId = aspNetUser.Id
      });

      _db.SaveChanges();

      return Request.CreateResponse(HttpStatusCode.OK, new_uid);
    }

    [HttpPut]
    public async Task<HttpResponseMessage> EditUser(EditUserModel model)
    {
      var user = _db.Users.Where(a => a.Id.ToString() == model.Uid).FirstOrDefault();

      user.Email = model.Email;
      user.FirstName = model.FirstName;
      user.LastName = model.LastName;
      user.MiddleName = model.MiddleName;

      _db.SaveChanges();

      return Request.CreateResponse(HttpStatusCode.OK);
    }

  }
}
