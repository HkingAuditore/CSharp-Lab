using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSharp
{
    public partial class FullCalculator : System.Web.UI.Page
    {
        static StringBuilder input = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Text_OnClick(object sender, EventArgs e)
        {
            input.Append(((Button) sender).Text);
            Input.Text = input.ToString();
        }

        protected void ButtonE_OnClick(object sender, EventArgs e)
        {
            try
            {
                ExpressionTree exp = new ExpressionTree(Input.Text.Trim());
                Result.Text = exp.Result.ToString();
            }
            catch (Exception exception)
            {
                Result.Text = exception.Message;
            }
            
        }

        protected void ButtonReset_OnClick(object sender, EventArgs e)
        {
            input.Clear();
            Input.Text = input.ToString();
        }
    }
}