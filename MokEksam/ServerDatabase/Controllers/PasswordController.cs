using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ServerDatabase.Models;

namespace ServerDatabase.Controllers
{
    public class PasswordController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [ResponseType(typeof(void))]
        public IHttpActionResult CheckPassword(string endUserName, string password)
        {
            EndUser endUser = db.EndUsers.Find(endUserName);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (endUser == null)
            {
                return NotFound();
            }

            if (endUser.user_password != password)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }
            
        }
    }
}
