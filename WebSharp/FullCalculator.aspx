<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FullCalculator.aspx.cs" Inherits="WebSharp.FullCalculator" %>

<!DOCTYPE html>

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
<body>
<div class="container" style="padding-left: 20%; padding-right: 20%">
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-lg-12" style="text-align: center; font-size: 50px">
                计算器
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <asp:TextBox ID="Input" runat="server"></asp:TextBox>
                &nbsp;=
                <asp:Label ID="Result" runat="server" Text="结果"></asp:Label>
            </div>
        </div>
        <div class="row" style="margin-top: 10%">
            <div class="col-lg-4">
                <asp:Button ID="Button1" runat="server" Text="1" OnClick="Text_OnClick"/>
                <asp:Button ID="Button2" runat="server" Text="2" OnClick="Text_OnClick"/>
                <asp:Button ID="Button3" runat="server" Text="3" OnClick="Text_OnClick"/>
                <asp:Button ID="ButtonP" runat="server" Text="+" OnClick="Text_OnClick"/>

            </div>
        </div>
        <div class="row">
            <div class="col-lg-4">
                <asp:Button ID="Button4" runat="server" Text="4" OnClick="Text_OnClick"/>
                <asp:Button ID="Button5" runat="server" Text="5" OnClick="Text_OnClick"/>
                <asp:Button ID="Button6" runat="server" Text="6" OnClick="Text_OnClick"/>
                <asp:Button ID="ButtonMi" runat="server" Text="-" OnClick="Text_OnClick"/>

            </div>
        </div>
        <div class="row">
            <div class="col-lg-4">
                <asp:Button ID="Button7" runat="server" Text="7" OnClick="Text_OnClick"/>
                <asp:Button ID="Button8" runat="server" Text="8" OnClick="Text_OnClick"/>
                <asp:Button ID="Button9" runat="server" Text="9" OnClick="Text_OnClick"/>
                <asp:Button ID="ButtonMu" runat="server" Text="*" OnClick="Text_OnClick"/>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-4">
                <asp:Button ID="Button0" runat="server" Text="0" OnClick="Text_OnClick"/>
                <asp:Button ID="ButtonE" runat="server" Text="=" Width="52px" OnClick="ButtonE_OnClick"/>
                <asp:Button ID="ButtonD" runat="server" Text="/" OnClick="Text_OnClick" Height="26px"/>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-4">
                <asp:Button ID="ButtonL" runat="server" Text="(" OnClick="Text_OnClick"/>
                <asp:Button ID="ButtonR" runat="server" Text=")" OnClick="Text_OnClick"/>
                <asp:Button ID="ButtonReset" runat="server" Text="Reset" Width="52px" OnClick="ButtonReset_OnClick"/>
            </div>
        </div>
    </form>
</div>
</body>
</html>