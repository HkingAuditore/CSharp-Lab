<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bank.aspx.cs" Inherits="WebSharp.Bank" %>

<!DOCTYPE html>
<style>
    .title { color: #4c4228;  }
    .custom-confirm-btn {
        background-color: #826936;
        border: 2px solid #f36c36;
        border-radius: 30px;
        color: #ffffff;
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
</style>

<html xmlns="http://www.w3.org/1999/xhtml">
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
<%-- <script> --%>
<%--     document.getElementById(playerLine3).style.display = 'none'; --%>
<%-- </script> --%>
<body style="background-image: url(Resource/RDR.jpg); background-attachment: fixed; margin-top: -0.5%;">
<form id="form1" runat="server">
    <div class="container" style="margin-top: 5%; margin-left: 20%; margin-right: 20%; margin-bottom: 5%; background-color: rgb(255, 244, 204); border-radius: 3px; box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075), 2px 2px 10px 2px rgba(53, 31, 13, 0.897);">
        <div class="row">
            <div class="col-lg-12" style="text-align: center;margin-top: 5%">
                <asp:Label ID="Label1" runat="server" Text="银行" Font-Names="汉仪力量黑简" Font-Size="50pt"></asp:Label>
            </div>
        </div>
        
        <div class="row" style="margin-top: 5%;margin-bottom: 5%">
            <div class="col-lg-3 title" style="text-align: right">
                手头现金：
            </div>
            <div class="col-lg-9" style="text-align: left;">
                <asp:Label ID="UserCash" runat="server" Text="余额"></asp:Label>
            </div>
        </div>

        <div class="row" style="margin-top: 5%;margin-bottom: 5%">
            <div class="col-lg-3 title" style="text-align: right">
                选择地点：
            </div>
            <div class="col-lg-9" style="text-align: left;">
                <asp:DropDownList ID="Place" runat="server" OnSelectedIndexChanged="Place_OnSelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Value = "0x01">圣丹尼斯</asp:ListItem>
                <asp:ListItem Value = "0x02">罗兹</asp:ListItem>
                <asp:ListItem Value = "0x04">瓦伦丁</asp:ListItem>
                <asp:ListItem Value = "0x08">黑水镇</asp:ListItem>
                <asp:ListItem Value = "0x010">草莓镇</asp:ListItem>
                <asp:ListItem Value = "0x020">比彻之愿</asp:ListItem>
                <asp:ListItem Value = "0x040">大地之心</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

        <div class="row" style="margin-top: 5%;margin-bottom: 5%">
            <div class="col-lg-3 title" style="text-align: right">
                选择账户：
            </div>
            <div class="col-lg-9" style="text-align: left;">
                <asp:DropDownList ID="BankAccount" runat="server" AutoPostBack="true" OnSelectedIndexChanged="BankAccount_OnSelectedIndexChanged">

                </asp:DropDownList>
            </div>
        </div>

        <div class="row" style="margin-top: 5%;margin-bottom: 5%">
            <div class="col-lg-3 title" style="text-align: right">
                账户余额：
            </div>
            <div class="col-lg-9" style="text-align: left;">
                <asp:Label ID="BankBalance" runat="server" Text="余额"></asp:Label>
            </div>
        </div>

        <div class="row" style="margin-top: 5%;margin-bottom: 5%">
            <div class="col-lg-3 title" style="text-align: right">
                开新账户：
            </div>
            <div class="col-lg-3" style="text-align: left;">
                <asp:TextBox ID="OpeningAccount" runat="server" Width="268px"></asp:TextBox>
            </div>
            <div class="col-lg-1" style="text-align: left;">
                <asp:Button ID="Open" CssClass="btn custom-confirm-btn" runat="server" Text="开户" OnClick="Open_OnClick" />
            </div>
        </div>

        <div class="row" style="margin-top: 5%;margin-bottom: 5%">
            <div class="col-lg-3 title" style="text-align: right">
                转账：
            </div>
            <div class="col-lg-2" style="text-align: left;">
                <asp:DropDownList ID="TransferTarget" runat="server"  Width="176px">
                </asp:DropDownList>
            </div>
            <div class="col-lg-1" style="text-align: left;">
                <asp:TextBox ID="TransferMoney" runat="server" Width="87px"></asp:TextBox>
            </div>

            <div class="col-lg-1" style="text-align: left;">
                <asp:Button ID="Transfer" CssClass="btn custom-confirm-btn" runat="server" Text="转账" OnClick="Transfer_OnClick"/>
            </div>
        </div>

        <div class="row" style="margin-top: 5%;margin-bottom: 5%">
            <div class="col-lg-3 title" style="text-align: right">
                存取现金：
            </div>
            <div class="col-lg-2" style="text-align: left;">
                <asp:DropDownList ID="DealChoice" runat="server"  Width="176px">
                    <asp:ListItem Value="0">存</asp:ListItem>
                    <asp:ListItem Value="1">取</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-lg-1" style="text-align: left;">
                <asp:TextBox ID="DealMoney" runat="server" Width="87px"></asp:TextBox>
            </div>

            <div class="col-lg-1" style="text-align: left;">
                <asp:Button ID="Deal" CssClass="btn custom-confirm-btn" runat="server" Text="确定" OnClick="Deal_OnClick" />
            </div>
        </div>
        <div class="row" style="text-align: center;padding-left: 20%;padding-right: 20%;padding-bottom:10%">
            <div class="col-lg-12" >
                <asp:Button ID="Back" runat="server"  CssClass="btn custom-confirm-btn" Text="返回个人界面" OnClick="Back_OnClick_OnClick"/>

            </div>
        </div>


    </div>
</form>

</body>
</html>