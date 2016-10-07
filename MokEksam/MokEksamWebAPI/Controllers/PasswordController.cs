using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MokEksamWebAPI.Models;

namespace MokEksamWebAPI.Controllers
{
    public class PasswordController : ApiController
    {
        private DBcontext db = new DBcontext();

        [ResponseType(typeof(EndUser))]
        public IHttpActionResult CheckPassword(string endUserName, string password)
        {
            EndUser endUser = db.EndUser.Find(endUserName);
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
