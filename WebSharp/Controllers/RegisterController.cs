using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Web;
using WebSharp.Module;

namespace WebSharp.Controllers
{

    public class RegisterErrorException : ApplicationException
    {
        public RegisterErrorException(string message) : base(message) { }
    }

    public class RegisterController
    {

        private static readonly Regex EMailReg = new Regex(@"(?<=[^\s])@.+?\.(com|net|cn)");
        private static readonly Regex MailReg = new Regex(@"(?<!.)[0-9]{6}(?!.)");
        private static readonly Regex PhoneReg = new Regex(@"(?<!.)(13|15)[0-9]{9}(?!.)");

        public RegisterController(string userId, string userName, Gender userGender, string password, Weapon userWeapon, Home userHome,
            string emailAccount,string userMail,string userPhone)
        {
            if(User.FindUser(userId) == null)
            {
                User.AddUser(new User(userId, userName, userGender, password, userWeapon, userHome, emailAccount,
                    userMail, userPhone));
            }
            else
            {
                RegisterErrorException e = new RegisterErrorException("用户ID已存在！");
                throw e;
            }
        }

        //邮箱检验
        public static bool CheckEmail(string email) => (EMailReg.Matches(email).Count == 1) ? true : false;

        //邮编检验
        public static bool CheckMail(string mail) => (MailReg.Matches(mail).Count == 1) ? true : false;

        //手机号码检验
        public static bool CheckPhone(string phone) => (PhoneReg.Matches(phone).Count == 1) ? true : false;



    }
}