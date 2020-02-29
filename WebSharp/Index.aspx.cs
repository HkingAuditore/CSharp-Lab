using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSharp.Module;

namespace WebSharp
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = Module.User.FindUser(Session["userName"].ToString());
            UserName.Text = user.UserName;
            UserGender.Text = user.UserGender.ToString();
        }
    }
}