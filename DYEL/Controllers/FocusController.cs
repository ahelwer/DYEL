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
    public class FocusController : ApiController
    {
        private DYELContext db = new DYELContext();

        public IEnumerable<Focus> GetFoci()
        {
            return from focus in db.Foci
                   orderby focus.FocusId ascending
                   select focus;
        }

        public IHttpActionResult PostNewFocus([FromBody]Focus focus)
        {
            if (null != focus
                && null != focus.FocusId
                && null == db.Foci.Find(focus.FocusId)
                && null != focus.Description)
            {
                db.Foci.Add(focus);
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