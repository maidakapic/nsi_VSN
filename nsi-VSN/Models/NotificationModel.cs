using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nsi_VSN.Models
{
    public class NotificationModel
    {
        public NotificationModel() { }

        public int notification_id { get; set; }
        public System.DateTime notificationTime { get; set; }
        public int notificationType_id { get; set; }
        public int notificator_id { get; set; }
        public string seen { get; set; }
        public int postNotification_id { get; set; }
    }
}