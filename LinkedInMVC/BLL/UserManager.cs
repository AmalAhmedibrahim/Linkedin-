using LinkedInMVC.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkedInMVC.BLL
{
    public class UserManager : Repository<ApplicationUser, ApplicationDbContext>
    {
        public UserManager(ApplicationDbContext context) : base(context)
        {
        }

    }
}