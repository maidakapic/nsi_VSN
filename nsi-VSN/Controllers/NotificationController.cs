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
        private vsndbEntities1 db = new vsndbEntities1();

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
                    nm.notificationTime = n.notificationTime.Value;
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
        [HttpPost]
        [ActionName("PostNotifiction")]
        public HttpResponseMessage PostNotifiction([FromBody] NotificationModel ntf)
        {
            notification n = new notification();
            n.notificator_id = ntf.notificator_id;
            n.notificationType_id = ntf.notificationType_id;
            n.postNotification_id = ntf.postNotification_id;
            n.seen = ntf.seen;

            
            db.notifications.Add(n);
            db.SaveChanges();
            
            return Request.CreateResponse(HttpStatusCode.OK, n);
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
