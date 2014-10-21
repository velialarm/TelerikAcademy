<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="_02_GenNumServerCrl.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <pre>Using the <b>Web server</b> controls create a Web application for generating random numbers. It should have two input fields defining a range (e.g. [10..20]) and a button to generate a random number in the specified range.</pre>
    <form id="form1" runat="server">
    <div>
        <asp:Label runat="server" Text="From:"></asp:Label>
        <asp:TextBox runat="server" ID="tbFrom"></asp:TextBox>
        <asp:Label runat="server" Text="To:"></asp:Label>
        <asp:TextBox runat="server" ID="tbTo"></asp:TextBox>
        <asp:Button runat="server" Text="Generate Numbers" OnClick="GenerateNumbers"/>
        
        <div>
            <asp:Label runat="server" ID="result"></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>
