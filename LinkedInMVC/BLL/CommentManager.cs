﻿using LinkedInMVC.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkedInMVC.BLL
{
    public class CommentManager : Repository<Comment, ApplicationDbContext>
    {
        public CommentManager(ApplicationDbContext context) : base(context)
        {
        }
    }
}