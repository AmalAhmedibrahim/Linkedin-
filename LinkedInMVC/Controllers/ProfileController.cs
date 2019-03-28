﻿using LinkedInMVC.Models;
using LinkedInMVC.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public ActionResult Index()
        {

            string id = User.Identity.GetUserId();
            ApplicationUser currentUser = UnitofWork.UserManager.FindById(id);
            ProfileViewModel ProfileVM;
            if (User.Identity.IsAuthenticated)
            {
                List<EducationViewModel> userEducations = UnitofWork.UserEducationManager.GetUserEducations(id);
                List<ExperienceViewModel> userExperiences = UnitofWork.UserExperienceManager.GetUserExperiences(id);
                ProfileVM = new ProfileViewModel
                {
                    FirstName = currentUser.FirstName,
                    LastName = currentUser.SecondName,
                    ProfileImage = currentUser.ProfileImage,
                    ProfileCover = currentUser.ProfileCover,
                    CurrentCopmany = currentUser.CurrentCopmany,
                    Headline = currentUser.Headline,
                    Country = currentUser.Country,
                    NumOfConnections = currentUser.NumOfConnections,
                    Educations = userEducations,
                    Experiences = userExperiences
                };
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(ProfileVM);
        }


        //public Task<ActionResult> Create( )
        //{

        //}
    }
}     