using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using nsi_VSN.Models;

namespace nsi_VSN.Controllers
{
    public class POstsController : ApiController
    {
        private vsndbEntities db = new vsndbEntities();

        // GET api/POsts
        public IEnumerable<post> Getposts()
        {
            var posts = db.posts.Include(p => p.post_types).Include(p => p.user);
            return posts.AsEnumerable();
        }

        // GET api/POsts/5
        public post Getpost(int id)
        {
            post post = db.posts.Find(id);
            if (post == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return post;
        }

        // PUT api/POsts/5
        public HttpResponseMessage Putpost(int id, post post)
        {
            if (ModelState.IsValid && id == post.post_id)
            {
                db.Entry(post).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/POsts
        public HttpResponseMessage Postpost(post post)
        {
            if (ModelState.IsValid)
            {
                db.posts.Add(post);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, post);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = post.post_id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/POsts/5
        public HttpResponseMessage Deletepost(int id)
        {
            post post = db.posts.Find(id);
            if (post == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.posts.Remove(post);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, post);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}