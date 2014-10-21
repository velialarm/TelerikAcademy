<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="_04_StudentWebForm.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student System Web Form</title>
    <link href="css/style.css" rel="stylesheet" />
</head>
<body>

    <form id="form1" runat="server">
        <div class="container">
            
                <p class="desc">
        Make a simple Web form for registration of students and courses. 
        The form should accept first name, last name, faculty number, university (drop-down list), specialty (drop-down list) and a list of courses (multi-select list) and display them on submit. 
        Use the appropriate Web server controls. After submission you should display summary of the entered information as formatted HTML. 
        Use dynamically generated tags (&lt h1 &gt, &ltp&gt, …).
</p>

            <h3>Students registration form</h3>

            <asp:Label ID="lFirstName" runat="server" CssClass="label">First Name: </asp:Label>
            <asp:TextBox ID="tbFirstName" runat="server" CssClass="tb" /><br />

            <asp:Label ID="lLastName" runat="server" CssClass="label">Last Name: </asp:Label>
            <asp:TextBox ID="tbLastName" runat="server" CssClass="tb" /><br />

            <asp:Label ID="lFacultyNumber" runat="server" CssClass="label">Faculty Number: </asp:Label>
            <asp:TextBox ID="tbFacultyNumber" runat="server" CssClass="tb" /><br />

            <asp:Label ID="lUniversities" runat="server" CssClass="label">Universities: </asp:Label>
            <asp:DropDownList ID="ddListUniversities"
                AutoPostBack="False"
                OnSelectedIndexChanged="UniChange"
                runat="server"
                CssClass="dropdown-list">

                <asp:ListItem Selected="True" Value="Telerik University"> Telerik University </asp:ListItem>
                <asp:ListItem> Sofia University </asp:ListItem>
                <asp:ListItem> UNSS </asp:ListItem>
                <asp:ListItem> TU </asp:ListItem>
            </asp:DropDownList><br />

            <asp:Label ID="lCourses" runat="server" CssClass="label">Courses: </asp:Label>
            <asp:CheckBoxList ID="CkeckBoxListCourses" runat="server">
                <asp:ListItem>C# Programming</asp:ListItem>
                <asp:ListItem>JS Programming</asp:ListItem>
                <asp:ListItem>Databases</asp:ListItem>
                <asp:ListItem>HTML</asp:ListItem>
                <asp:ListItem>CSS</asp:ListItem>
            </asp:CheckBoxList>

            <asp:Button ID="ButtonSubmit" runat="server"
                Text="Generate Student's Data" OnClick="ButtonSubmit_Click" /><br />

        </div>
    </form>
</body>
</html>
