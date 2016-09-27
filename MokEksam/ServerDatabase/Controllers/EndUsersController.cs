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
using ServerDatabase.Models;

namespace ServerDatabase.Controllers
{
    public class EndUsersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/EndUsers
        public IQueryable<EndUser> GetEndUsers()
        {
            return db.EndUsers;
        }

        // GET: api/EndUsers/5
        [ResponseType(typeof(EndUser))]
        public IHttpActionResult GetEndUser(string id)
        {
            EndUser endUser = db.EndUsers.Find(id);
            if (endUser == null)
            {
                return NotFound();
            }

            return Ok(endUser);
        }

        // PUT: api/EndUsers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEndUser(string id, EndUser endUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != endUser.user_name)
            {
                return BadRequest();
            }

            db.Entry(endUser).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EndUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/EndUsers
        [ResponseType(typeof(EndUser))]
        public IHttpActionResult PostEndUser(EndUser endUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EndUsers.Add(endUser);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EndUserExists(endUser.user_name))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = endUser.user_name }, endUser);
        }

        // DELETE: api/EndUsers/5
        [ResponseType(typeof(EndUser))]
        public IHttpActionResult DeleteEndUser(string id)
        {
            EndUser endUser = db.EndUsers.Find(id);
            if (endUser == null)
            {
                return NotFound();
            }

            db.EndUsers.Remove(endUser);
            db.SaveChanges();

            return Ok(endUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EndUserExists(string id)
        {
            return db.EndUsers.Count(e => e.user_name == id) > 0;
        }
    }
}