using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoom
{
    public class ChatRoom : IChat
    {
        public string Name { get; private set; }
        public List<Message> Messages { get; private set; }
        public List<User> Users { get; private set; } = new List<User>();

        public ChatRoom(string name)
        {
            Name = name;
            Messages = new List<Message>();
            Users = new List<User>();
        }

        // Method to allow users to send messages in a chat room
        public void SendMessage(User user, string text)
        {
            Message message = new Message(text, user);
            Messages.Add(message);
        }

        // Method to display all messages in the chat room
        public void DisplayMessages()
        {
            Console.WriteLine($"\n--- Chat Room: {Name} ---");
            foreach (var message in Messages)
            {
                Console.WriteLine($"{message.TimeStamp:HH:mm} {message.Sender.Username}: {message.Text}");
            }
            Console.WriteLine("-------------------------\n");
        }

        // Method to allow users to join an existing chat room
        public void Join(User user)
        {
            if (!Users.Contains(user))
                Users.Add(user);
        }

        // Method to display a list of all available chat rooms
        public void ListChatRooms(List<ChatRoom> chatRoomList)
        {
            for (int i = 0; i < chatRoomList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {chatRoomList[i].Name}");
            }
        }

        // Method to allow users to log out
        public void Logout(User user)
        {
            Users.Remove(user);
        }

        // Method to allow the chat room creator to delete the chat room
        public void DeleteChatRoom(ChatRoom chatRoom, List<ChatRoom> chatRoomList)
        {
            chatRoomList.Remove(chatRoom);
        }

        // Method to allow users to delete their messages
        public void DeleteMessage(Message message)
        {
            Messages.Remove(message);
        }
    }
}
