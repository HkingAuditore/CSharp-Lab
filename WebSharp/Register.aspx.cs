using System;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSharp.Controllers;

namespace WebSharp
{
    public partial class Register : Page
    {


        private Weapon[] _weapons = new[]
        {
            Weapon.DoubleActionRevolver,
            Weapon.SchofieldRevolver,
            Weapon.M1899Pistol,
            Weapon.MauserPistol,
            Weapon.SpringfieldRifle,
            Weapon.LancasterRepeater,
            Weapon.CarcanoRifle,
            Weapon.DoubleBarreledShotgun,
            Weapon.SawedOffShotgun
        };

        private Home[] _homes = new[]
        {
            Home.SaintDenis,
            Home.Rhodes,
            Home.Valentine,
            Home.BlackWater,
            Home.Strawberry,
            Home.BeecherSHope,
            Home.TheHeartLand
        };

        private const int Time = 3;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack) //首次登录时为false
            {
                Session["Time"] = "1";
            }
            else if (Int32.Parse(Session["Time"].ToString()) >= Time)
            {
                Confirm.Enabled = false;
                Confirm.CssClass = "btn-alert";
            }
        }

        

        protected void Upload_Click(object sender, EventArgs e)
        {
            string pwd = UserPassword.Text;
            string pwdConfirm = UserPasswordConfirm.Text;
            if (FileUpload1.HasFile)
            {
                StringBuilder imgPath = new StringBuilder(Server.MapPath("~/Users/Avatars/"));
                string fileType = FileUpload1.FileName.Split('.')[1];
                if (fileType.ToLower() != "jpg")
                {
                    Response.Write("<script>alert('请上传jpg格式图像！')</script>");
                    return;
                }
                if (!Directory.Exists(imgPath.ToString())) Directory.CreateDirectory(imgPath.ToString());
                if (UserAccount.Text != "" && Module.User.FindUser(UserAccount.Text) == null)
                {
                    imgPath.Append(UserAccount.Text + '.' + fileType) ;
                    FileUpload1.SaveAs(imgPath.ToString());
                    // Response.Write("<script>alert('"+ imgPath.ToString() + "')</script>");
                    Image1.ImageUrl = "~/Users/Avatars/" + UserAccount.Text + '.' + fileType;
                }
                else
                {
                    if(UserAccount.Text == "")
                        Response.Write("<script>alert('未填写账号或账号已被占用！')</script>");
                    if(Module.User.FindUser(UserAccount.Text) != null)
                    {
                        Response.Write("<script>alert('账号已被占用！')</script>");
                        Response.Write("<script>alert('"+ Module.User.FindUser(UserAccount.Text).UserID + "')</script>");
                    }
                    return;
                    
                }


            }

            UserPassword.Text = pwd;
            UserPasswordConfirm.Text = pwdConfirm;
        }


        private void CheckInput()
        {
            if (!Male.Checked && !Female.Checked)
            {
                RegisterErrorException e = new RegisterErrorException("未选择性别！");
                throw e;
            }
            if (UserAccount.Text == "" || Module.User.FindUser(UserAccount.Text) != null)
            {
                RegisterErrorException e = new RegisterErrorException("未填写账号或账号已被占用！");
                throw e;

            }
            if (UserEmail.Text == "")
            {
                RegisterErrorException e = new RegisterErrorException("未填写邮箱！");
                throw e;

            }
            if (UserPassword.Text == "")
            {
                RegisterErrorException e = new RegisterErrorException("未填写密码！");
                throw e;

            }
            if (UserPasswordConfirm.Text != UserPassword.Text)
            {
                RegisterErrorException e = new RegisterErrorException("两次密码不一致！");
                throw e;

            }
            if (UserName.Text == "")
            {
                RegisterErrorException e = new RegisterErrorException("未填写用户名！");
                throw e;

            }

            if (GetUserWeapon() == 0)
            {
                RegisterErrorException e = new RegisterErrorException("请至少选择一个武器！");
                throw e;

            }
            if (!System.IO.File.Exists(Server.MapPath("~/Users/Avatars/" + UserAccount.Text + ".jpg")))
            {
                RegisterErrorException e = new RegisterErrorException("请上传头像！");
                throw e;

            }
            //验证码检验
            if (!txtCaptcha.Text.Equals(Session["code"]))
            {
                RegisterErrorException e = new RegisterErrorException("验证码错误！");
                throw e;
            }
        }


        private Weapon GetUserWeapon()
        {
            Weapon userWeapon = 0x00;
            int radioCount = 0;
            foreach (Control controller in form1.Controls)
            {
                if (string.Equals(controller.GetType().ToString(), "System.Web.UI.WebControls.CheckBox"))
                {
                    CheckBox weaponBox = (CheckBox) controller;
                    if (weaponBox.Checked)
                    {
                        userWeapon |= _weapons[radioCount];
                    }

                    radioCount++;
                }
            }

            return userWeapon;
        }

        private Home GetUserHome() => _homes[UserHome.SelectedIndex];

        protected void Confirm_OnClick(object sender, EventArgs e)
        {

            try
            {
                CheckInput();
                Gender userGender = Male.Checked ? Gender.Male : Gender.Female;
                RegisterController registerController = new RegisterController(UserAccount.Text,UserName.Text, userGender,UserPassword.Text,GetUserWeapon(),GetUserHome(),UserEmail.Text,UserMail.Text,UserPhone.Text);
                Session["userID"] = UserAccount.Text;
                Response.Redirect("index.aspx");
            }
            catch (Exception et)
            {
                Response.Write("<script>alert('"+et.Message+"')</script>");
                Response.Write($"<script>alert('这是第{Session["Time"]}次错误！')</script>");
                Session["Time"] = Int32.Parse(Session["Time"].ToString()) + 1;
            }
        }



        protected void UserEmail_OnTextChanged(object sender, EventArgs e)
        {
            if (!RegisterController.CheckEmail(UserEmail.Text))
            {
                Response.Write("<script>alert('邮箱无效！')</script>");
                UserEmail.Text = "";
            }
        }


        protected void UserPhone_OnTextChanged(object sender, EventArgs e)
        {
            if (!RegisterController.CheckPhone(UserPhone.Text))
            {
                Response.Write("<script>alert('手机号码无效！')</script>");
                UserPhone.Text = "";
            }

        }

        protected void UserMail_OnTextChanged(object sender, EventArgs e)
        {
            if (!RegisterController.CheckMail(UserMail.Text))
            {
                Response.Write("<script>alert('邮编无效！')</script>");
                UserMail.Text = "";
            }

        }
    }
}