using nsi_VSN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace nsi_VSN.Controllers
{
    public class PostController : ApiController
    {

        private vsndbEntities db = new vsndbEntities();
            
        // GET api/post
       
        public IEnumerable<PostModel> GetPosts()
        {
            List<post> postList = db.posts.ToList();
            List<PostModel> postovi = new List<PostModel>();

            foreach(post p in postList)
            {
                PostModel pm = new PostModel();
                pm.post_id = p.post_id;
                pm.title = p.title;
                pm.postText = p.postText;
                pm.postImage = p.postImage;
                pm.publisher_id = p.publisher_id;
                pm.postType_id = p.postType_id;
                pm.publishTime = p.publishTime;
                pm.visible = p.visible;

                pm.comments = db.comments.Where(comment => comment.commentedPost_id == p.post_id).Count();
                pm.likes = db.likes.Where(like => like.likedPost_id == p.post_id).Count();

                postovi.Add(pm);
            }
            return postovi.AsEnumerable();
        }
        //get all posts from user
        // GET api/posts
        public IEnumerable<PostModel> GetPostsFromUser(int userId)
        {
            List<post> posts = db.posts.ToList<post>();
            List<PostModel> postovi = new List<PostModel>();
            foreach (post p in posts)
            {
                if (p.publisher_id == userId)
                {
                    PostModel pm = new PostModel();
                    pm.post_id = p.post_id;
                    pm.publisher_id = p.publisher_id;
                    pm.postType_id = p.postType_id;
                    pm.postImage = p.postImage;
                    pm.postText = p.postText;
                    pm.publishTime = p.publishTime;
                    pm.title = p.title;
                    postovi.Add(pm);
                }
            }
            return postovi;
        }

        // get one post with id
        // GET api/post/5
        public IEnumerable<PostModel> Get(int id)
        {
            List<post> posts = db.posts.ToList<post>();
            List<PostModel> postovi = new List<PostModel>();
            foreach (post p in posts)
            {
                if (p.post_id == id)
                {
                    PostModel pm = new PostModel();
                    pm.post_id = p.post_id;
                    pm.publisher_id = p.publisher_id;
                    pm.postType_id = p.postType_id;
                    pm.postImage = p.postImage;
                    pm.postText = p.postText;
                    pm.publishTime = p.publishTime;
                    pm.title = p.title;
                    postovi.Add(pm);
                }
            }
            return postovi;
           
        }

        // POST api/post
        public void Post([FromBody]PostModel value)
        {
        }

        // PUT api/post/5
        public void Put(int id, [FromBody]PostModel value)
        {
        }

        // DELETE api/post/5
        public void Delete(int id)
        {
        }
    }
}
