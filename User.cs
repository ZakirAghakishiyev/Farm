using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm
{
    internal class User:Base
    {
        private static int AutoIncremendId = 1;
        public User(string userName, string password, int userId, string userType)
        {
            UserName = userName;
            Password = password;
            Id = AutoIncremendId++;
            UserId = userId;
            UserType = userType;
        }

        public string UserType { set; get; }
        public string UserName {  get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }

    }
}
