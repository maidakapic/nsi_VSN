using nsi_VSN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace nsi_VSN.Controllers
{
    public class LikeController : ApiController
    {
        private vsndbEntities db = new vsndbEntities();

        //get all like from post
        // GET api/like
        public IEnumerable<LikeModel> GetLikeFromPost(int postId)
        {
            List<like> likes = db.likes.ToList<like>();
            List<LikeModel> lajkovi = new List<LikeModel>();

            foreach(like l in likes)
            {
                if (l.likedPost_id == postId) 
                {
                    LikeModel lm = new LikeModel();

                    lm.likes_id = l.likes_id;
                    lm.likedPost_id = l.likedPost_id;
                    lm.likedBy_id = l.likedBy_id;
                    lajkovi.Add(lm);
                }
            }

            return lajkovi;
        }
        //get all like from user
        // GET api/like
        public IEnumerable<LikeModel> GetLikeFromuser(int userId)
        {
            List<like> likes = db.likes.ToList<like>();
            List<LikeModel> lajkovi = new List<LikeModel>();

            foreach (like l in likes)
            {
                if (l.likedPost_id == userId)
                {
                    LikeModel lm = new LikeModel();

                    lm.likes_id = l.likes_id;
                    lm.likedPost_id = l.likedPost_id;
                    lm.likedBy_id = l.likedBy_id;
                    lajkovi.Add(lm);
                }
            }

            return lajkovi;
        }

        // GET api/like/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/like
        public void Post([FromBody]string value)
        {
        }

        // PUT api/like/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/like/5
        public void Delete(int id)
        {
        }
    }
}
