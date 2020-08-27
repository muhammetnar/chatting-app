<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="message_application.signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <center>
        <br />
    <div style="align-content:center; width:500px; height:600px; margin-top:50px; border-radius:70px; box-shadow: 0px 0px 5px 0px #cad0d1; background-color: #EDF1F2;">
        <br />  <br /> 
        <asp:Label ID="Label5" runat="server" Text="New Account" CssClass="label" Font-Size="40px"></asp:Label>
        <table>
           <tr>
               <td>&nbsp;</td>
           </tr>
            <tr>

                <td> <asp:TextBox ID="firstname" runat="server" CssClass="forminput" Width="300" Height="40" placeholder="Name"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ControlToValidate="firstname" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>

                <td> <asp:TextBox ID="lastname" runat="server" CssClass="forminput" Width="300" Height="40" placeholder="Surname"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ControlToValidate="lastname" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>

                <td> <asp:TextBox ID="username" runat="server" CssClass="forminput" Width="300" Height="40" placeholder="Username" AutoCompleteType="Disabled" OnTextChanged="username_Textchanged" AutoPostBack="true"></asp:TextBox>
                    <br/><asp:Label ID="lblusernamemsg" runat="server" Text="" CssClass="label" Font-Size="15px" ></asp:Label>
<%--                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ControlToValidate="email" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr>
               <td></td>
           </tr>
            <tr>
                <td> <asp:TextBox ID="password" runat="server" CssClass="forminput" TextMode="Password" Width="300" Height="40" placeholder="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red" ControlToValidate="password" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td> <asp:TextBox ID="repassword" runat="server" CssClass="forminput" TextMode="Password" Width="300" Height="40" placeholder="Confirm Password"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ForeColor="Red" ControlToValidate="repassword" ControlToCompare="password" ErrorMessage="*"></asp:CompareValidator>
                </td>
            </tr>
           
            <tr>
                <td></td>
            </tr>
            <tr>
                <td>
                   <center><asp:Button ID="btncreate" runat="server" Text="Create Account" CssClass="searchbutton" style="width:200px; height:45px; font-size:18px;" OnClick="btncreate_Click" /><br /><br /></center> </td>
            </tr>
            <tr>
                <td>
                   <center><asp:Button ID="btnbacksignin" runat="server" Text="Back to Signin" CssClass="searchbutton" style="width:200px; height:45px; font-size:18px;" PostBackUrl="~/Default.aspx" /><br /><br /></center> </td>
            </tr>
            <tr>
                <td><asp:Label ID="lblmsg" runat="server" Text="" ForeColor="Red" Font-Size="14px"></asp:Label></td>
            </tr>
        </table>
     
    </div>
        </center>
    </form>
</body>
</html>
