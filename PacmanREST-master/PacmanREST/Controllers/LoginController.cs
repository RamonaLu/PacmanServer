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
using PacmanREST.Models;

namespace PacmanREST.Controllers
{
    public class LoginController : ApiController
    {
        private pacmanAndroidNew_dbEntities db = new pacmanAndroidNew_dbEntities();

        // GET: api/Login
        public String GetLogin()
        {
            return "";
        }

        //GET api/Login/uName
        [Route("api/Login/{uName}/{uPass}")]
        [HttpGet]
        public IHttpActionResult GetLogin(String uName, String uPass)
        {
            var user = db.Pacman_carer_db.FirstOrDefault(i => i.name.Equals(uName));
            if (user.phone.ToString() == uPass )
            {
                return Ok(user);
            }
            else
            {
                return BadRequest();
            }
            
        }
    }
}
