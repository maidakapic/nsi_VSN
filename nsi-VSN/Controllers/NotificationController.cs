using nsi_VSN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace nsi_VSN.Controllers
{
    public class NotificationController : ApiController
    {
        private vsndbEntities db = new vsndbEntities();

        //get all notification from user
        // GET api/notification
        public IEnumerable<NotificationModel> GetNotificationFromUser(int userId)
        {
            List<notification> notifications = db.notifications.ToList<notification>();
            List<NotificationModel> notifikacije = new List<NotificationModel>();
            foreach (notification n in notifications) 
            {
                if (n.notificator_id == userId) 
                {
                    NotificationModel nm = new NotificationModel();

                    nm.notification_id = n.notification_id;
                    nm.notificationTime = n.notificationTime;
                    nm.notificationType_id = n.notificationType_id;
                    nm.notificator_id = n.notificator_id;
                    nm.postNotification_id = n.postNotification_id;
                    nm.seen = n.seen;

                    notifikacije.Add(nm);
                }
            }
            return notifikacije;
        }

        //get all notification from post
        // GET api/notification
        public IEnumerable<NotificationModel> GetNotificationFromPost(int postId)
        {
            List<notification> notifications = db.notifications.ToList<notification>();
            List<NotificationModel> notifikacije = new List<NotificationModel>();
            foreach (notification n in notifications)
            {
                if (n.notificator_id == postId)
                {
                    NotificationModel nm = new NotificationModel();

                    nm.notification_id = n.notification_id;
                    nm.notificationTime = n.notificationTime;
                    nm.notificationType_id = n.notificationType_id;
                    nm.notificator_id = n.notificator_id;
                    nm.postNotification_id = n.postNotification_id;
                    nm.seen = n.seen;

                    notifikacije.Add(nm);
                }
            }
            return notifikacije;
        }

        // GET api/notification/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/notification
        public void Post([FromBody]string value)
        {
        }

        // PUT api/notification/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/notification/5
        public void Delete(int id)
        {
        }
    }
}
