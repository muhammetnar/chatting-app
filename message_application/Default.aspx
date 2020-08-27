<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="message_application.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/site.css" rel="stylesheet" />
</head>
<body>

     <center>
        
          <form runat="server">
    <div style="align-content:center; width:500px; height:500px; margin-top:100px; border-radius:70px; box-shadow: 0px 0px 5px 0px #cad0d1; background-color: #EDF1F2;">
        <br />  <br /> 
        <asp:Label ID="Label5" runat="server" Text="Sign In" CssClass="label" Font-Size="40px"></asp:Label>
        <table>
           <tr>
               <td>&nbsp;</td>
           </tr>
            <tr>

                <td> <asp:TextBox ID="kadi" runat="server" CssClass="forminput" Width="300" Height="40" placeholder="Username"></asp:TextBox></td>
            </tr>
            <tr>
               <td></td>
           </tr>
            <tr>
                <td> <asp:TextBox ID="sifre" runat="server" CssClass="forminput" Width="300" Height="40"  placeholder="Password" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td>
                   <center><asp:Button ID="BtnLogin" runat="server" Text="Sign In"  OnClick="BtnLogin_Click" CssClass="searchbutton" style="width:220px; height:45px; font-size:18px;" /><br /><br />
                   </center> </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblmsg" runat="server" Text="" CssClass="label"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <asp:Label ID="Label7" runat="server" Text="Or" CssClass="label" Font-Size="25px"></asp:Label><br /><br />
        <asp:Button ID="Button2" runat="server" Text="Create New Account" PostBackUrl="~/signup.aspx" CssClass="searchbutton" style="width:220px; height:45px; font-size:18px;" />
    </div>

          </form>
        </center>
</body>
</html>
