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
using WebApi.Models;

namespace WebApi.Controllers
{
    public class EndUsersController : ApiController
    {
        private dbContext db = new dbContext();

        // GET: api/EndUsers
        public IQueryable<EndUser> GetEndUser()
        {
            return db.EndUser;
        }

        // GET: api/EndUsers/5
        [ResponseType(typeof(EndUser))]
        public IHttpActionResult GetEndUser(string id)
        {
            EndUser endUser = db.EndUser.Find(id);
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

            db.EndUser.Add(endUser);

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
            EndUser endUser = db.EndUser.Find(id);
            if (endUser == null)
            {
                return NotFound();
            }

            db.EndUser.Remove(endUser);
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
            return db.EndUser.Count(e => e.user_name == id) > 0;
        }
    }
}