using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoom
{
    public interface IChat
    {
        void SendMessage(User user, string text);
        void DisplayMessages();
    }
}
