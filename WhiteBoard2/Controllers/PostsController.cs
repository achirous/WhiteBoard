using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WhiteBoard2.Models;
using Microsoft.AspNet.Identity;

namespace WhiteBoard2.Controllers
{
    [Authorize]
    public class PostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Posts
        public ActionResult Index()
        {
            //db.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Posts',RESEED,0);");
            //db.Database.ExecuteSqlCommand("TRUNCATE TABLE Comments");
            //db.Database.ExecuteSqlCommand("TRUNCATE TABLE ViewedPosts");
            //checks if the user is a lecturer or a student an renders appropriate views accordingly
            if (User.IsInRole("Lecturer"))
            {
                return View("Index");
            }else
            {
                //if user is a student then update each post to seen by that student
                //get current user
                string currentUserId = User.Identity.GetUserId();
                ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);
                //initialize a list of PostIds
                List<int> pIds = new List<int>();
                var name = currentUser.UserName;
                var pId = 0;
                //loop through posts to update the ViewedPosts table
                foreach (var post in db.Posts)
                {
                    //populates list of PostIds
                    pId = post.PostId;

                    //add a new entry to ViewedPost table
                    ViewedPost seen = new ViewedPost();
                    seen.ViewPost = post;
                    seen.IdViewed = pId;
                    seen.ViewedByUser = currentUser;
                    seen.ViewedByName = name;
                    db.ViewedPosts.Add(seen);
                   
                }
                
                db.SaveChanges();
                //create a list of duplicate entries in the ViewedPosts table
                List<ViewedPost> duplicates = db.ViewedPosts.GroupBy(d => new { d.ViewPost, d.ViewedByName}).Where(d => d.Count()>1)
                                  .Select(d => d.FirstOrDefault()).ToList();
                
                //deletes every duplicate entry from the ViewedPosts table
                foreach(var item in duplicates)
                {
                    System.Diagnostics.Debug.WriteLine(item.IdViewed+" "+item.ViewedByName);
                    db.ViewedPosts.Remove(item);
                }
                db.SaveChanges();
                
                return View("StudentIndex");
            }
            
        }

        //returns the SeenByView containing the info about who saw that post
        [Authorize(Roles ="Lecturer")]
        public ActionResult BuildSeenBy(int i)
        {
            Post post = db.Posts.Find(i);
            return PartialView("_SeenByView", db.ViewedPosts.ToList().Where(x => x.ViewPost == post));
        }

        //returns all the announcements that have been made
        public ActionResult BuildPostTable()
        {
            return PartialView("_PostTable", db.Posts.ToList());            
        }

        //returns all the comments for each announcement whose id is passed as a parameter
        [HttpPost]
        public ActionResult BuildCommentsTable(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //find the announcement with that id
            Post post = db.Posts.Find(id); 
            //return the comments for the above announcement 
            return PartialView("_CommentsTable", db.Comments.ToList().Where(x => x.Post == post));
        }

        
        //creates a new announcement (only lecturers)
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Lecturer")]
        public ActionResult AJAXCreate([Bind(Include = "PostText")] Post post)
        {
            
            if (ModelState.IsValid)
            {
                //gets the current user info
                string currentUserId = User.Identity.GetUserId();
                ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);
                post.User = currentUser;
                if (currentUserId != null)
                {
                    post.PostName = currentUser.UserName;
                }
                //get the current time
                post.PostTime = System.DateTime.Now;
                //add the new entry to the Posts table
                db.Posts.Add(post);
                db.SaveChanges();
            }
            //return partial view containing all announcements
            return PartialView("_PostTable", db.Posts.ToList());
        }

        //creates a new comment once it has the postId and the value which is sent from the form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AJAXComment(int? id, string value)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //find announcement
            Post post = db.Posts.Find(id);
            //creates new comment
            Comment comment = new Comment();
            //its post is the current post
            comment.Post = post;
            //its user is the current user
            string currentUserId = User.Identity.GetUserId();
            ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);
            if (currentUserId != null)
            {
                comment.CommentName = currentUser.UserName;
            }
            //give it the current time
            comment.CommentTime = System.DateTime.Now;
            if (value == "")
            {
                return HttpNotFound();
            }else
            {
                //give it the value that the user typed in the form
                comment.CommentText = value;
                //add new entry to Comments table
                db.Comments.Add(comment);
                db.SaveChanges();
                //return partial view containing the updated comments for the specific announcement
                return PartialView("_CommentsTable", db.Comments.ToList().Where(x => x.Post == post));
            }
        }
    }
}
