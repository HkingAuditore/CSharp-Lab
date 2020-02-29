<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebSharp.Login" %>

<!DOCTYPE html>

<link href="Content/bootstrap.css" rel="stylesheet" />
<link href="Content/bootstrap-theme.css" rel="stylesheet" />
<script src="../packages/bootstrap.3.0.0/Content/Scripts/bootstrap.min.js"></script>
<script src="../packages/jQuery.1.10.2/Content/Scripts/jquery-1.10.2.js"></script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>

    <div class="container">
        <div class="row" style="margin-top:2% ">
            <div class="col-lg-10">
                <div class="alert alert-warning" role="alert">
                    请登录以查看个人信息页面！
                </div>
            </div>
        </div>
        <form id="form1" runat="server">
            <div class="row" style="margin-top:1% ">
                <div class="col-lg-1">
                    用户名
                </div>
                <div class="col-lg-4">
                    <asp:TextBox type="text" class="form-control" ID="UserNameTextBox" runat="server" ValidateRequestMode="Enabled" ></asp:TextBox>
                </div>
            </div>
            <div class="row" style="margin-top:1% ">
                <div class="col-lg-1">
                    密码
                </div>
                <div class="col-lg-4">
                    <asp:TextBox type="text" class="form-control" ID="PasswordTextBox" TextMode="Password" runat="server" OnTextChanged="PasswordTextBox_TextChanged" ValidateRequestMode="Enabled"></asp:TextBox>
                </div>
            </div>

            <div class="row" style="margin-top:1% ">
                <div class="col-lg-1">
                    <label>验证码</label>
                </div>
                <div class="col-lg-1">
                    <asp:TextBox type="text" class="form-control" ID="txtCaptcha" runat="server" ToolTip="请输入验证码" ValidateRequestMode="Enabled" Width="90px"></asp:TextBox>
                </div>
                <div class="col-lg-3">
                    <img id="imgCode" alt="看不清，请单击我！" src="PlugIns/Validata.aspx" onclick="this.src=this.src+'?'" style="vertical-align: bottom" />
                </div>
            </div>

            <div class="row" style="margin-top:1% ">
                <div class="col-lg-2">
                    <asp:Button ID="LoginButton" type="button" runat="server" Text="登录" BorderStyle="Solid" CssClass="btn-success" OnClick="LoginButton_Click" Font-Size="12pt" Height="42px" Width="102px" />
                </div>
                <div class="col-lg-2" style="padding-bottom: 0">
                    <asp:CheckBox ID="CheckIndex" runat="server" Text="登录后跳转" />
                </div>
            </div>
        <div class="row" style="margin-top: 5%">
            <div class="col-lg-2">
                <asp:Label ID="Result" runat="server" Text="结果显示在这里"></asp:Label>
            </div>
        </div>

        </form>

    </div>
</body>
</html>