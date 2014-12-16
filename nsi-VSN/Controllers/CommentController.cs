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

        private vsndbEntities1 db = new vsndbEntities1();

        //get all comment from post
        // GET api/comment

        [HttpGet]
        [ActionName("GetCommentFromPost")]
        public IEnumerable<CommentModel> GetCommentFromPost(int postId)
        {
            List<comment> comments = db.comments.Where(b => b.commentedPost_id == postId).ToList<comment>();
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

                    cm.commentedBy_username = c.user.username;

                    komentari.Add(cm);
                }
            }
            return komentari;
        }

        //get all comment from user
        // GET api/comment
       
        [HttpGet]
        [ActionName("GetCommentFromUser")]
        public IEnumerable<CommentModel> GetCommentFromUser(int userId)
        {
            List<comment> comments = db.comments.Where(b => b.commentedBy_id == userId).ToList<comment>();
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

                    cm.commentedBy_username = c.user.username;

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
        [HttpPost]
        [ActionName("PostComment")]
        public HttpResponseMessage PostComment([FromBody]CommentModel comment)
        {
            comment c = new comment();
            c.commentedBy_id = comment.commentedBy_id;
            c.commentedPost_id = comment.commentedPost_id;
            c.commentText = comment.commentText;

            db.comments.Add(c);
            db.SaveChanges();
            
            NotificationModel nc = new NotificationModel();
            nc.notificator_id = c.commentedBy_id;
            nc.postNotification_id = c.commentedPost_id;
            nc.notificationType_id = 2;
            nc.notificationTime = DateTime.Now;

            NotificationController not = new NotificationController();
            not.PostNotifiction(nc);

            return Request.CreateResponse(HttpStatusCode.OK, c);

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
