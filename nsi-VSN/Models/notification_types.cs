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
    
    public partial class notification_types
    {
        public notification_types()
        {
            this.notifications = new HashSet<notification>();
        }
    
        public int notificationType_id { get; set; }
        public string textNotification { get; set; }
    
        public virtual ICollection<notification> notifications { get; set; }
    }
}