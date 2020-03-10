using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSharp.Module;

namespace WebSharp
{
    public partial class Gamble : System.Web.UI.Page
    {
        public User ThisUser { get; private set; }
        public static Module.Gamble ThisGamble = new Module.Gamble();
        public static float LastRoundMoney;
        public static bool IsUserPlay = false;
        private float _gambleMoney;
        private GambleChoose _userChoose;


        protected void Page_Load(object sender, EventArgs e)
        {
            ThisUser = Module.User.FindUser(Session["userID"].ToString());

            if (Session["Rebuild"] == null) //首次登录时为false
            {
                UserMoney.Text = "$" + ThisUser.UserMoney.ToString();
                SetGamble();
                AllMoney.Text = "除了您，当前场上共有 $" + ThisGamble.GamblingMoney;
                DiceDiv.Visible = false;
                Session["Rebuild"] = "0";
            }
            else
            {
                if (Session["Rebuild"].ToString() =="1")
                {
                    ThisGamble = new Module.Gamble();
                    SetGamble();
                    UserMoney.Text = "$" + ThisUser.UserMoney.ToString();
                    AllMoney.Text = "除了您，当前场上共有 $" + ThisGamble.GamblingMoney;
                    DiceDiv.Visible = false;
                    Session["Rebuild"] = "0";
                }

            }
            



        }

        private void PushResult(Module.Gamble lastGamble)
        {
            for (int i = 0; i < lastGamble.Gamblers.Count - 1; i++)
            {
                Label money = (Label)FindControl("PlayerMoney" + (i + 1).ToString());

                money.Text = money.Text + "+ $" + lastGamble.Gamblers[i].Reward.ToString();
            }
            UserMoney.Text = UserMoney.Text + " +$" + lastGamble.Gamblers[lastGamble.Gamblers.Count - 1].Reward;
            AllMoney.Text = "开盘，本轮场上共有赌资 $" + LastRoundMoney;
            Dice.Text = lastGamble.DiceResult.ToString();
            DiceDiv.Visible = true;


        }


        private float GetMoney() => float.Parse(GambleMoney.Text) <= ThisUser.UserMoney
            ? float.Parse(GambleMoney.Text)
            : ThisUser.UserMoney;



        private void SetGamble()
        {
            Random rand = new Random();
            ThisGamble.FillGamble(ThisUser, rand.Next(4, 10));

            int i = 0;
            for (; i < ThisGamble.Gamblers.Count; i++)
            {
                Image avatar = (Image) FindControl("PlayerImage" + (i+1).ToString());
                Label name = (Label) FindControl("PlayerName" + (i + 1).ToString());
                Label money = (Label)FindControl("PlayerMoney" + (i + 1).ToString());
                Label choose = (Label)FindControl("PlayerChoose" + (i + 1).ToString());

                avatar.ImageUrl = "~/Users/Avatars/" + ThisGamble.Gamblers[i].ID + ".jpg";
                name.Text = Module.User.FindUser(ThisGamble.Gamblers[i].ID).UserName;
                money.Text ="$" +  ThisGamble.Gamblers[i].ContributeMoney.ToString();
                choose.Text = ThisGamble.Gamblers[i].Choose.ToString()=="Big"?"押大":"押小";
            }

            // Response.Write("<script>alert(" + ((i / 4) + 1).ToString() + ");</script>");
            // Response.Write("<script>document.getElementById(\"playerLine" + ((i / 4) + 1).ToString() + "\").style.display = \"none\";</script>");
            // Response.Write("<script>document.getElementById(\"playerLine" + ((i / 4) + 2).ToString() + "\").style.display = \"none\";</script>");
            if (i < 9) playerLine3.Visible = false;
            if (i < 5) playerLine2.Visible = false;
            

        }

        private void LaunchGamble()
        {
            IsUserPlay = true;
            _gambleMoney = GetMoney();
            ThisGamble.AddGambler(ThisUser, _gambleMoney, _userChoose);
            LastRoundMoney = ThisGamble.GamblingMoney;
            ThisGamble.StartGamble();
            // var gambleCache = HttpRuntime.Cache;
            // gambleCache.Insert( "tempGamble",ThisGamble);
            PushResult(ThisGamble);

            BigButton.Visible = false;
            SmallButton.Visible = false;

        }


        protected void BigButton_OnClick(object sender, EventArgs e)
        {
            _userChoose = GambleChoose.Big;
            LaunchGamble();
 

        }

        protected void SmallButton_OnClick(object sender, EventArgs e)
        {
            _userChoose = GambleChoose.Small;
            LaunchGamble();

        }

        protected void RebuildButton_OnClickButton_OnClick(object sender, EventArgs e)
        {
            if (IsUserPlay)
            {
                IsUserPlay = false;
            }
            else
            {
                ThisGamble.StartGamble();

            }
            Session["Rebuild"] = "1";
            Response.Redirect("Gamble.aspx");

        }
    }





}