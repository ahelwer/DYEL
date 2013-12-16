using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using DYEL.Models;

namespace DYEL.Controllers
{
    public class SessionController : ApiController
    {
        private DYELContext db = new DYELContext();

        public Session GetNewSession(String PersonId, String Password)
        {
            Person person = db.People.Find(PersonId);

            if (null != person && person.Password == Password)
            {
                Session newSession = new Session
                {
                    SessionId = Guid.NewGuid(),
                    PersonId = PersonId,
                    StartTime = DateTime.Now
                };
                db.Sessions.Add(newSession);
                db.SaveChanges();
                return newSession;
            }
            else
            {
                throw new HttpException("Invalid login");
            }
        }

        public IHttpActionResult DeleteSession(Guid SessionId)
        {
            Session toDelete = db.Sessions.Find(SessionId);

            if (null != toDelete)
            {
                db.Sessions.Remove(toDelete);
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