using System;
using System.Collections.Generic;
using WebSharp.Module;


/// <summary>
/// 性别
/// </summary>
[Flags]
public enum Gender : uint
{
    Male = 0x01,
    Female = 0x02
}



/// <summary>
/// 出生地
/// </summary>
[Flags]
public enum Home : uint
{
    SaintDenis   = 0x01 ,
    Rhodes       = 0x02 ,
    Valentine    = 0x04 ,
    BlackWater   = 0x08 ,
    Strawberry   = 0x10,
    BeecherSHope = 0x20,
    TheHeartLand = 0x40,

}

public class BasicUserException : ApplicationException
{
    public BasicUserException(string message) : base(message)
    {
    }
}

public class BasicUser:IPropertyOwner
{
    public string UserID { get; private set; }
    public string UserName { get; private set; }
    public Gender UserGender { get; private set; }
    public Weapon UserWeapon { get; set; }
    public Home UserHome { get; private set; }
    public string EmailAccount { get; private set; }
    public string UserMail { get; private set; }
    public string UserPhone { get; private set; }
    public List<BasicBankAccount> BankAccounts = new List<BasicBankAccount>();

    public float UserMoney { get; set; }

    private string _password;
    private static float _initMoney = 10f;

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

    
    public float Property
    {
        get
        {
            float userProperty = 0f;
            foreach (var bankAccount in BankAccounts)
            {
                userProperty += bankAccount.Property;
            }

            return (userProperty + UserMoney);
        }
    }

    public string OwnerId { get => UserID; }


    public float ChangeMoney(float money)
    {
        this.UserMoney += money;
        return this.UserMoney;
    }

    public void Transfer<T>(T target, float money) where T : IPropertyOwner
    {
        if(target == null)throw new BasicUserException("无转账对象！");
        if (IsEnoughMoney(money))
        {
            IPropertyOwner targetPropertyOwner = target as IPropertyOwner;
            targetPropertyOwner.ChangeMoney(money);
            this.ChangeMoney(-money);
        }
        else
        {
            throw new BasicUserException("余额不足");
        }
    }

    public bool IsEnoughMoney(float money) => UserMoney >= money;


    /// <summary>
    /// 开户
    /// </summary>
    /// <param name="accountId">银行账号</param>
    /// <param name="openingPlace">开户地点</param>
    public void OpenBankAccount(string accountId,Home openingPlace)
    {
        if (UserMoney >= _initMoney && FindBankAccount(accountId)==null)
        {
            BankAccounts.Add(new BasicBankAccount(accountId, _initMoney, openingPlace));
            ChangeMoney(-_initMoney);
        }
        else
        {
            throw new BasicUserException("开户失败");
        }
    }

    public BasicBankAccount FindBankAccount(string accountId)
    {
        foreach (var bankAccount in BankAccounts)
        {
            if (bankAccount.IsMatchAccount(accountId))
            {
                return bankAccount;
            }
        }

        return null;
    }
}