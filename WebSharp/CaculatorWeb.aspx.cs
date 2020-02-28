using System;
using System.Web.UI.WebControls;
using WebSharp.Module;

namespace WebSharp
{
    public partial class CaculatorWeb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private bool CheckValid(TextBox target)
        {
            return !string.IsNullOrEmpty(target.Text);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (CheckValid(num0) && CheckValid(num1))
            {
                try
                {
                    var calculator = new Calculator(Calculator.InterpretInput(num0.Text),
                        Calculator.InterpretInput(num1.Text),
                        (Calculator.Operate)Convert.ToInt16(OperatorChosen.Text));
                    Result.Text = calculator.Result.ToString();
                }
                catch (BasicCalculatorException et)
                {
                    Result.Text = et.Message + "请检查输入。";
                }
                // catch (System.FormatException et)
                // {
                //     Result.Text = "有不支持的输入符号，请检查输入。";
                // }
            }
            else
            {
                Result.Text = "请填写数字！";
            }
        }
    }
}