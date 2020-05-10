using LibraryProject.DataAccees;
using LibraryProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace LibraryProject.Controllers
{
    
    public class SignupController : ApiController
    {
        private Data db = new Data();
        public IHttpActionResult Postsignup([FromBody]UserDetails userDetails)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.signup(userDetails);

            return Ok(200);

        }
    }
}
