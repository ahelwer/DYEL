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
    public class AttendsController : ApiController
    {
        private DYELContext db = new DYELContext();

        public IEnumerable<Attends> GetAttends(String personId)
        {
            return from attend in db.Attends
                   where attend.PersonId == personId
                   select attend;
        }

        public IHttpActionResult PostNewAttend([FromBody]Attends attend)
        {
            System.Diagnostics.Debug.WriteLine("creating attends for " + attend.PersonId + " " + attend.LocationId);

            if (null == db.Attends.Find(attend.PersonId, attend.LocationId)
                && null != db.People.Find(attend.PersonId)
                && null != db.FitnessLocations.Find(attend.LocationId))
            {
                db.Attends.Add(attend);
                db.SaveChanges();
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }

        public IHttpActionResult DeleteAttend([FromUri]Attends attend)
        {
            if (null != attend
                && null != attend.PersonId
                && null != attend.LocationId)
            {
                Attends actual = db.Attends.Find(attend.PersonId, attend.LocationId);
                if (null != actual)
                {
                    db.Attends.Remove(actual);
                    db.SaveChanges();
                    return Ok();
                }
            }
            return Unauthorized();
        }
    }
}