using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nsi_VSN.Models
{
    public class UserModel
    {
        public UserModel() { }

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
        public int comments { get; set; }
        public int likes { get; set; }
        public int messages { get; set; }
        public int notifications { get; set; }
        public int posts { get; set; }
    }
}