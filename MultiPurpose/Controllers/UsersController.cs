using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Description;
using MultiPurpose.Context;
using MultiPurpose.Helper;
using MultiPurpose.Models;

namespace MultiPurpose.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/Users/5
        [Route("login")]
        [Authentication]
        public IHttpActionResult GetUsers()
        {
            string username = Thread.CurrentPrincipal.Identity.Name;
            return Ok(username);
        }

        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}