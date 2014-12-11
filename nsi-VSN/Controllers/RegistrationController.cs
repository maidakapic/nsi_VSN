using nsi_VSN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace nsi_VSN.Controllers
{
    public class RegistrationController : ApiController
    {
        private vsndbEntities db = new vsndbEntities();

        // GET api/registration
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/registration/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/registration
        public void Post([FromBody]UserModel value)
        {
            user user = new user();
            user.firstName = value.firstName;
            user.lastName = value.lastName;
            user.birthDate = value.birthDate.Value;
            user.profileImage = value.profileImage;
            user.username = value.username;
            user.passwordHash = value.passwordHash;
            user.salt = value.salt;
            user.livingPlace = value.livingPlace;
            user.mail = value.mail;
            user.active = null; //profil treba aktivirati
            user.banned = null;
            user.userRole = 2; //obicni korisnik
            db.users.Add(user);

            db.SaveChanges();

        }

        // PUT api/registration/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/registration/5
        public void Delete(int id)
        {
        }
    }
}
