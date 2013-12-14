using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DYEL.Models;

namespace DYEL.Controllers
{
    public class PostController : ApiController
    {
        private DYELContext db = new DYELContext();

        public IEnumerable<Post> GetPosts(String personId)
        {
            return  from post in db.Posts
                    join follow in db.Followers on post.PersonId equals follow.FolloweeId
                    where follow.FollowerId == personId
                    orderby post.Time descending
                    select post;
        }

        public IHttpActionResult PostNewPost([FromBody]Post newPost)
        {
            System.Diagnostics.Debug.WriteLine(newPost.PersonId + " " + newPost.Text + " "+ newPost.Focus);

            if (null != newPost
                && null != newPost.PersonId
                && null != db.People.Find(newPost.PersonId)
                && null != newPost.Text
                && null != newPost.Focus
                && null != db.Foci.Find(newPost.Focus))
            {
                newPost.PostId = Guid.NewGuid();
                newPost.Time = DateTime.Now;
                db.Posts.Add(newPost);
                db.SaveChanges();
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}