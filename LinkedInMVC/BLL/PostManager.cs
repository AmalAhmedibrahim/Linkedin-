using LinkedInMVC.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkedInMVC.BLL
{
    public class PostManager : Repository<Comment, ApplicationDbContext>
    {
        private ApplicationDbContext context ;
        public PostManager(ApplicationDbContext context) : base(context)
        {
            context = this.context;
            
        }

        //public static List<Post> GetAllByDate(string userId)
        //{
        //    List<Guid> cons = AppManager.linkedInContext
        //        .Connection_Requeset.Where(c => c.FK_UserId == userId)
        //        .Where(c => c.IsApproved == true)
        //        .Select(c => c.FK_Connction_UserId).ToList();
        //    return AppManager.linkedInContext.Posts
        //        .Where(p => cons.Any(c => c == p.FK_CreatorId))
        //        .OrderBy(p => p.Date).ToList();
        //}
        //public static List<Post> GetAllByTop(string userId)
        //{
        //    /***
        //     * Get Connections of the user who he has access to 
        //     * view his posts
        //     * */
        //    List<Guid> cons = AppManager.linkedInContext
        //        .Connection_Requeset.Where(c => c.FK_UserId == userId)
        //        .Where(c => c.IsApproved == true)
        //        .Select(c => c.FK_Connction_UserId).ToList();
        //    /***
        //     * Get the posts of people in cons
        //     * */
        //    return AppManager.linkedInContext.Posts
        //        .Where(p => cons.Any(c => c == p.FK_CreatorId))
        //        .OrderBy(p => p.Num_Of_Comments).ToList();
        //}
        //public static void deletePost(int postId)
        //{
        //    Post postToDelete = AppManager.linkedInContext.Posts
        //        .Select(p => p).Where(p => p.Id == postId).FirstOrDefault();
        //    AppManager.linkedInContext.Posts.Remove(postToDelete);
        //    AppManager.linkedInContext.SaveChanges();
        //}

        /***
         * Load all the posts for the profile page
         * */
        //public static List<Post> GetAllByUserId(string userId)
        //{
        //    return AppManager.linkedInContext.Posts
        //        .Where(e => e.FK_CreatorId == userId).ToList();
        //}
        //public static Post GetByPostId(int postId)
        //{
        //    return (Post)AppManager.linkedInContext.Posts
        //        .Where(e => e.Id == postId);
        //}
    }
}