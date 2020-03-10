using System;



//性别
[Flags]
public enum Gender : uint
{
    Male = 0x01,
    Female = 0x02
}



//出生地
[Flags]
public enum Home : uint
{
    SaintDenis   = 0x01 ,
    Rhodes       = 0x02 ,
    Valentine    = 0x04 ,
    BlackWater   = 0x08 ,
    Strawberry   = 0x010,
    BeecherSHope = 0x020,
    TheHeartLand = 0x040,

}

public class BasicUserException : ApplicationException
{
    public BasicUserException(string message) : base(message)
    {
    }
}

public class BasicUser
{
    public string UserID { get; private set; }
    public string UserName { get; private set; }
    public Gender UserGender { get; private set; }
    public Weapon UserWeapon { get; set; }
    public Home UserHome { get; private set; }
    public string EmailAccount { get; private set; }
    public string UserMail { get; private set; }
    public string UserPhone { get; private set; }

    public float UserMoney { get; set; }

    private string _password;

    public BasicUser (string userId,string userName, Gender userGender, string password, Weapon userWeapon, Home userHome, string emailAccount, string userMail, string userPhone,float userMoney = 100)
    {
        UserID = userId;
        UserName = userName;
        UserGender = userGender;
        _password = password;
        UserWeapon = userWeapon;
        UserHome = userHome;
        EmailAccount = emailAccount;
        UserMail = userMail;
        UserPhone = userPhone;
        UserMoney = userMoney;
    }

    //检查密码
    public bool CheckPassword(string input) => input.ToLower() == _password.ToLower();

    //改变金钱
    public float ChangeMoney(float money)
    {
        this.UserMoney += money;
        return this.UserMoney;
    }
}