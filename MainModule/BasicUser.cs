using System;

//性别
[Flags]
public enum Gender : uint
{
    Male = 0x01,
    Female = 0x02
}

//武器
[Flags]
public enum Weapon : uint
{
    DoubleActionRevolver  = 0x001,
    SchofieldRevolver     = 0x002,
    M1899Pistol           = 0x004,
    MauserPistol          = 0x008,
    SpringfieldRifle      = 0x010,
    LancasterRepeater     = 0x020,
    CarcanoRifle          = 0x040,
    DoubleBarreledShotgun = 0x080,
    SawedOffShotgun       = 0x0100,

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

    private string _password;

    public BasicUser (string userId,string userName, Gender userGender, string password, Weapon userWeapon, Home userHome, string emailAccount, string userMail, string userPhone)
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
    }

    //检查密码
    public bool CheckPassword(string input) => input.ToLower() == _password.ToLower();
}