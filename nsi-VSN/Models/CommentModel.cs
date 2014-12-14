using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nsi_VSN.Models
{
    public class CommentModel
    {
        public CommentModel() { }

        public int comment_id { get; set; }
        public int commentedPost_id { get; set; }
        public int commentedBy_id { get; set; }
        public string commentText { get; set; }
        public string commentedBy_username { get; set; }
    }
}