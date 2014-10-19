<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="_01_GenRandomNumbers.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <pre>Using the HTML server controls create a Web application for generating random numbers. It should have two input fields defining a range (e.g. [10..20]) and a button to generate a random number in the specified range.</pre>
    <form id="form1" runat="server">
        <div>
            <span>Enter Number from: </span>
            <input type="text" id="inpFrom" runat="server" /><br />
            <span>Enter Number to: </span>
            <input type="text" id="inpTo" runat="server" /><br />
            <input type="button" value="Generate numbers" runat="server" onserverclick="GenerateNumbers" />
            <hr />

            <div class="result" id="result" runat="server"></div>
        </div>
    </form>
</body>
</html>
