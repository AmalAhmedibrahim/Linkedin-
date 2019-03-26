﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LinkedInMVC.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<UserCompany> UserCompanies { get; set; }
        
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        //Adding First and last names to user table
        public string FirstName { get; set; }
        public string SecondName { get; set; }

        public string ProfileImage { get; set; }

        public string ProfileCover { get; set; }

        public string Title { get; set; }
        public string Country { get; set; }

        public int NumOfConnections { get; set; }

        public ICollection<UserEducation> Usereducations = new List<UserEducation>();
        public ICollection<UserExperience> UserExperiences = new List<UserExperience>();
    }


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
      
        public DbSet<Company> Company { get; set; }
        public DbSet<UserCompany> UserCompany { get; set; }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Comment> Comments { get; set; }


        public DbSet<Education> Educations { get; set; }
         public DbSet<UserEducation> UserEducation { get; set; }
      
        public DbSet<Experience> Experience { get; set; }
        public DbSet<UserExperience> UserExperiences { get; set; }

        //CONNECTION
        public DbSet<Connection_Request> Connection_Requeset { get; set; }




    }
}