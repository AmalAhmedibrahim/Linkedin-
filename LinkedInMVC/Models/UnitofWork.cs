﻿using Microsoft.AspNet.Identity.Owin;
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

        public UnitofWork(IOwinContext owinContext)
        {
            context = owinContext.Get<ApplicationDbContext>();
            RoleManager = owinContext.Get<ApplicationRoleManager>();
            UserManager = owinContext.Get<ApplicationUserManager>();
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