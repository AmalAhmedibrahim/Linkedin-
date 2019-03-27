﻿using LinkedInMVC.BLL;
using LinkedInMVC.Managers;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkedInMVC.Models
{
    public class UnitofWork
     : IDisposable
    {
        private readonly ApplicationDbContext context;
        public ApplicationRoleManager RoleManager { get; private set; }
        public ApplicationUserManager UserManager { get; private set; }
        public CompanyManager CompanyManager { get; set; }// unit of work for company manager
        public UserCompanyManager UserCompanyManager { get; set; }// unit of work for usercompany manager
        public ConnectionManager ConnectionManager { get; set; }// unit of work for usercompany manager
        
        public ExperienceManager ExperienceManager
        {
            get
            {
                return new ExperienceManager(context);
            }
        }

        public EducationManager EducationManager
        {
            get
            {
                return new EducationManager(context);
            }
        }
        public UserManager AmalUserManager
        {
            get
            {
                return new UserManager(context);
            }
        }


        public UnitofWork(IOwinContext owinContext)
        {
            context = owinContext.Get<ApplicationDbContext>();
            RoleManager = owinContext.Get<ApplicationRoleManager>();
            UserManager = owinContext.Get<ApplicationUserManager>();
            CompanyManager = owinContext.Get<CompanyManager>();  // initialize company manager property
            UserCompanyManager = owinContext.Get<UserCompanyManager>(); // initialize usercompany manager property 
        }
        public static UnitofWork Create(IdentityFactoryOptions<UnitofWork> options, IOwinContext owinContext)
        {
            return new UnitofWork(owinContext);
        }


        public void Dispose()
        {
        }
    }
}