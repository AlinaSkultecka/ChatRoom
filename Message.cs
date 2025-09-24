using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoom
{
    public class Message
    {
        public string Text { get; private set; }
        public DateTime TimeStamp { get; private set; }
        public User Sender { get; private set; }
        
        public Message (string text, User sender)
        {
            Text = text; 
            Sender = sender;
            TimeStamp = DateTime.Now;
        }

        // Method to allow users to edit their messages
        public void UpdateText(string newText)
        {
            Text = newText;
            TimeStamp = DateTime.Now;
        }
    }
}
