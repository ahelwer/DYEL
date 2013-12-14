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
                                         orderby person.Id ascending
                                         select person;
            
            foreach(Person person in people)
            {
                person.Password = null;
            }

            return people;
        }

        public IHttpActionResult GetLogin(String id, String password)
        {
            Person person = db.People.Find(id);

            if (null != person && person.Password == password)
            {
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }

        public IHttpActionResult PostNewPerson([FromBody]Person person)
        {
            System.Diagnostics.Debug.WriteLine(person.Id + " " + person.Password + " " + person.Age + " " + person.Gender + " " + person.Focus);
            if (null != person
                && null != person.Id
                && null == db.People.Find(person.Id)
                && 0 <= person.Age
                && null != person.Focus
                && null != db.Foci.Find(person.Focus))
            {
                System.Diagnostics.Debug.WriteLine("reached");
                db.People.Add(person);

                // A person always follows themselves
                Follower identity = new Follower
                {
                    FollowerId = person.Id,
                    FolloweeId = person.Id
                };
                db.Followers.Add(identity);
                System.Diagnostics.Debug.WriteLine("reached");


                db.SaveChanges();
                System.Diagnostics.Debug.WriteLine("reached");

                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}