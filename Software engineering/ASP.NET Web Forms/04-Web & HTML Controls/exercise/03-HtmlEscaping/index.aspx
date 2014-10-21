<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="_03_HtmlEscaping.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Html Escaping</title>
</head>
<body>
    <p style="width: 300px;">
        Define a Web form with text box and button. On button click show the entered in the first textbox text in other textbox control and label control. Enter some potentially dangerous text. Fix issues related to HTML escaping –the application should accept HTML tags and display them correctly.
    <hr />
    </p>
    <form id="form1" runat="server">
        <div>
            <asp:Label Text="EnterText: " runat="server" />
            <asp:TextBox ID="tbValue" runat="server" /><br />
            <asp:Button Text="Submit" runat="server" ID="ButtonSubmit" OnClick="BtnClickOne" /><br />

            <asp:Label Text="Escaped text: " runat="server" /><br />
            <asp:TextBox ID="tbEscText" runat="server" /><br />

            <asp:Label Text="Escaped text:" runat="server" /><br />
            <asp:Label ID="lEscText" runat="server" Mode="Encode">
                <%: this.tbValue.Text %>
            </asp:Label><br />

        </div>
    </form>
</body>
</html>
