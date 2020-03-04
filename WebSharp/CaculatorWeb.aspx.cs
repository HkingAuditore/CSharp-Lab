using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSharp.Module;

namespace WebSharp
{
    public partial class CaculatorWeb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                SolveEquation(num0,num1,num2);

            }
            else
            {
                Result.Visible = false;
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private bool CheckValid(TextBox target)
        {
            return !string.IsNullOrEmpty(target.Text);
        }

        private void SolveEquation(TextBox textBox0, TextBox textBox1,TextBox textBox2)
        {
            try
            {
                Equation equation;
                
                if (textBox0.Text == "0" && textBox1.Text == "0")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('x的系数不可以全部为0！')", true);
                }


                if (textBox0.Text == "0")
                {
                    equation = new OneDegreeEquation(1, float.Parse(textBox2.Text), float.Parse(textBox1.Text));
                }
                else
                {
                    equation = new TwoDegreeEquation(2, float.Parse(textBox2.Text), float.Parse(textBox1.Text), float.Parse(textBox0.Text));
                }
                var stringBuilder = new StringBuilder("解有 " + equation.Result.Count + " 个， 是： ");
                foreach (var i in equation.Result)
                {
                    stringBuilder.Append(i + ",");
                }
                stringBuilder.Remove(stringBuilder.Length - 1, 1);
                Result.Visible = true;
                Result.Text = stringBuilder.ToString();
            }
            catch (Exception et)
            {
                Result.Visible = true;
                Result.Text = et.Message;
            }
        }

        // private void Calculate()
        // {
        //     if (CheckValid(num0) && CheckValid(num1))
        //     {
        //         try
        //         {
        //             var calculator = new Calculator(Calculator.InterpretInput(num0.Text),
        //                 Calculator.InterpretInput(num1.Text),
        //                 (Calculator.Operate)Convert.ToInt16(OperatorChosen.Text));
        //             Result.Text = calculator.Result.ToString();
        //         }
        //         catch (BasicCalculatorException et)
        //         {
        //             Result.Text = et.Message + "请检查输入。";
        //         }
        //         // catch (System.FormatException et)
        //         // {
        //         //     Result.Text = "有不支持的输入符号，请检查输入。";
        //         // }
        //     }
        //     else
        //     {
        //         Result.Text = "请填写数字！";
        //     }
        // }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Calculate();
            SolveEquation(num0,num1,num2);
        }

        protected void CheckInput(object sender, EventArgs e)
        {
            TextBox input = (TextBox) sender;
            try
            {
                float result = float.Parse(input.Text);

            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('输入数字有误！')", true);
                input.Text = "";
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            num0.Text = "";
            num1.Text = "";
            num2.Text = "";
            Result.Visible = false;
        }
    }
}