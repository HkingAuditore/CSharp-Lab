using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSharp.Module;

namespace WebSharp
{
    public partial class Index : System.Web.UI.Page
    {
        private string TranslateProperty(Gender gender) => gender == Gender.Male ? "男" : "女";

        private string TranslateProperty(Weapon weapon)
        {
            StringBuilder weapons = new StringBuilder("");
            if (weapon.HasFlag(Weapon.DoubleActionRevolver))
                weapons.Append("双动式左轮手枪,");
            if (weapon.HasFlag(Weapon.SchofieldRevolver))
                weapons.Append("斯科菲尔德左轮手枪,");
            if (weapon.HasFlag(Weapon.M1899Pistol))
                weapons.Append("M1899手枪,");
            if (weapon.HasFlag(Weapon.MauserPistol))
                weapons.Append("毛瑟手枪,");
            if (weapon.HasFlag(Weapon.SpringfieldRifle))
                weapons.Append("春田步枪,");
            if (weapon.HasFlag(Weapon.LancasterRepeater))
                weapons.Append("兰卡斯连发步枪,");
            if (weapon.HasFlag(Weapon.CarcanoRifle))
                weapons.Append("卡尔卡诺步枪,");
            if (weapon.HasFlag(Weapon.DoubleBarreledShotgun))
                weapons.Append("双管霰弹枪,");
            if (weapon.HasFlag(Weapon.SawedOffShotgun))
                weapons.Append("削短型霰弹枪,");
            weapons.Remove(weapons.Length-1, 1);
            return weapons.ToString();
        }
        private string TranslateProperty(Home home)
        {
            switch (home)
            {
                case Home.SaintDenis:
                    return "圣丹尼斯";
                    break;
                case Home.Rhodes:
                    return "罗兹";

                    break;
                case Home.Valentine:
                    return "瓦伦丁";

                    break;
                case Home.BlackWater:
                    return "黑水镇";

                    break;
                case Home.Strawberry:
                    return "草莓镇";

                    break;
                case Home.BeecherSHope:
                    return "比彻之愿";

                    break;
                case Home.TheHeartLand:
                    return "大地之心";

                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(home), home, null);
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            User user = Module.User.FindUser(Session["userID"].ToString());
            if (user != null)
            {
                Avatar.ImageUrl = "~/Users/Avatars/" + user.UserID + ".jpg";
                UserAccount.Text = user.UserID;
                UserName.Text = user.UserName;
                UserHome.Text = TranslateProperty(user.UserHome);
                UserWeapon.Text = TranslateProperty(user.UserWeapon);
                UserGender.Text = TranslateProperty(user.UserGender);
                UserEmail.Text = user.EmailAccount;
                UserMail.Text = user.UserMail;
                UserPhone.Text = user.UserPhone;
            }
        }
    }
}