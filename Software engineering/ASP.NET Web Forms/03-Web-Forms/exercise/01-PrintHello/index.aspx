<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="_01_PrintHello.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <p>Enter your name: </p>
                <asp:TextBox runat="server" ID="tbEnterName" />
                <asp:Button runat="server" ID="bShowMsg" OnClick="bShowMsg_OnClick" Text="Click Me" />
            </div>
            <hr/>
            <h2>
                
                <asp:Label runat="server" ID="lMsg" />
            </h2>
        </div>
    </form>
</body>
</html>
