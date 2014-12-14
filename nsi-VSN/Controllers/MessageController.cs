using nsi_VSN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace nsi_VSN.Controllers
{
    public class MessageController : ApiController
    {
        private vsndbEntities db = new vsndbEntities();
       
        //get all messages from user (sender)
        // GET api/message
        [HttpGet]
        [ActionName("GetMessagesFromSender")]
        public IEnumerable<MessageModel> GetMessagesFromSender(int senderID)
        {
            List<message> messages = db.messages.Where(b => b.sender_id == senderID).ToList<message>();
            List<MessageModel> poruke = new List<MessageModel>();

            foreach (message m in messages) 
            {
                if (m.sender_id == senderID) 
                {
                    MessageModel mm = new MessageModel();

                    mm.message_id = m.message_id;
                    mm.receiver_id = m.receiver_id;
                    mm.sender_id = m.sender_id;
                    mm.time = m.time;
                    mm.content = m.content;

                    mm.reciver_name = m.user.username;
                    mm.sender_name = m.user1.username;

                    poruke.Add(mm);

                }
            }
            return poruke;
        }

        //get all messages from user (reciver)
        // GET api/message
        [HttpGet]
        [ActionName("GetMessagesFromReciver")]
        public IEnumerable<MessageModel> GetMessagesFromReciver(int reciverID)
        {
         
            List<message> messages = db.messages.Where(b => b.receiver_id == reciverID).ToList<message>();
            List<MessageModel> poruke = new List<MessageModel>();

            foreach (message m in messages)
            {
                if (m.receiver_id == reciverID)
                {
                    MessageModel mm = new MessageModel();

                    mm.message_id = m.message_id;
                    mm.receiver_id = m.receiver_id;
                    mm.sender_id = m.sender_id;
                    mm.time = m.time;
                    mm.content = m.content;

                    mm.reciver_name = m.user.username;
                    mm.sender_name = m.user1.username;

                    poruke.Add(mm);

                }
            }
            return poruke;
        }

        // GET api/message/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/message
        public void Post([FromBody]string value)
        {
        }

        // PUT api/message/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/message/5
        public void Delete(int id)
        {
        }
    }
}
