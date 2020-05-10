using LibraryProject.DataAccees;
using LibraryProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LibraryProject.Controllers
{
    public class LoginController : ApiController
    {
        private Data db = new Data();
        public IHttpActionResult PostLogin([FromBody]Login login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Validate validate = db.loginvalidate(login);

            return Ok(validate);

        }
    }
}
