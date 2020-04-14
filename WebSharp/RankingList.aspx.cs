using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSharp
{
    public partial class RankingList : System.Web.UI.Page
    {
        public static readonly string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;

        private void UpdateData(string target)
        {
            using (var sqlConnection = new SqlConnection(ConString))
            {
                var dataSet = new DataSet();

                var sqlDataAdapter = new SqlDataAdapter();
                var sqlCommand = sqlConnection.CreateCommand();
                if (target != "")
                    sqlCommand.CommandText = "SELECT * FROM UserBasicInfo WHERE Name LIKE '%" + target + "%'";
                else
                    sqlCommand.CommandText = "SELECT * FROM UserBasicInfo";
                sqlDataAdapter.SelectCommand = sqlCommand;

                sqlConnection.Open();
                sqlDataAdapter.Fill(dataSet);

                GridViewMain.DataSource = dataSet;
                GridViewMain.DataBind();
                // GridView propertyData = (GridView)(GridView1.Rows[parent_index].FindControl("ChildGridView"));

            }

        }

        private void TestTransaction()
        {
            using (var sqlConnection = new SqlConnection(ConString))
            {
                sqlConnection.Open();
                // 新建一个事务
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction("TestTransaction");
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                try
                {
                    // 指令1
                    sqlCommand.CommandText =
                        "INSERT INTO UserBasicInfo VALUES ('Ezio', 'Ezio Auditore', '男', '31','mail@mail.com','BlackWater','123')";
                    sqlCommand.ExecuteNonQuery();
                    // 建立一个保存点
                    sqlTransaction.Save("Ezio");

                    // 不能执行的指令2
                    try
                    {
                        sqlCommand.CommandText =
                            "INSERT INTO UserBasicInfo VALUES ('Hking', 'Hking Auditore', '男', '20','mail@mail.com','Strawberry','123','123')";
                        sqlCommand.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        //回滚到保存点
                        sqlTransaction.Rollback("Ezio");
                    }
                    
                    //提交操作
                    sqlTransaction.Commit();
                    Response.Write("<script>alert('SUCCESS!')</script>");
                }
                catch
                {
                    Response.Write("<script>alert('ERROR!')</script>");
                }

            }
        }

        private void TestCommand()
        {
            using (var sqlConnection = new SqlConnection(ConString))
            {
                // 使用了Target占位符表示目标ID
                SqlCommand sqlCommand = new SqlCommand("UPDATE UserBasicInfo SET Password = '123456' WHERE ID = @Target", sqlConnection);
                // 构造Parameter对象
                SqlParameter targetSqlParameter = new SqlParameter("@Target",SqlDbType.VarChar,200);
                targetSqlParameter.Value = "Ezio";
                sqlCommand.Parameters.Add(targetSqlParameter);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }

        }

        private void UseCommand(String command)
        {
            using (var sqlConnection = new SqlConnection(ConString))
            {
                // 使用了Target占位符表示目标ID
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }

        }

        private void TestCommandProcedure()
        {
            using (var sqlConnection = new SqlConnection(ConString))
            {
                
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                //设定以存储过程解释CommandText
                sqlCommand.CommandText = "TestProcedure";
                // 构造Parameter对象
                SqlParameter targetSqlParameter = new SqlParameter("@Target",SqlDbType.VarChar,200);
                targetSqlParameter.Value = "Ezio";
                sqlCommand.Parameters.Add(targetSqlParameter);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }

        }

        private void TestCommandAsyn()
        {
            using (var sqlConnection = new SqlConnection(ConString))
            {
                
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                //设定以存储过程解释CommandText
                sqlCommand.CommandText = "TestProcedure";
                // 构造Parameter对象
                SqlParameter targetSqlParameter = new SqlParameter("@Target",SqlDbType.VarChar,200);
                targetSqlParameter.Value = "Ezio";
                sqlCommand.Parameters.Add(targetSqlParameter);

                sqlConnection.Open();

                IAsyncResult result = sqlCommand.BeginExecuteNonQuery();
                // 在未完成时弹出WAIT框
                while (!result.IsCompleted)
                {
                    Response.Write("<script>alert('WAIT')</script>");
                    System.Threading.Thread.Sleep(100);
                }

                // 在完成后弹出结果（影响行数）
                Response.Write("<script>alert('Affected "+ sqlCommand.EndExecuteNonQuery(result) + " rows')</script>");
                sqlConnection.Close();
            }

        }

        private void TestBuilder()
        {
            using (var sqlConnection = new SqlConnection(ConString))
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand =
                    new SqlCommand(
                        "SELECT * FROM UserBasicInfo WHERE Gender = '女'",
                        sqlConnection);
                SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);

                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet,"UserBasicInfo");

                // 添加数据
                DataTable dataTable = dataSet.Tables["USerBasicInfo"];
                DataRow dataRow = dataTable.NewRow();
                dataRow["ID"] = "Ezio";
                dataRow["Name"] = "Ezio Auditore";
                dataTable.Rows.Add(dataRow);

                Response.Write("<script>alert('COMMAND: " + sqlCommandBuilder.GetInsertCommand().CommandText + "')</script>");
                sqlDataAdapter.Update(dataSet, "UserBasicInfo");
                GridViewMain.DataSource = dataSet.Tables["UserBasicInfo"];
                GridViewMain.DataBind();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // UpdateData(!IsPostBack ? "" : TargetHome.SelectedValue);
            if(!IsPostBack)
            {
                UpdateData(!IsPostBack ? "" : SearchTarget.Text.Trim());
            }
            // else
            // {
            //     UpdateData(!IsPostBack ? "" : SearchTarget.Text.Trim());
            // }
           
        }

        protected void Refresh_OnClick(object sender, EventArgs e)
        {
            UpdateData("");
        }

        protected string GetString() => "TEST！";

        protected string GenerateRowSQL(string curId) =>
            "SELECT [BankAccount], [AccountOwnerID], [Property] FROM [BankAccountInfo] WHERE [AccountOwnerID] = '" +
            curId +"'";

        protected void GridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string sqlStr = "DELETE FROM UserBasicInfo WHERE ID= '" + GridViewMain.Rows[e.RowIndex].Cells[0].Text.ToString() + " '";
            UseCommand(sqlStr);
            UpdateData(!IsPostBack ? "" : SearchTarget.Text.Trim());

        }
        protected void GridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string ID = GridViewMain.Rows[e.RowIndex].Cells[0].Text.ToString();
            string Name = ((TextBox)(GridViewMain.Rows[e.RowIndex].Cells[2].Controls[0])).Text.ToString().Trim();
            string Gender = ((TextBox)(GridViewMain.Rows[e.RowIndex].Cells[3].Controls[0])).Text.ToString().Trim();
            string Age = ((TextBox)(GridViewMain.Rows[e.RowIndex].Cells[4].Controls[0])).Text.ToString().Trim();
            string Email = ((TextBox)(GridViewMain.Rows[e.RowIndex].Cells[5].Controls[0])).Text.ToString().Trim();
            string Address = ((TextBox)(GridViewMain.Rows[e.RowIndex].Cells[6].Controls[0])).Text.ToString().Trim();
            string Password = ((TextBox)(GridViewMain.Rows[e.RowIndex].Cells[7].Controls[0])).Text.ToString().Trim();
            string sqlStr = "UPDATE UserBasicInfo SET Name='" + Name + "',Gender='" + Gender + "',Age='" + Age + "',Email='" + Email + "',Address='" + Address + "',Password='" + Password + "'WHERE ID='" + ID + "'";
            Response.Write("<script>alert('SQL: " + sqlStr + "')</script>");
            UseCommand(sqlStr);
            
            // UpdateData(!IsPostBack ? "" : SearchTarget.Text.Trim());
        }
        protected void GridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewMain.EditIndex = e.NewEditIndex;
            UpdateData(!IsPostBack ? "" : SearchTarget.Text.Trim());
        }

        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewMain.SetPageIndex(GridViewMain.SelectedIndex);
            UpdateData(!IsPostBack ? "" : SearchTarget.Text.Trim());
        }

        protected void GridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewMain.EditIndex = -1;
            UpdateData(!IsPostBack ? "" : SearchTarget.Text.Trim());
        }

        protected void GridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewMain.PageIndex = e.NewPageIndex;
            UpdateData(!IsPostBack ? "" : SearchTarget.Text.Trim());
        }

        protected void PropertyData_RowEditing(object sender, GridViewEditEventArgs e)
        {
            ((GridView)sender).EditIndex = e.NewEditIndex;
            // UpdateData(!IsPostBack ? "" : SearchTarget.Text.Trim());
        }

        protected void PropertyData_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            ((GridView)sender).EditIndex = -1;
            // UpdateData(!IsPostBack ? "" : SearchTarget.Text.Trim());
        }

        protected void PropertyData_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string BankAccount = ((GridView)sender).Rows[e.RowIndex].Cells[0].Text.ToString();
            string Property = ((TextBox)(((GridView)sender).Rows[e.RowIndex].Cells[1].Controls[0])).Text.ToString().Trim();
            string sqlStr = "UPDATE BankAccountInfo SET Property='" + Property + "'WHERE BankAccount='" + BankAccount + "'";
            UseCommand(sqlStr);
            // UpdateData(!IsPostBack ? "" : SearchTarget.Text.Trim());
        }

        protected void Button1_OnClick(object sender, EventArgs e)
        {
            string curId = ((Button) sender).CommandArgument.ToString();
            int index = ((GridViewRow)((Button) sender).NamingContainer).RowIndex;
            ((Button) GridViewMain.Rows[index].FindControl("ButtonConfirm")).Visible = true;
            ((Button) GridViewMain.Rows[index].FindControl("ButtonCancel")).Visible = true;
            ((Button)GridViewMain.Rows[index].FindControl("Button1")).Visible = false;

            ((TextBox)GridViewMain.Rows[index].FindControl("NewAccount")).Visible = true;
            ((TextBox)GridViewMain.Rows[index].FindControl("NewProperty")).Visible = true;
        }

        protected void ButtonConfirm_OnClick(object sender, EventArgs e)
        {
            int index = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
            string curId = GridViewMain.Rows[index].Cells[0].Text.ToString();

            string newAccount =  ((TextBox)GridViewMain.Rows[index].FindControl("NewAccount")).Text.ToString();
            string newProperty = ((TextBox)GridViewMain.Rows[index].FindControl("NewProperty")).Text.ToString();

            string sqlString = "INSERT INTO BankAccountInfo VALUES ('" + newAccount + "', '" + curId + "'," + newProperty + ")";

            UseCommand(sqlString);

            ((Button)GridViewMain.Rows[index].FindControl("ButtonConfirm")).Visible = false;
            ((Button)GridViewMain.Rows[index].FindControl("ButtonCancel")).Visible = false;
            ((Button)GridViewMain.Rows[index].FindControl("Button1")).Visible = true;

            ((TextBox)GridViewMain.Rows[index].FindControl("NewAccount")).Visible = false;
            ((TextBox)GridViewMain.Rows[index].FindControl("NewProperty")).Visible = false;

            UpdateData(!IsPostBack ? "" : SearchTarget.Text.Trim());
        }

        protected void ButtonCancel_OnClick(object sender, EventArgs e)
        {

            int index = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
            ((Button)GridViewMain.Rows[index].FindControl("ButtonConfirm")).Visible = false;
            ((Button)GridViewMain.Rows[index].FindControl("ButtonCancel")).Visible = false;
            ((Button)GridViewMain.Rows[index].FindControl("Button1")).Visible = true;

            ((TextBox)GridViewMain.Rows[index].FindControl("NewAccount")).Visible = false;
            ((TextBox)GridViewMain.Rows[index].FindControl("NewProperty")).Visible = false;
        }
    }
}