<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RankingList.aspx.cs" Inherits="WebSharp.RankingList" %>

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

<body style="background-image: url(Resource/RDR.jpg); background-attachment: fixed; margin-top: -0.5%;">
<form id="form1" runat="server">
    <div class="container" style="margin-top: 5%; margin-left: 20%; margin-right: 10%; margin-bottom: 5%; background-color: rgb(255, 244, 204); border-radius: 3px; box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075), 2px 2px 10px 2px rgba(53, 31, 13, 0.897);">
       <div class="row" style="padding-top: 5%;">
        <div class="col-lg-12">
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"  HorizontalAlign="Center">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField HeaderText="操作" ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True">
                    <ItemStyle Wrap="False" />
                    </asp:CommandField>
                    <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
                    <asp:ImageField DataAlternateTextField="ID" DataImageUrlField="ID" ReadOnly="True"
                                    HeaderText="Avatar" DataImageUrlFormatString="Users/Avatars/{0}.jpg" ControlStyle-Height="128px" ControlStyle-Width="128px">

                    </asp:ImageField>
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                    <asp:BoundField DataField="Age" HeaderText="Age" SortExpression="Age" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address">
                    <ItemStyle Width="100px" Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
                </Columns>
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />
            </asp:GridView>
        </div>
       </div>
    <div class="row" style="text-align: center; margin-top: 5%; margin-left: 30%;margin-bottom: 5%">
    <div class="col-lg-12">
        <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="259px" AllowPaging="True" AutoGenerateRows="False" CellPadding="4" DataKeyNames="ID" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <CommandRowStyle BackColor="#FFFFC0" Font-Bold="True" />
                <FieldHeaderStyle BackColor="#FFFF99" Font-Bold="True" />
                <Fields>
                    <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                    <asp:BoundField DataField="Age" HeaderText="Age" SortExpression="Age" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                    <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True" />
                </Fields>
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            </asp:DetailsView>
        </div>
    </div>
    <div class="row">
    <div class="col-lg-12">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                           ConnectionString="Data Source=DESKTOP-CSPPMMH;Initial Catalog=UserInfo;Integrated Security=True" 
                           DeleteCommand="DELETE FROM [UserRankInfo] WHERE [ID] = @ID" 
                           InsertCommand="INSERT INTO [UserRankInfo] ([ID], [Name], [Gender], [Age], [Email], [Address], [Password]) VALUES (@ID, @Name, @Gender, @Age, @Email, @Address, @Password)" 
                           ProviderName="System.Data.SqlClient" SelectCommand="SELECT [ID], [Name], [Gender], [Age], [Email], [Address], [Password] FROM [UserRankInfo]" 
                           UpdateCommand="UPDATE [UserRankInfo] SET [Name] = @Name, [Gender] = @Gender,  [Age] = @Age, [Email] = @Email, [Address] = @Address, [Password] = @Password WHERE [ID] = @ID">
                <DeleteParameters>
                    <asp:Parameter Name="ID" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="ID" Type="String" />
                    <asp:Parameter Name="Name" Type="String" />
                    <asp:Parameter Name="Gender" Type="String" />
                    <asp:Parameter Name="Age" Type="String" />
                    <asp:Parameter Name="Email" Type="String" />
                    <asp:Parameter Name="Address" Type="String" />
                    <asp:Parameter Name="Password" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Name" Type="String" />
                    <asp:Parameter Name="Gender" Type="String" />
                    <asp:Parameter Name="Age" Type="String" />
                    <asp:Parameter Name="Email" Type="String" />
                    <asp:Parameter Name="Address" Type="String" />
                    <asp:Parameter Name="Password" Type="String" />
                    <asp:Parameter Name="ID" Type="String" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
    </div>

    </div>
</form>

</body>
</html>
