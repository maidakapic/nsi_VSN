using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nsi_VSN.Models
{
    public class PostModel
    {
    
        public int post_id { get; set; }
        public string title { get; set; }
        public string postText { get; set; }
        public byte[] postImage { get; set; }
        public int publisher_id { get; set; }
        public int postType_id { get; set; }
        public int comments { get; set; }
        public int likes {get; set; }
        public int notifications { get; set; }
        public System.DateTime publishTime { get; set; }
        public string visible { get; set; }
    
     
    }
}