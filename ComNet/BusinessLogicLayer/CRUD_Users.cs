using DataAccessLayer;
using IBusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBusinessLogicLayer.Models;
using System.Net;
using CustomExtensions;

namespace BusinessLogicLayer
{
  public class CRUD_Users : ICRUD_Users
  {
    private Darrel_ComNetEntities _db;



    public CRUD_Users()
    {
      _db = new Darrel_ComNetEntities();
      _db.Configuration.ProxyCreationEnabled = false;
    }

    public CRUD_Users(Darrel_ComNetEntities db)
    {
      _db = db;
      _db.Configuration.ProxyCreationEnabled = false;
    }



    public UserModels Create(UserModels model)
    {
      //if (ModelState)

      var newUser = new User()
      {
        FirstName = model.FirstName,
        LastName = model.LastName,
        MiddleName = model.MiddleName,
        Email = model.Email,
        Status = model.UserStatus,
        Id = Guid.NewGuid()
      };

      _db.Users.Add(newUser);
      _db.SaveChanges();

      model.Id = newUser.Id.ToString();

      return model;
    }

    public bool Delete(string id)
    {
      bool result = false;

      // 1 is the value user statues
      var deleteStatus = this._db.Statuses
        .Where(a => a.TypeId == 1 &&
               a.Name.Contains("deleted", StringComparison.OrdinalIgnoreCase))
               .FirstOrDefault();

      var user = this._db.Users.Where(a => a.Id.ToString().Equals(id)).FirstOrDefault();

      if (user != null)
      {
        user.Status = deleteStatus.Id;
        this._db.SaveChanges();

        result = true;
      }

      return result;
    }

    public List<UserModels> Read()
    {
      List<UserModels> parsedUsers = new List<UserModels>();
      var users = this._db.Users.ToList();

      parsedUsers = users.Select(a => new UserModels()
      {
        Email = a.Email,
        FirstName = a.FirstName,
        LastName = a.LastName,
        MiddleName = a.MiddleName,
        UserStatus = a.Status
      }).ToList();

      return parsedUsers;
    }

    public UserModels Read(string id)
    {
      UserModels parsedUser = new UserModels();

      var user = this._db.Users.Where(a => a.Id.ToString().Equals(id)).FirstOrDefault();

      parsedUser.Email = user.Email;
      parsedUser.FirstName = user.FirstName;
      parsedUser.LastName = user.LastName;
      parsedUser.MiddleName = user.MiddleName;
      parsedUser.UserStatus = user.Status;

      return parsedUser;
    }

    public bool Update(UserModels model)
    {
      bool result = false;
      var user = this._db.Users.Where(a => a.Id.ToString().Equals(model.Id)).FirstOrDefault();

      if (user != null)
      {
        user.Email = model.Email;
        user.FirstName = model.FirstName;
        user.LastName = model.LastName;
        user.MiddleName = model.MiddleName;
        user.Status = model.UserStatus;
        this._db.SaveChanges();

        result = true;
      }

      return result;
    }
  }
}
