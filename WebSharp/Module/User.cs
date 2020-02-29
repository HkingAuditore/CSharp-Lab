using System.Collections.Generic;

namespace WebSharp.Module
{
    public class User : BasicUser
    {
        public User(string userName, Gender userGender, string password) : base(userName, userGender, password)
        {
        }

        // 用户字典
        private static Dictionary<string, User> _userDictionary = new Dictionary<string, User>()
        {
            {"abc",new User("abc",Gender.Male,"123") },
            {"Hking Auditore",new User("Hking Auditore",Gender.Male,"123") },
            {"Ezio Auditore",new User("Ezio Auditore",Gender.Male,"123") },
            {"John Marston",new User("John Marston",Gender.Male,"123") },
            {"Arthur Morgan",new User("Arthur Morgan",Gender.Male,"123") }
        };


        public static User FindUser(string userName)
        {
            if (User._userDictionary.ContainsKey(userName))
            {
                return User._userDictionary[userName];
            }
            else
            {
                return null;
            }

        }

    }
}