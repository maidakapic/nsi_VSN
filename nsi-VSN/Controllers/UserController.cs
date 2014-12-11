using nsi_VSN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace nsi_VSN.Controllers
{
    public class UserController : ApiController
    {
        private vsndbEntities db = new vsndbEntities();
      
        // GET api/user
        public IEnumerable<UserModel> Getusers()
        {
            List<user> users = db.users.ToList<user>();
            List<UserModel> korisnici = new List<UserModel>();

            foreach(user u in users)
            {
                UserModel um = new UserModel();
                um.user_id = u.user_id;
                um.firstName = u.firstName;
                um.lastName = u.lastName;
                um.profileImage = u.profileImage;
                um.username = u.username;
                um.passwordHash = u.passwordHash;
                um.salt = u.salt;
                um.livingPlace = u.livingPlace;
                um.mail = u.mail;
                um.banned = u.banned;
                um.birthDate = u.birthDate;
                um.userRole = u.userRole;
                um.active = u.active;

                um.comments= db.comments.Where(comment => comment.commentedBy_id==u.user_id).Count();
                um.likes = db.likes.Where(like => like.likedBy_id == u.user_id).Count();
                um.messages = db.messages.Where(message => message.sender_id == u.user_id).Count();

                korisnici.Add(um);
            }

            return korisnici.AsEnumerable();
        }

        // GET api/user/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/user
        public void Post([FromBody]string value)
        {
        }

        // PUT api/user/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/user/5
        public void Delete(int id)
        {
        }
    }
}
