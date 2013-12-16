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
    public class PersonController : ApiController
    {
        private DYELContext db = new DYELContext();

        public Person GetPerson(String requestedPerson)
        {
            Person requested = db.People.Find(requestedPerson);
            requested.Password = null;
            return requested;
        }

        public IEnumerable<Person> GetPeople()
        {
            IEnumerable<Person> people = from person in db.People
                                         orderby person.PersonId ascending
                                         select person;
            
            foreach(Person person in people)
            {
                person.Password = null;
            }

            return people;
        }

        public Session PostNewPerson([FromBody]Person person)
        {
            if (null != person
                && null != person.PersonId
                && null == db.People.Find(person.PersonId)
                && 0 <= person.Age
                && null != person.Focus
                && null != db.Foci.Find(person.Focus))
            {
                db.People.Add(person);

                // A person always follows themselves
                Follower identity = new Follower
                {
                    FollowerId = person.PersonId,
                    FolloweeId = person.PersonId
                };
                db.Followers.Add(identity);

                // Create new session
                Session newSession = new Session
                {
                    SessionId = Guid.NewGuid(),
                    PersonId = person.PersonId,
                    StartTime = DateTime.Now
                };
                db.Sessions.Add(newSession);

                db.SaveChanges();

                return newSession;
            }
            else
            {
                throw new HttpException("Invalid user creation");
            }
        }
    }
}