using System;
using System.Collections.Generic;

namespace WebSharp.Module
{
    public class User : BasicUser
    {
        public User(string userId, string userName, Gender userGender, string password, Weapon userWeapon, Home userHome,
             string emailAccount, string userMail, string userPhone) 
            : base(userId,userName, userGender, password,userWeapon,userHome,emailAccount,userMail,userPhone)
        {
        }

        // 用户字典
        private static Dictionary<string, User> _userDictionary = new Dictionary<string, User>()
        {
            {"abc",new User("abc","abc",Gender.Male,"123", Weapon.DoubleActionRevolver, Home.SaintDenis, "mail@mail.com","512123","13600000000") },
            {"HkingAuditore",new User("HkingAuditore","Hking Auditore",Gender.Male,"123", Weapon.CarcanoRifle, Home.Valentine, "mail@mail.com","512123","13600000000") },
            {"JohnMarston",new User("JohnMarston","John Marston",Gender.Male,"123", Weapon.M1899Pistol, Home.BeecherSHope, "mail@mail.com","512123","13600000000") },
            {"ArthurMorgan",new User("ArthurMorgan","Arthur Morgan",Gender.Male,"123", Weapon.MauserPistol | Weapon.SpringfieldRifle,Home.BlackWater, "mail@mail.com","512123","13600000000") },
            {"SadieAdler",new User("SadieAdler","Sadie Adler",Gender.Female,"123", Weapon.SchofieldRevolver,Home.Strawberry, "mail@mail.com","512123","13600000000") }
        };


        public static User FindUser(string userName)
        {
            try
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
            catch
            {
                return null;
            }

        }

        public static void AddUser(User user)
        {
            _userDictionary.Add(user.UserID,user);
        }

    }
}