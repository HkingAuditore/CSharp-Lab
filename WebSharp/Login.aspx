<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebSharp.Login" %>

<!DOCTYPE html>
<style>
    .custom-confirm-btn {
        background-color: #ffffff;
        border: 2px solid #f36c36;
        border-radius: 30px;
        color: #f36c36;
        width: 100%;
    }

    .custom-confirm-btn:hover {
        background-color: #f36c36;
        border-color: #f36c36;
        box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075), 0 0 8px 1px rgba(252, 166, 96, 0.897);
        color: rgb(255, 255, 255) !important;
    }

    .custom-confirm-btn:focus {
        background-color: #f36c36;
        border-color: #f36c36;
        color: rgb(255, 255, 255);
    }

    .custom-confirm-btn:active {
        background-color: #f36c36;
        border-color: #f36c36;
        box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075), 0 0 8px 3px rgba(252, 153, 96, 0.897);
        color: rgb(255, 255, 255);
    }

    .title { color: #ffffff; }
</style>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8"/>
    <meta content="width=device-width, initial-scale=1.0" name="viewport"/>
    <meta content="ie=edge" http-equiv="X-UA-Compatible"/>
    <meta content="width=device-width, initial-scale=1.0" name="viewport"/>
    <meta content="ie=edge" http-equiv="X-UA-Compatible"/>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="Content/bootstrap.css" rel="stylesheet"/>
    <link href="Content/bootstrap-theme.css" rel="stylesheet"/>
    <script src="Content/bootstrap.min.js"></script>
    <script src="Content/jquery-1.10.2.js"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Red Dead Redemption</title>
</head>

<body style="background-image: url(Resource/RDR.jpg); background-attachment: fixed; margin-top: -0.5%;">
<div class="container">
<div class="row" style="margin-top: 10%">
    <div class="container" style="margin-bottom: 5%; background-color: rgba(36, 7, 5, 0.6); backdrop-filter: blur(10px); border-radius: 30px; box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075), 2px 2px 10px 2px rgba(53, 31, 13, 0.897);">
        <div class="row">
            <h1 style="text-align: center; color: rgb(208, 176, 124); font-size: 60px;">登录</h1>
        </div>
        <div class="row">
            <div class="col-lg-12" style="padding-left: 30%; padding-right: 30%">
                <form id="form1" runat="server">


                    <div class="row" style="margin-top: 5%; margin-bottom: 5%">
                        <div class="col-lg-3 title" style="text-align: right">
                            账户：
                        </div>
                        <div class="col-lg-9" style="text-align: left;">
                            <asp:TextBox ID="UserID" runat="server" Width="80%"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row" style="margin-top: 5%; margin-bottom: 5%">
                        <div class="col-lg-3 title" style="text-align: right">
                            密码：
                        </div>
                        <div class="col-lg-9" style="text-align: left;">
                            <asp:TextBox ID="UserPassword" runat="server" Width="80%" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>


                    <div class="row" style="margin-top: 1%">
                        <div class="col-lg-3 title" style="text-align: right">
                            <label>验证码</label>
                        </div>
                        <div class="col-lg-5">
                            <asp:TextBox type="text" class="form-control" ID="txtCaptcha" runat="server" ToolTip="请输入验证码" ValidateRequestMode="Enabled" Width="90px"></asp:TextBox>
                        </div>
                        <div class="col-lg-4">
                            <img id="imgCode" alt="看不清，请单击我！" src="PlugIns/Validata.aspx" onclick="this.src = this.src + '?'" style="vertical-align: bottom"/>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-12">
                            <div style="padding: 5%; padding-left: 40%; padding-right: 40%; text-align: center">
                                <asp:Button ID="Confirm" runat="server" Text="登录" CssClass="btn custom-confirm-btn" OnClick="Confirm_OnClick"/>
                            </div>
                        </div>
                    </div>

                </form>
            </div>
        </div>
    </div>
</div>
</div>
</body>
</html>