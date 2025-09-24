using System;
using System.Security.Cryptography.X509Certificates;

namespace ChatRoom
{
    internal class Program
    {
        private static List<User> users = new List<User>();
        private static List<ChatRoom> chatRooms = new List<ChatRoom>();
        private static User? currentUser = null;

        // Simple user interface in the console
        static void Main(string[] args)
        {
            while (true)
            {
                if (currentUser == null)
                {
                    DisplayMenu();
                    string choice = Console.ReadLine() ?? "";
                    switch (choice)
                    {
                        case "1": Register(); break;
                        case "2": Login(); break;
                        case "0": return;
                        default: Console.WriteLine("Invalid option"); break;
                    }
                }
                else
                {
                    DisplayUserMenu();
                    string choice = Console.ReadLine() ?? "";
                    switch (choice)
                    {
                        case "1": CreateChatRoom(); break;
                        case "2": EnterChatRoom(); break;
                        case "3": currentUser = null; Console.WriteLine("Logged out."); break;
                        case "0": return;
                        default: Console.WriteLine("Invalid option"); break;
                    }
                }
            }
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("\n=== Welcome to ChatRoom ===");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("0. Exit");
            Console.Write("Choose: ");
        }

        private static void DisplayUserMenu()
        {
            Console.WriteLine($"\n=== Hello {currentUser!.Username} ===");
            Console.WriteLine("1. Create Chat Room");
            Console.WriteLine("2. Join Chat Room");
            Console.WriteLine("3. Logout");
            Console.WriteLine("0. Exit");
            Console.Write("Choose: ");
        }

        private static void Register()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine() ?? "";
            Console.Write("Enter password: ");
            string password = Console.ReadLine() ?? "";

            if (users.Exists(u => u.Username == username))
            {
                Console.WriteLine("Username already exists!");
                return;
            }

            var user = new User(username, password);
            users.Add(user);
            Console.WriteLine("Registration successful!");
        }

        private static void Login()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine() ?? "";
            Console.Write("Enter password: ");
            string password = Console.ReadLine() ?? "";

            var tempUser = new User("", ""); // placeholder for method call
            if (tempUser.Login(username, password, users))
            {
                currentUser = users.Find(u => u.Username == username);
                Console.WriteLine($"Welcome back, {currentUser!.Username}!");
            }
            else
            {
                Console.WriteLine("Invalid credentials!");
            }
        }

        private static void CreateChatRoom()
        {
            Console.Write("Enter chat room name: ");
            string name = Console.ReadLine() ?? "";
            var room = new ChatRoom(name);
            chatRooms.Add(room);
            Console.WriteLine($"Chat room '{name}' created.");
        }

        private static void EnterChatRoom()
        {
            if (chatRooms.Count == 0)
            {
                Console.WriteLine("No chat rooms available.");
                return;
            }

            Console.WriteLine("Available chat rooms:");
            for (int i = 0; i < chatRooms.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {chatRooms[i].Name}");
            }
            Console.Write("Choose a room: ");
            if (int.TryParse(Console.ReadLine(), out int choice) &&
                choice > 0 && choice <= chatRooms.Count)
            {
                var room = chatRooms[choice - 1];
                room.Join(currentUser!);
                ChatLoop(room);
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }

        private static void ChatLoop(ChatRoom room)
        {
            while (true)
            {
                room.DisplayMessages();
                Console.WriteLine("Type a message (or type '/exit' to leave the chat): ");
                string msg = Console.ReadLine() ?? "";
                if (msg == "/exit") break;
                room.SendMessage(currentUser!, msg);
            }
        }
    }
}   

