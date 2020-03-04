<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CaculatorWeb.aspx.cs" Inherits="WebSharp.CaculatorWeb" %>

<!DOCTYPE html>

<link href="Content/bootstrap.css" rel="stylesheet"/>
<link href="Content/bootstrap-theme.css" rel="stylesheet"/>
<script src="../packages/bootstrap.3.0.0/Content/Scripts/bootstrap.min.js"></script>
<script src="../packages/jQuery.1.10.2/Content/Scripts/jquery-1.10.2.js"></script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
<form id="form1" runat="server">

    <div class="container">
        <div class="row" style="text-align: center; font-size: 40px">
            方程求解
        </div>
        <div class="row" style="margin-top: 2%">
            <div style="text-align: center">
                <asp:TextBox ID="num0" runat="server" OnTextChanged="CheckInput"></asp:TextBox>
                <%--<asp:DropDownList ID="OperatorChosen" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem Value="0">+</asp:ListItem>
            <asp:ListItem Value="1">-</asp:ListItem>
            <asp:ListItem Value="2">*</asp:ListItem>
            <asp:ListItem Value="3">÷</asp:ListItem>
            <asp:ListItem Value="4">乘方</asp:ListItem>
            <asp:ListItem Value="5">整除</asp:ListItem>
            <asp:ListItem Value="6">取余</asp:ListItem>
            <asp:ListItem Value="7">开方</asp:ListItem>
            </asp:DropDownList>--%>
                x<sup>2</sup>+
                <asp:TextBox ID="num1" runat="server" OnTextChanged="CheckInput"></asp:TextBox>
                x+<asp:TextBox ID="num2" runat="server" OnTextChanged="CheckInput" AutoPostBack="TRUE"></asp:TextBox> =0
            </div>

        </div>
        <div class="row" style="text-align: center; font-size: 150%; margin-top: 3%;margin-bottom: 2%">
            <div class="col-lg-2 col-lg-offset-3">
                <asp:Button ID="Button1" type="button" runat="server" Text="求解方程" OnClick="Button1_Click" CssClass="btn-primary"/>
            </div>
            <div class="col-lg-2">
                <asp:Button ID="Button2" runat="server" Text="清空输入" type="button" CssClass="btn-warning" OnClick="Button2_Click" />
            </div>
            <div class="col-lg-2">
                <asp:Button ID="Button3" runat="server" Text="帮助文档" type="button" CssClass="btn-info" OnClick="Button3_Click"/>
            </div>
        </div>
        <div class="row" style="text-align: center; font-size: 150%">
            <asp:Label ID="Result" runat="server" ForeColor="#FF6C35" Text="结果显示在这里" Width="493px" style="text-align: center" Height="20px"></asp:Label>
        </div>
    </div>
</form>
</body>
</html>