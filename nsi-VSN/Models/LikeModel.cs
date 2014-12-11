using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nsi_VSN.Models
{
    public class LikeModel
    {
        public LikeModel() { }

        public int likes_id { get; set; }
        public int likedBy_id { get; set; }
        public int likedPost_id { get; set; }
    }
}