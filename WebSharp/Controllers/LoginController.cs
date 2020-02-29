using System;
using System.Collections.Generic;
using WebSharp.Module;

namespace WebSharp.Controllers
{
    public class LoginErrorException : ApplicationException
    {
        public LoginErrorException(string message) : base(message) { }
    }

    public class LoginArgs : EventArgs
    {
        public LoginArgs(int failureCode, User userCorrespond)
        {
            FailureCode = failureCode;
            UserCorrespond = userCorrespond;
        }

        public int FailureCode { get; set; }
        public User UserCorrespond { get; private set; }
    }

    public class LoginController
    {

        //登录成功记录
        public bool Validation { get; private set; }
        public User UserCorrespond { get; private set; }

        //登录成功事件
        public static event EventHandler<LoginArgs> LoginSuccess;
        //登录失败事件
        public static event EventHandler<LoginArgs> LoginFailure;

        //登录初始化
        static LoginController()
        {
            LoginSuccess += SuccessLogin;
            LoginFailure += FailLogin;
        }

        public LoginController(string userName, string pwd)
        {
            // 这里检验是否输入用户名和密码
            // 把这一段注释掉也可以，后面检查字典的时候也会扔错误
            if (userName == "" || pwd == "")
            {
                if (LoginFailure != null) LoginFailure(this, new LoginArgs(0, this.UserCorrespond));
                return;
            }
            if (IsPwdCorrespond(userName, pwd))
            {
                if (LoginSuccess != null) LoginSuccess(this, new LoginArgs(1, this.UserCorrespond));
            }
            else
            {
                if (LoginFailure != null) LoginFailure(this, new LoginArgs(1, this.UserCorrespond));
            }
        }

        //根据用户名查找用户
        private User FindUser(string userName) => User.FindUser(userName);

        //判断密码是否匹配
        private bool IsPwdCorrespond(string userName, string pwd)
        {
            UserCorrespond = FindUser(userName);
            if (UserCorrespond != null)
            {
                return (this.Validation = UserCorrespond.CheckPassword(pwd));
            }
            else
            {
                if (LoginFailure != null) LoginFailure(this, new LoginArgs(2, this.UserCorrespond));
                return (this.Validation = false);
            }
        }

        //登录失败
        private static void FailLogin(object source, LoginArgs e)
        {
            switch (e.FailureCode)
            {
                case 0:
                    LoginErrorException noUserNameOrPwd = new LoginErrorException("未输入用户名和密码！");
                    throw noUserNameOrPwd;

                case 1:
                    LoginErrorException wrongPwd = new LoginErrorException("密码错误！");
                    throw wrongPwd;

                case 2:
                    LoginErrorException wrongUsername = new LoginErrorException("找不到用户！");
                    throw wrongUsername;

                default:
                    return;
            }
        }

        //登录成功
        private static void SuccessLogin(object source, LoginArgs e)
        {
            
        }
    }
}