using LinkedInMVC.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkedInMVC.BLL
{
    public class ConnectionManager : Repository<Company, ApplicationDbContext>
    {
        public ConnectionManager(ApplicationDbContext context) : base(context)
        {

        }
    }
}
