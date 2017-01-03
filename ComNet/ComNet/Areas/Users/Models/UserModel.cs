using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ComNet.Areas.Users.Models
{

  public class EditUserModel: UserModel
  {
    public string Uid { get; set; }
  }

  public class UserModel
  {
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    public string MiddleName { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    public string  Password { get; set; }
  }
}