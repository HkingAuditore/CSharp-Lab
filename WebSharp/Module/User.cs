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

        public static Dictionary<string, User> UserDictionary { get; } = new Dictionary<string, User>()
        {
            // {
            //     "abc",
            //     new User("abc", "abc", Gender.Male, "123", Weapon.DoubleActionRevolver, Home.SaintDenis,
            //         "mail@mail.com", "512123", "13600000000")
            // },
            // {
            //     "HkingAuditore",
            //     new User("HkingAuditore", "Hking Auditore", Gender.Male, "123", Weapon.CarcanoRifle, Home.Valentine,
            //         "mail@mail.com", "512123", "13600000000")
            // },
            {
                "John",
                new User("John", "John Marston", Gender.Male, "123", Weapon.M1899Pistol, Home.BeecherSHope,
                    "mail@mail.com", "512123", "13600000000")
            },
            {
                "Arthur",
                new User("Arthur", "Arthur Morgan", Gender.Male, "123", Weapon.MauserPistol | Weapon.SpringfieldRifle,
                    Home.BlackWater, "mail@mail.com", "512123", "13600000000")
            },
            {
                "Sadie",
                new User("Sadie", "Sadie Adler", Gender.Female, "123", Weapon.SchofieldRevolver, Home.Strawberry,
                    "mail@mail.com", "512123", "13600000000")
            },
            {
                "Abigail",
                new User("Abigail", "Abigail Roberts", Gender.Female, "123", Weapon.SchofieldRevolver, Home.Strawberry,
                    "mail@mail.com", "512123", "13600000000")
            },
            {
                "Dutch",
                new User("Dutch", "Dutch Van Der Linde", Gender.Male, "123", Weapon.SchofieldRevolver, Home.Strawberry,
                    "mail@mail.com", "512123", "13600000000")
            },
            {
                "Hosea",
                new User("Hosea", "Hosea Matthews", Gender.Male, "123", Weapon.SchofieldRevolver, Home.Strawberry,
                    "mail@mail.com", "512123", "13600000000")
            },
            {
                "Charles",
                new User("Charles", "Charles Smith", Gender.Male, "123", Weapon.SchofieldRevolver, Home.Strawberry,
                    "mail@mail.com", "512123", "13600000000")
            },
            {
                "Jack",
                new User("Jack", "Jack Marston", Gender.Male, "123", Weapon.SchofieldRevolver, Home.Strawberry,
                    "mail@mail.com", "512123", "13600000000")
            },
            {
                "Mary",
                new User("Mary", "Mary-Beth Gaskill", Gender.Male, "123", Weapon.SchofieldRevolver,
                    Home.Strawberry,
                    "mail@mail.com", "512123", "13600000000")
            },
            {
                "Sean",
                new User("Sean", "Sean Macguire", Gender.Male, "123", Weapon.SchofieldRevolver, Home.Strawberry,
                    "mail@mail.com", "512123", "13600000000")
            }
        };


        public static User FindUser(string userName)
        {
            try
            {
                if (User.UserDictionary.ContainsKey(userName))
                {
                    return User.UserDictionary[userName];
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
            UserDictionary.Add(user.UserID,user);
        }

    }
}