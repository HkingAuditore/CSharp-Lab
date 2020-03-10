<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Gamble.aspx.cs" Inherits="WebSharp.Gamble" %>

<!DOCTYPE html>
<style>
    .title { color: #4c4228;  }
    .custom-confirm-btn {
        background-color: #826936;
        border: 2px solid #f36c36;
        border-radius: 30px;
        color: #ffffff;
        width: 100%;
        font-size: 40px !important;
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
                <asp:Label ID="Label1" runat="server" Text="酒馆赌场" Font-Names="汉仪力量黑简" Font-Size="50pt"></asp:Label>
            </div>
        </div>

        <div class="row" style="margin-top: 2%;margin-bottom: 2%">
            <div class="col-lg-2 col-lg-offset-3" style="text-align: right">
                现有财产：
            </div>
            <div class="col-lg-4" style="text-align: left">
                <asp:Label ID="UserMoney" runat="server" Text="Label"></asp:Label>
            </div>
        </div>

        <div class="row" style="margin-top: 2%;margin-bottom: 2%">
            <div class="col-lg-2 col-lg-offset-3" style="text-align: right">
                您要下注：
            </div>
            <div class="col-lg-4" style="text-align: left">
                <asp:TextBox ID="GambleMoney" runat="server"></asp:TextBox>
            </div>
        </div>

        <div id="DiceDiv" class="row" style="margin-top: 2%;margin-bottom: 2%" runat="server">
            <div class="col-lg-2 col-lg-offset-3" style="text-align: right">
                开盘结果：
            </div>
            <div class="col-lg-4" style="text-align: left">
                <asp:Label ID="Dice" runat="server" Text="结果"></asp:Label>
            </div>
        </div>

        <div class="row" style="margin-top: 2%;margin-bottom: 2%">
            <div class="col-lg-2 col-lg-offset-3" style="text-align: right">
                本轮总赌资：
            </div>
            <div class="col-lg-4" style="text-align: left">
                <asp:Label ID="AllMoney" runat="server" Text="赌资"></asp:Label>
            </div>
        </div>
        <div class="row" style="padding-left: 20%;padding-right: 20%">
            <div class="row" style="margin-top: 2%; margin-bottom: 2%">
                <div class="col-lg-12" style="text-align: left">
                    本场赌局玩家：
                </div>

            </div>
            <div class="row">
                <div class="row" id="playerLine1" style="margin-top: 2%; margin-bottom: 2%"  runat="server">
                    <div class="col-lg-3" style="text-align: center">
                        <asp:Image ID="PlayerImage1" runat="server" Height="128px"/><br/>
                        <asp:Label ID="PlayerName1" runat="server" Text=""></asp:Label><br/>
                        <asp:Label ID="PlayerMoney1" runat="server" Text=""></asp:Label><br/>
                        <asp:Label ID="PlayerChoose1" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="col-lg-3" style="text-align: center">
                        <asp:Image ID="PlayerImage2" runat="server" Height="128px"/><br/>
                        <asp:Label ID="playerName2" runat="server" Text=""></asp:Label><br/>
                        <asp:Label ID="playerMoney2" runat="server" Text=""></asp:Label><br/>
                        <asp:Label ID="playerChoose2" runat="server" Text=""></asp:Label>


                    </div>
                    <div class="col-lg-3" style="text-align: center">
                        <asp:Image ID="PlayerImage3" runat="server" Height="128px"/><br/>
                        <asp:Label ID="PlayerName3" runat="server" Text=""></asp:Label><br/>
                        <asp:Label ID="PlayerMoney3" runat="server" Text=""></asp:Label><br/>
                        <asp:Label ID="PlayerChoose3" runat="server" Text=""></asp:Label>


                    </div>
                    <div class="col-lg-3" style="text-align: center">
                        <asp:Image ID="PlayerImage4" runat="server" Height="128px"/><br/>
                        <asp:Label ID="PlayerName4" runat="server" Text=""></asp:Label><br/>
                        <asp:Label ID="PlayerMoney4" runat="server" Text=""></asp:Label><br/>
                        <asp:Label ID="PlayerChoose4" runat="server" Text=""></asp:Label>


                    </div>

                </div>
                <div class="row" id="playerLine2" style="margin-top: 2%; margin-bottom: 2%" runat="server">
                    <div class="col-lg-3" style="text-align: center">
                        <asp:Image ID="PlayerImage5" runat="server" Height="128px"/><br/>
                        <asp:Label ID="PlayerName5" runat="server" Text=""></asp:Label><br/>
                        <asp:Label ID="PlayerMoney5" runat="server" Text=""></asp:Label><br/>
                        <asp:Label ID="PlayerChoose5" runat="server" Text=""></asp:Label>


                    </div>
                    <div class="col-lg-3" style="text-align: center">
                        <asp:Image ID="PlayerImage6" runat="server" Height="128px"/><br/>
                        <asp:Label ID="PlayerName6" runat="server" Text=""></asp:Label><br/>
                        <asp:Label ID="PlayerMoney6" runat="server" Text=""></asp:Label><br/>
                        <asp:Label ID="PlayerChoose6" runat="server" Text=""></asp:Label>


                    </div>
                    <div class="col-lg-3" style="text-align: center">
                        <asp:Image ID="PlayerImage7" runat="server" Height="128px"/><br/>
                        <asp:Label ID="PlayerName7" runat="server" Text=""></asp:Label><br/>
                        <asp:Label ID="PlayerMoney7" runat="server" Text=""></asp:Label><br/>
                        <asp:Label ID="PlayerChoose7" runat="server" Text=""></asp:Label>


                    </div>
                    <div class="col-lg-3" style="text-align: center">
                        <asp:Image ID="PlayerImage8" runat="server" Height="128px"/><br/>
                        <asp:Label ID="PlayerName8" runat="server" Text=""></asp:Label><br/>
                        <asp:Label ID="PlayerMoney8" runat="server" Text=""></asp:Label><br/>
                        <asp:Label ID="PlayerChoose8" runat="server" Text=""></asp:Label>


                    </div>

                </div>
                <div class="row" id="playerLine3" style="margin-top: 2%; margin-bottom: 2%" runat="server">
                    <div class="col-lg-3" style="text-align: center">
                        <asp:Image ID="PlayerImage9" runat="server" Height="128px"/><br/>
                        <asp:Label ID="PlayerName9" runat="server" Text=""></asp:Label><br/>
                        <asp:Label ID="PlayerMoney9" runat="server" Text=""></asp:Label><br/>
                        <asp:Label ID="PlayerChoose9" runat="server" Text=""></asp:Label>

                    </div>

                </div>
            </div>
        </div>

        <div class="row" style="margin-top: 5%;margin-bottom: 5%">
            <div class="col-lg-6" style="text-align: center; padding-left: 30%;padding-right: 5%">
                <asp:Button ID="BigButton" runat="server" Text="押大" CssClass="btn custom-confirm-btn" Font-Names="汉仪力量黑简" OnClick="BigButton_OnClick"/>
            </div>
            <div class="col-lg-6" style="text-align: center; padding-left: 5%;padding-right: 30%">
                <asp:Button ID="SmallButton" runat="server" Text="押小" CssClass="btn custom-confirm-btn" Font-Names="汉仪力量黑简" OnClick="SmallButton_OnClick"/>
            </div>
        </div>

        <div class="row" style="margin-top: 2%;margin-bottom: 10%">
            <div class="col-lg-12" style="text-align: center; padding-left: 30%;padding-right: 30%">
                <asp:Button ID="RebuildButton" runat="server" Text="重置赌局" CssClass="btn custom-confirm-btn" Font-Names="汉仪力量黑简" OnClick="RebuildButton_OnClickButton_OnClick"/>
            </div>
        </div>
    </div>
</form>

</body>
</html>