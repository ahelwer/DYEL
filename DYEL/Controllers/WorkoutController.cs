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
    public class WorkoutController : ApiController
    {
        private DYELContext db = new DYELContext();

        public IEnumerable<Workout> GetWorkouts(String personId)
        {
            return from workout in db.Workouts
                   join follow in db.Followers on workout.PersonId equals follow.FolloweeId
                   where follow.FollowerId == personId
                   where DateTime.Compare(DateTime.Now, workout.Time) <= 0
                   orderby workout.Time ascending
                   select workout;
        }

        public IHttpActionResult PostNewWorkout([FromBody]Workout newWorkout)
        {
            if (null != newWorkout
                && null != newWorkout.PersonId
                && null != db.People.Find(newWorkout.PersonId)
                && null != newWorkout.LocationId
                && null != db.FitnessLocations.Find(newWorkout.LocationId)
                && null != newWorkout.Time
                && DateTime.Compare(DateTime.Now, newWorkout.Time) <= 0
                && null != newWorkout.Focus
                && null != db.Foci.Find(newWorkout.Focus))
            {
                newWorkout.WorkoutId = Guid.NewGuid();
                db.Workouts.Add(newWorkout);

                // A person always joins their own workout
                Joiner identity = new Joiner
                {
                    PersonId = newWorkout.PersonId,
                    WorkoutId = newWorkout.WorkoutId,
                    Status = Response.Accepted
                };
                db.Joiners.Add(identity);

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