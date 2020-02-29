<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebSharp.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-6">
                登录成功！
            </div>
        </div>
        <div class="row">
            <div class="col-lg-4">
                您的用户名是：
            </div>
            <div class="col-lg-6">
                <asp:Label ID="UserName" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-4">
                您的性别是：
            </div>
            <div class="col-lg-6">
                <asp:Label ID="UserGender" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
    </div>
    
    </form>
    
</body>
</html>