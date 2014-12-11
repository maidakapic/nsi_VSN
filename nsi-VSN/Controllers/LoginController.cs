using nsi_VSN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace nsi_VSN.Controllers
{
    public class LoginController : ApiController
    {

        private vsndbEntities db = new vsndbEntities();

        // GET api/login
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/login/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/login
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

        private object HttpResponseMessage(HttpStatusCode httpStatusCode)
        {
            throw new NotImplementedException();
        }

        // PUT api/login/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/login/5
        public void Delete(int id)
        {
        }

        public string user { get; set; }
    }
}
