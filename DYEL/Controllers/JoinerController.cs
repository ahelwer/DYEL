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
    public class JoinerController : ApiController
    {
        private DYELContext db = new DYELContext();

        public IDictionary<Guid, IEnumerable<Joiner>> GetJoinRequests(String personId)
        {
            return (from joiner in db.Joiners
                   join workout in db.Workouts on joiner.WorkoutId equals workout.WorkoutId
                   where workout.PersonId == personId
                   where DateTime.Compare(DateTime.Now, workout.Time) <= 0
                   where joiner.Status != Response.Rejected
                   group joiner by joiner.WorkoutId into requests
                   select new KeyValuePair<Guid, IEnumerable<Joiner>>(requests.Key, requests))
                   .ToDictionary(x => x.Key, x => x.Value);
        }

        public IEnumerable<Joiner> GetWorkoutJoiners(Guid workoutId)
        {
            return from joiner in db.Joiners
                   where joiner.WorkoutId == workoutId
                   orderby joiner.PersonId ascending
                   select joiner;
        }

        public IHttpActionResult PostNewJoinRequest([FromBody]Joiner newRequest)
        {
            if (null != newRequest
                && null != newRequest.PersonId
                && null != db.People.Find(newRequest.PersonId)
                && null != newRequest.WorkoutId
                && null != db.Workouts.Find(newRequest.WorkoutId)
                && null == db.Joiners.Find(newRequest.PersonId, newRequest.WorkoutId))
            {
                Workout workout = db.Workouts.Find(newRequest.WorkoutId);
                if (workout.PersonId == newRequest.PersonId)
                    newRequest.Status = Response.Accepted;
                else
                    newRequest.Status = Response.Pending;
                db.Joiners.Add(newRequest);
                db.SaveChanges();
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }

        public IHttpActionResult PutResponse([FromBody]Joiner response)
        {
            System.Diagnostics.Debug.WriteLine(response.PersonId + " " + response.WorkoutId + " " + response.Status);
            if (null != response
                && Response.Pending != response.Status
                && null != response.PersonId
                && null != db.People.Find(response.PersonId)
                && null != response.WorkoutId
                && null != db.Workouts.Find(response.WorkoutId)
                && null != db.Joiners.Find(response.PersonId, response.WorkoutId))
            {
                Joiner actual = db.Joiners.Find(response.PersonId, response.WorkoutId);
                actual.Status = response.Status;
                db.SaveChanges();
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }

        public IHttpActionResult DeleteJoin([FromUri]Joiner request)
        {
            if (null != request
                && null != request.PersonId
                && null != db.People.Find(request.PersonId)
                && null != request.WorkoutId
                && null != db.Workouts.Find(request.WorkoutId)
                && null != db.Joiners.Find(request.PersonId, request.WorkoutId))
            {
                Joiner actual = db.Joiners.Find(request.PersonId, request.WorkoutId);
                db.Joiners.Remove(actual);
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