<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowArray.aspx.cs" Inherits="WebSharp.ShowArray" %>

<!DOCTYPE html>
<style>
    .title { color: #4c4228;  }
    .custom-confirm-btn {
        background-color: #3764be;
        border: 2px solid #3764be;
        border-radius: 10px;
        color: #ffffff;
        width: 100%;
        font-size: 20px !important;
    }

    .custom-confirm-btn:hover {
        background-color: #00c4ff;
        border-color: #00c4ff;
        box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075), 0 0 8px 1px rgba(0, 196, 255,0.50);
        color: rgb(255, 255, 255) !important;
    }

    .custom-confirm-btn:focus {
        background-color: #00c4ff;
        border-color: #00c4ff;
        color: rgb(255, 255, 255);
    }

    .custom-confirm-btn:active {
        background-color: #00c4ff;
        border-color: #00c4ff;
        box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075), 0 0 8px 3px rgba(0, 196, 255,0.50);
        color: rgb(255, 255, 255);
    }
</style>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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

    <title>Array Test</title>
</head>

<body>
<form id="form1" runat="server">
    <div class="container">
        <div class="row" style="text-align: left;margin-top: 4%">
            <div class="col-lg-2">
                <asp:Button ID="NormalArray" runat="server" Text="[]"  CssClass="btn custom-confirm-btn" OnClick="NormalArray_Click" />
            </div>
            <div class="col-lg-2">
                <asp:Button ID="Array" runat="server" Text="Array"  CssClass="btn custom-confirm-btn" OnClick="Array_Click" />
            </div>
            <div class="col-lg-2">
                <asp:Button ID="ArrayList" runat="server" Text="ArrayList"  CssClass="btn custom-confirm-btn" OnClick="ArrayList_Click" />
            </div>
            <div class="col-lg-2">
                <asp:Button ID="List" runat="server" Text="List"  CssClass="btn custom-confirm-btn" OnClick="List_Click" />
            </div>
            <div class="col-lg-2">
                <asp:Button ID="Dictionary" runat="server" Text="Dictionary"  CssClass="btn custom-confirm-btn" OnClick="Dictionary_Click" />
            </div>
            <div class="col-lg-2">
                <asp:Button ID="HashTable" runat="server" Text="HashTable"  CssClass="btn custom-confirm-btn" OnClick="HashTable_Click" />
            </div>
        </div>
        
        <div class="row" style="margin-top: 5%">
            <div class="col-lg-6">
                <asp:Label ID="Info" runat="server" Text="Label"></asp:Label>
            </div>
            <div class="col-lg-6">
                <div class="row" id="AddElementDiv" runat="server" Visible="True" >
                    <div class="col-lg-4">
                        新增元素：<asp:TextBox ID="AddElement" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-2">
                        <asp:Button ID="AddButton" runat="server" Text="增加" CssClass="btn custom-confirm-btn" OnClick="AddButton_Click" />
                    </div>
                </div>
                <div class="row" id="AddKeyValueDiv" runat="server" Visible="False">
                    <div class="col-lg-4">
                        新增键值对：键：<asp:TextBox ID="AddKey" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-4">
                        值：<asp:TextBox ID="AddValue" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-2">
                        <asp:Button ID="AddKeyValueButton" runat="server" Text="增加" CssClass="btn custom-confirm-btn" OnClick="AddKeyValueButton_Click" />
                    </div>
                </div>
                <div class="row" style="margin-top: 8%">
                    <div class="col-lg-4">
                        删除元素：<asp:TextBox ID="RemoveElement" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-2">
                        <asp:Button ID="RemoveElementButton" runat="server" Text="删除" CssClass="btn custom-confirm-btn" OnClick="RemoveElementButton_Click"/>
                    </div>
                </div>

                <div class="row" style="margin-top: 8%" runat="server" id="RemoveKeyDiv" Visible="False">
                    <div class="col-lg-4">
                        删除键：<asp:TextBox ID="RemoveKey" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-lg-2">
                        <asp:Button ID="RemoveKeyButton" runat="server" Text="删除" CssClass="btn custom-confirm-btn" OnClick="RemoveKeyButton_Click"/>
                    </div>
                </div>
                <div class="row" style="margin-top: 8%">
                    <div class="col-lg-3">
                        <asp:Button ID="SequenceSort" runat="server" Text="顺序排序" CssClass="btn custom-confirm-btn" OnClick="SequenceSort_Click" />

                    </div>
                    <div class="col-lg-3">
                        <asp:Button ID="ReverseSort" runat="server" Text="逆序排序" CssClass="btn custom-confirm-btn" OnClick="ReverseSort_Click"/>
                    </div>
                </div>
            </div>
            
        </div>

    </div>

    </form>
</body>
</html>
