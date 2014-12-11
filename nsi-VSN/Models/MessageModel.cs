using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nsi_VSN.Models
{
    public class MessageModel
    {
        public MessageModel() { }
        
        public int message_id { get; set; }
        public string content { get; set; }
        public System.DateTime time { get; set; }
        public int sender_id { get; set; }
        public int receiver_id { get; set; }
    }
}