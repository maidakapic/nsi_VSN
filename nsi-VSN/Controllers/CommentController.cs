using nsi_VSN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace nsi_VSN.Controllers
{
    public class CommentController : ApiController
    {

        private vsndbEntities db = new vsndbEntities();

        //get all comment from post
        // GET api/comment
        public IEnumerable<CommentModel> GetCommentFrompost(int postId)
        {
            List<comment> comments = db.comments.ToList<comment>();
            List<CommentModel> komentari = new List<CommentModel>();
            foreach (comment c in comments) 
            {
                if (c.commentedPost_id == postId) 
                {
                    CommentModel cm = new CommentModel();
                    cm.comment_id = c.comment_id;
                    cm.commentedBy_id = c.commentedBy_id;
                    cm.commentedPost_id = c.commentedPost_id;
                    cm.commentText = c.commentText;
                    komentari.Add(cm);
                }
            }
            return komentari;
        }

        //get all comment from user
        // GET api/comment
        public IEnumerable<CommentModel> GetCommentFromUser(int userId)
        {
            List<comment> comments = db.comments.ToList<comment>();
            List<CommentModel> komentari = new List<CommentModel>();
            foreach (comment c in comments)
            {
                if (c.commentedBy_id == userId)
                {
                    CommentModel cm = new CommentModel();
                    cm.comment_id = c.comment_id;
                    cm.commentedBy_id = c.commentedBy_id;
                    cm.commentedPost_id = c.commentedPost_id;
                    cm.commentText = c.commentText;
                    komentari.Add(cm);
                }
            }
            return komentari;
        }

        // GET api/comment/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/comment
        public void Post([FromBody]string value)
        {
        }

        // PUT api/comment/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/comment/5
        public void Delete(int id)
        {
        }
    }
}
