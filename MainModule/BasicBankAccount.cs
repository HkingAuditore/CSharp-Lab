public interface IPropertyOwner
{
    /// <summary>
    ///     财产
    /// </summary>
    float Property { get; }

    string OwnerId { get; }

    /// <summary>
    ///     修改金钱
    /// </summary>
    /// <param name="money"></param>
    /// <returns></returns>
    float ChangeMoney(float money);

    /// <summary>
    ///     转账
    /// </summary>
    /// <param name="target">转账对象</param>
    /// <param name="money">转账金额</param>
    void Transfer<T>(T target, float money) where T:IPropertyOwner;

    bool IsEnoughMoney(float money);

}

public class BasicBankAccount : IPropertyOwner
{
    /// 银行账户
    public string AccountId { get; }

    /// 财产
    private float _property;

    public float Property
    {
        get => _property;
        set
        {
            if (value >= 0)
                _property = value;
            else
                throw new BasicUserException(this.AccountId + "负债！");
        }
    }

    public string OwnerId => AccountId;

    /// 开户地点
    public Home OpeningPlace { get; }

    public BasicBankAccount(string accountID, float initProperty, Home openingPlace)
    {
        AccountId = accountID;
        Property = initProperty;
        OpeningPlace = openingPlace;
    }

    /// <summary>
    ///     改变银行账户金额
    /// </summary>
    /// <param name="money">改变值</param>
    /// <returns></returns>
    public float ChangeMoney(float money)
    {
        Property += money;
        return Property;
    }

    public void Transfer<T>(T target, float money) where T : IPropertyOwner
    {
        if (target == null) throw new BasicUserException("无转账对象！");
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


    public bool IsEnoughMoney(float money) => Property >= money;

    public bool IsMatchAccount(string accountId) => this.AccountId == accountId;

}