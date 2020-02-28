using System;

namespace WebSharp
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            testText.Text = textBoxTest.Text + " by HkingAuditore";
        }
    }
}