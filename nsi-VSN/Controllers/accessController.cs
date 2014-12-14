using nsi_VSN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace nsi_VSN.Controllers
{
    public class accessController : ApiController
    {
        private vsndbEntities db = new vsndbEntities();

        [HttpGet]
        [ActionName("token")]
        public HttpResponseMessage haha()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "dsa");
        }

        [HttpPost]
        [ActionName("token")]
        public HttpResponseMessage Login([FromBody]LoginModel value)
        {

            var user = db.users.Where(w => w.username == value.username).FirstOrDefault();

            if (user == null)
            {
                
                return Request.CreateResponse(HttpStatusCode.BadRequest, "{'error_code':1001, 'message':'Nema ga'}");
            }
            else if (value.passwordHash == user.passwordHash)
            {
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "dsa");
        }
    }
}
