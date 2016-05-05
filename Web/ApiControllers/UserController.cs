using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebPPublished.Models;

namespace WebPPublished.ApiControllers
{
    public class UserController : ApiController
    {
        //private ApplicationSignInManager _signInManager;

        //public ApplicationSignInManager SignInManager
        //{
        //    get
        //    {
        //        return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
        //    }
        //    private set
        //    {
        //        _signInManager = value;
        //    }
        //}

        //[HttpGet]
        //public IHttpActionResult Login([FromBody] LoginViewModel model)
        //{
        //    var result = SignInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, shouldLockout: false);
        //    switch (result)
        //    {
        //        case SignInStatus.Success:
        //            return Ok();
        //        case SignInStatus.Failure:
        //            return NotFound();
        //        default:
        //            return NotFound();
        //    }
        //}
    }
}
