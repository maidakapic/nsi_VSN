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
    
    public partial class user
    {
        public user()
        {
            this.comments = new HashSet<comment>();
            this.likes = new HashSet<like>();
            this.messages = new HashSet<message>();
            this.messages1 = new HashSet<message>();
            this.notifications = new HashSet<notification>();
            this.posts = new HashSet<post>();
        }
    
        public int user_id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public byte[] profileImage { get; set; }
        public Nullable<System.DateTime> birthDate { get; set; }
        public string username { get; set; }
        public string passwordHash { get; set; }
        public string salt { get; set; }
        public string livingPlace { get; set; }
        public string active { get; set; }
        public string banned { get; set; }
        public string mail { get; set; }
        public int userRole { get; set; }
    
        public virtual ICollection<comment> comments { get; set; }
        public virtual ICollection<like> likes { get; set; }
        public virtual ICollection<message> messages { get; set; }
        public virtual ICollection<message> messages1 { get; set; }
        public virtual ICollection<notification> notifications { get; set; }
        public virtual ICollection<post> posts { get; set; }
        public virtual role role { get; set; }
    }
}
