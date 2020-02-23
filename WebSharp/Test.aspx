<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="WebSharp.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Hello World<br />
        </div>
        <asp:Image ID="Image1" runat="server" Height="578px" ImageUrl="IMG_5284.jpg" Width="1112px" />
        <audio src="Dreams%20and%20Hopes.mp3" controls="controls" />
        </audio><br/>
        

        <asp:Label ID="testText" runat="server" Text="Dreams" ForeColor="#FF66CC" ></asp:Label><br/>
        

        <asp:TextBox ID="textBoxTest" runat="server"></asp:TextBox>
        

        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Dreams" />

    </form>
</body>
</html>
