//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace nsi_VSN.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class like
    {
        public int likes_id { get; set; }
        public int likedBy_id { get; set; }
        public int likedPost_id { get; set; }
    
        public virtual user user { get; set; }
        public virtual post post { get; set; }
    }
}
