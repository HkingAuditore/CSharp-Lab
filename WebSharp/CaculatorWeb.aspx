<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CaculatorWeb.aspx.cs" Inherits="WebSharp.CaculatorWeb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
        <asp:TextBox ID="num0" runat="server"></asp:TextBox>
        <asp:DropDownList ID="OperatorChosen" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem Value="0">+</asp:ListItem>
            <asp:ListItem Value="1">-</asp:ListItem>
            <asp:ListItem Value="2">*</asp:ListItem>
            <asp:ListItem Value="3">÷</asp:ListItem>
            <asp:ListItem Value="4">乘方</asp:ListItem>
            <asp:ListItem Value="5">整除</asp:ListItem>
            <asp:ListItem Value="6">取余</asp:ListItem>
            <asp:ListItem Value="7">开方</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="num1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="=" OnClick="Button1_Click" />
        <asp:Label ID="Result" runat="server" ForeColor="#FF6C35" Text="结果" Width="111px" style="text-align: center" Height="20px"></asp:Label>
        </div>
    </form>
</body>
</html>