using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatApp.Models.MessageModels
{
    public class Message
    {
        public string Text { get; set; }
        public string Sender { get; set; }
        public string Connection_id{ get; set; }
        public int TypeMessage { get; set; }
        public Message(string t , string sender,string conn_id , int type)
        {
            this.Text = t;
            this.Sender = sender;
            this.Connection_id = conn_id;
            this.TypeMessage = type;
        }
    }
}