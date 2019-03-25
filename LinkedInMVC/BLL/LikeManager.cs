using LinkedInMVC.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkedInMVC.BLL
{
    public class LikeManager : Repository<Like, ApplicationDbContext>
    {
        public LikeManager(ApplicationDbContext context) : base(context)
        {
        }
    }
}