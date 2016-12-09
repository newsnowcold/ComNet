using IBusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusinessLogicLayer
{
  public interface ICRUD_Users
  {
    UserModels Create(UserModels model);

    List<UserModels> Read();

    UserModels Read(string id);

    bool Update(UserModels model);

    bool Delete(string id);
  }
}
