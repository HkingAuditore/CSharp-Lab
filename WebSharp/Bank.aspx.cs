using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSharp.Module;

namespace WebSharp
{
    public partial class Bank : System.Web.UI.Page
    {
        public static User ThisUser { get; private set; }
        private static Home[] _homes = new[]
        {
            Home.SaintDenis,
            Home.Rhodes,
            Home.Valentine,
            Home.BlackWater,
            Home.Strawberry,
            Home.BeecherSHope,
            Home.TheHeartLand
        };

        // private static int curAccount;

        #region 界面显示控制

        private void UpdateTargetAccounts()
        {
            List<IPropertyOwner> list = new List<IPropertyOwner>();
            BasicBankAccount cur = ThisUser.FindBankAccount(BankAccount.SelectedValue);
            foreach (var account in ThisUser.BankAccounts)
            {
                if (account != cur)
                {
                    list.Add(account as IPropertyOwner);
                }
            }
            foreach (var user in WebSharp.Module.User.UserDictionary)
            {
                if (user.Value != ThisUser)
                {
                    list.Add(user.Value as IPropertyOwner);
                }
            }

            TransferTarget.DataSource = list;
            TransferTarget.DataTextField = "OwnerId";
            TransferTarget.DataValueField = "OwnerId";
            TransferTarget.DataBind();
        }

        private void UpdateAccounts(Home place)
        {
            List<BasicBankAccount> list = new List<BasicBankAccount>();
            foreach (var bankAccount in ThisUser.BankAccounts)
            {
                if(bankAccount.OpeningPlace == place)
                {
                    // Response.Write("<script>alert('" + bankAccount.AccountId + "')</script>");
                    list.Add(bankAccount);
                }
            }
            BankAccount.DataSource = list;
            BankAccount.DataTextField = "AccountID";
            BankAccount.DataValueField = "AccountID";
            BankAccount.DataBind();
        }

        private void UpdateProperty()
        {
            UserCash.Text = "$"+ThisUser.UserMoney.ToString(CultureInfo.CurrentCulture);
            if(ThisUser.FindBankAccount(BankAccount.SelectedValue) != null)
                BankBalance.Text = "$"+ThisUser.FindBankAccount(BankAccount.SelectedValue).Property.ToString(CultureInfo.CurrentCulture);
        }

        private void UpdateView(bool isUpdateAccounts)
        {
            UpdateTargetAccounts();
            if(isUpdateAccounts)UpdateAccounts(_homes[Place.SelectedIndex]);
            UpdateProperty();
        }

        #endregion

        #region 交互控制

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ThisUser = Module.User.FindUser(Session["userID"].ToString());
                // curAccount = 0;
                UpdateView(true);
            }
            
        }

        protected void Open_OnClick(object sender, EventArgs e)
        {
            try
            {
                ThisUser.OpenBankAccount(OpeningAccount.Text, _homes[Place.SelectedIndex]);
                UpdateView(true);
            }
            catch (Exception exception)
            {
                Response.Write("<script>alert('"+exception.Message+"')</script>");
            }
        }

        protected void Place_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateView(true);
        }

        protected void BankAccount_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int temp = this.BankAccount.SelectedIndex;
            UpdateView(false);
            BankAccount.SelectedIndex = temp;

        }

        protected void Transfer_OnClick(object sender, EventArgs e)
        {
            // IPropertyOwner target = ThisUser.FindBankAccount(BankAccount.SelectedValue);
            IPropertyOwner thisAccount = ThisUser.FindBankAccount(BankAccount.SelectedValue);
            try
            {
                IPropertyOwner target = ThisUser.FindBankAccount(TransferTarget.SelectedValue) ?? Module.User.FindUser(TransferTarget.SelectedValue) as IPropertyOwner;
                thisAccount.Transfer<IPropertyOwner>(target,float.Parse(TransferMoney.Text));
                UpdateView(false);
            }
            catch (Exception exception)
            {
                Response.Write("<script>alert('" + exception.Message + "')</script>");
            }
        }

        protected void Deal_OnClick(object sender, EventArgs e)
        {
            BasicBankAccount curBankAccount = ThisUser.FindBankAccount(BankAccount.SelectedValue);
            try
            {
                if (DealChoice.SelectedValue == "0")
                {
                    ThisUser.Transfer<BasicBankAccount>(curBankAccount, float.Parse(DealMoney.Text));
                }
                else
                {
                    curBankAccount.Transfer<BasicUser>(ThisUser, float.Parse(DealMoney.Text));
                }
                UpdateView(false);
            }
            catch (Exception exception)
            {
                Response.Write("<script>alert(\"" + exception.Message + "\")</script>");
            }

        }
        protected void Back_OnClick_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        #endregion

    }
}