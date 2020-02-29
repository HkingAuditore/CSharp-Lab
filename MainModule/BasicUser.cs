using System;

[Flags]
public enum Gender : uint
{
    Male = 0x01,
    Female = 0x02
}

public class BasicUser
{
    public string UserName { get; private set; }
    public Gender UserGender;

    private string _password;

    public BasicUser(string userName, Gender userGender, string password)
    {
        UserName = userName;
        UserGender = userGender;
        _password = password;
    }

    //检查密码
    public bool CheckPassword(string input) => input == _password ? true : false;
}