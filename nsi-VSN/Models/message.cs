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
    
    public partial class message
    {
        public int message_id { get; set; }
        public string content { get; set; }
        public System.DateTime time { get; set; }
        public int sender_id { get; set; }
        public int receiver_id { get; set; }
    
        public virtual user user { get; set; }
        public virtual user user1 { get; set; }
    }
}
