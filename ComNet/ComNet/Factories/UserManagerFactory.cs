using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ComNet.Factories
{
  public class UserManagerFactory
  {
    private HttpRequestMessage _request;


    public UserManagerFactory(HttpRequestMessage request)
    {
      _request = request;
    }

    public ApplicationUserManager GetInstance()
    {
      return _request.GetOwinContext().GetUserManager<ApplicationUserManager>();
    }
  }
}