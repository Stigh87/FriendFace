using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendFace
{
    internal class User
    {
        public string _username;
        public string _name;
        public string _email;
        public int _age;
        public int _id;
        public List<User> _friends; 

        public User(int id, string username, string name, string email, int age)
        {
            _username = username;
            _name = name;
            _email = email;
            _age = age;
            _id = id;
            _friends = new List<User>();

        }

        public void addFriend(User user)
        {
            _friends.Add(user);
        }

        internal void removeFriend(User user)
        {
            _friends.Remove(user);
        }
    }
}


