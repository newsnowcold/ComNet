using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IBusinessLogicLayer.Models
{
  public class UserModels
  {
    public string Id { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]    
    public string LastName { get; set; }

    public string MiddleName { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    public int UserStatus { get; set; }
  }
}
