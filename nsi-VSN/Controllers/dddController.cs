using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using nsi_VSN.Models;

namespace nsi_VSN.Controllers
{
    public class dddController : ApiController
    {
        private vsndbEntities db = new vsndbEntities();
        [HttpPost]
        [ActionName("token")]
        public HttpResponseMessage Login([FromBody]LoginModel value)
        {

            var user = db.users.Where(w => w.username == value.username).FirstOrDefault();

            if (user == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else if (value.passwordHash == user.passwordHash)
            {
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

    }
}
