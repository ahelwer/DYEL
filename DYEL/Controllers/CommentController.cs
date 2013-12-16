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
    public class CommentController : ApiController
    {
        private DYELContext db = new DYELContext();

        public IEnumerable<Comment> GetComments(String personId, Guid postId)
        {
            Post post = db.Posts.Find(postId);

            if (null != post && null != db.Followers.Find(personId, post.PersonId))
            {
                return from comment in db.Comments
                       where comment.PostId == postId
                       orderby comment.Time ascending
                       select comment;
            }
            else
            {
                return null;
            }
        }

        public IHttpActionResult PostNewComment([FromBody]Comment newComment)
        {
            newComment.CommentId = Guid.NewGuid();
            newComment.Time = DateTime.Now;

            db.Comments.Add(newComment);
            db.SaveChanges();
            return Ok();
        }
    }
}