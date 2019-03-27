using LinkedInMVC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkedInMVC.Controllers
{
    public class ProfileController : Controller
    {

        public UnitofWork UnitofWork
        {
            get
            {
                return HttpContext.GetOwinContext().Get<UnitofWork>();
            }
        }
        // GET: Profile
        public ActionResult Index(int id)
        {   
           // var UserData=UnitofWork.UserManager.pro
            var EducationData = UnitofWork.EducationManager.GetAll();
            var ExperienceData = UnitofWork.ExperienceManager.GetAll();
            var user = User.Identity.GetUserId();
            var userData = UnitofWork.UserDetailsManager.GetById(user);
           
            return View();
        }
    }
}