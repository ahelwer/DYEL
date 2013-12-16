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
    public class FollowerController : ApiController
    {
        private DYELContext db = new DYELContext();

        public IEnumerable<Follower> GetFollowers(String followeeId)
        {
            return from follow in db.Followers
                   where follow.FolloweeId == followeeId
                   orderby follow.FollowerId ascending
                   select follow;
        }

        public IEnumerable<Follower> GetFollowing(String followerId)
        {
            return from follow in db.Followers
                   where follow.FollowerId == followerId
                   orderby follow.FolloweeId ascending
                   select follow;
        }
        public IHttpActionResult PostNewFollow([FromBody]Follower follow)
        {
            if (null == db.Followers.Find(follow.FollowerId, follow.FolloweeId)
                && null != db.People.Find(follow.FollowerId)
                && null != db.People.Find(follow.FolloweeId))
            {
                db.Followers.Add(follow);
                db.SaveChanges();
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }

        public IHttpActionResult DeleteFollow([FromUri]Follower follow)
        {
            if (null != follow
                && null != follow.FollowerId
                && null != follow.FolloweeId)
            {
                Follower actual = db.Followers.Find(follow.FollowerId, follow.FolloweeId);
                if (null != actual)
                {
                    db.Followers.Remove(actual);
                    db.SaveChanges();
                    return Ok();
                }
            }
            return Unauthorized();
        }
    }
}