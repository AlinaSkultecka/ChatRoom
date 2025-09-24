using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoom
{
    public enum UserRole
    {
        Admin,
        Regular
    }
    
    public class User
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public UserRole Role { get; private set; }
        public User(string username, string password, UserRole role = UserRole.Regular)
        {
            Username = username;
            Password = password;
            Role = role;
        }

        // Method to allow users to create a new profile
        public User RegisterUser(string username, string password)
        {
            return new User(username, password);
        }
      
        // Method to allow users to log in
        public bool Login(string username, string password, List<User> userList)
        {
            foreach (User user in userList)
            {
                if (user.Username == username && user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
