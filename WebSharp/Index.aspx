<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebSharp.Index" %>

<!DOCTYPE html>
<style>
    .title { color: #4c4228;  }
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
<body style="background-image: url(Resource/RDR.jpg); background-attachment: fixed; margin-top: -0.5%;">
<div class="container">
    <div class="row" style="margin-top: 10%">
        <div class="container" style="margin-left: 20%; margin-right: 20%;margin-bottom: 5%; background-color: rgb(255, 244, 204); border-radius: 3px; box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075), 2px 2px 10px 2px rgba(53, 31, 13, 0.897);">
            <div class="row" style="text-align: center">
                
                <asp:Label ID="Label7" runat="server" Text="WANTED" Font-Names="Dirty Headline" Font-Size="80pt" ForeColor="#825E09"></asp:Label>

            </div>

            <div class="row">
                <div class="col-lg-12" style="padding-left: 25%; padding-right: 25%">
                    <div class="row" style="margin-top: 5%; margin-bottom: 5%">
                        <div class="col-lg-12" style="text-align: center">
                            <asp:Image ID="Avatar" runat="server" ImageUrl="~/Resource/AM.jpg" Height="256px" />
                        </div>
                    </div>
                        <div class="row" style="margin-top: 5%; margin-bottom: 5%">
                            <div class="col-lg-3 title" style="text-align: right">
                                账号：
                            </div>
                            <div class="col-lg-9" style="text-align: left;">
                                <asp:Label ID="UserAccount" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>

                        <div class="row" style="margin-top: 5%; margin-bottom: 5%">
                            <div class="col-lg-3 title" style="text-align: right">
                                邮箱：
                            </div>
                            <div class="col-lg-9" style="text-align: left;">
                                <asp:Label ID="UserEmail" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>

                        <div class="row" style="margin-top: 5%; margin-bottom: 5%">
                            <div class="col-lg-3 title" style="text-align: right">
                                用户名：
                            </div>
                            <div class="col-lg-9" style="text-align: left;">
                                <asp:Label ID="UserName" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>


                        <div class="row" style="margin-top: 5%; margin-bottom: 5%">
                            <div class="col-lg-3 title" style="text-align: right">
                                邮编：
                            </div>
                            <div class="col-lg-9" style="text-align: left;">
                                <asp:Label ID="UserMail" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>


                        <div class="row" style="margin-top: 5%; margin-bottom: 5%">
                            <div class="col-lg-3 title" style="text-align: right">
                                手机：
                            </div>
                            <div class="col-lg-9" style="text-align: left;">
                                <asp:Label ID="UserPhone" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>



                        <div class="row" style="margin-top: 5%; margin-bottom: 5%">
                            <div class="col-lg-3 title" style="text-align: right">
                                性别：
                            </div>
                            <div class="col-lg-9" style="text-align: left;">
                                <asp:Label ID="UserGender" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>



                        <div class="row" style="margin-top: 5%; margin-bottom: 5%">
                            <div class="col-lg-3 title" style="text-align: right">
                                出生地：
                            </div>
                            <div class="col-lg-9" style="text-align: left;">

                                <asp:Label ID="UserHome" runat="server" Text="Label"></asp:Label>
                                

                            </div>
                        </div>

                        <div class="row" style="margin-top: 5%; margin-bottom: 5%">
                            <div class="col-lg-3 title" style="text-align: right">
                                武器：
                            </div>
                            <div class="col-lg-9" style="text-align: left;">

                                <asp:Label ID="UserWeapon" runat="server" Text="Label"></asp:Label>

                            </div>
                        </div>


                </div>
            </div>
            <div class="row" style="text-align: center">
                <asp:Label ID="Label8" runat="server" Text="DEAD OR ALIVE" Font-Names="Dirty Headline" Font-Size="50pt" ForeColor="#825E09"></asp:Label>
                
            </div>
        </div>
    </div>
</div>
</body>
</html>