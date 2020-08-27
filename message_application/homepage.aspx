<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="message_application.homepage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/site.css" rel="stylesheet" />
</head>
<body>
    <center>
     <form id="form1" runat="server">
    <div>
    <table>
        <tr>
            <td>
                <div style="float: left; width: 938px; height:50px; line-height: 50px; padding-left: 15px; border: 1px solid #ccc; color: #555; background-color: #EDF1F2;">
                    <table>
                        <tr>
                            <td></td>
                            <td><asp:Button ID="BtnWriteMessage" runat="server" Text="Write New Message" CssClass="searchbutton" OnClick="BtnWriteMessage_Click" /></td>
                            <td style="width:280px;"></td>
                            <td style="width:220px;"> <asp:Button ID="BtnWhatsapp" runat="server" Text="WhatsApp Mami" CssClass="searchbutton" OnClick="BtnWhatsapp_Click"  /></td>
                            <td style="width:210px;">
                                <asp:Label ID="lblid" runat="server" Visible="false"></asp:Label>
                                <asp:Label ID="lblfirstname" runat="server" Text="" CssClass="label" Font-Size="14px" ForeColor="#185AA3"></asp:Label>&nbsp;
                                <asp:Label ID="lbllastname" runat="server" Text="" CssClass="label" Font-Size="14px" ForeColor="#185AA3"></asp:Label>
                            </td>
                            <td><asp:Button ID="BtnSignOut" runat="server" Text="Sign Out" CssClass="searchbutton" OnClick="BtnSignOut_Click" /></td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>

    <table border="0">
        <tr>
            <td>
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                            CellPadding="3" DataKeyNames="MESSAGE_BOX_ID" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                            <Columns>
                                <asp:TemplateField HeaderText="User" ItemStyle-Width="250px" ItemStyle-Height="30px">
                                    <ItemTemplate>
                                        
                                        <asp:Label ID="lblmessageboxid" CssClass="label" Text='<%# DataBinder.Eval(Container,"DataItem.MESSAGE_BOX_ID") %>'
                                            runat="server" Visible="false"></asp:Label>&nbsp;
                                        <asp:Label ID="lblmessageuserid" CssClass="label" Text='<%# DataBinder.Eval(Container,"DataItem.USER_ID") %>'
                                            runat="server" Visible="false"></asp:Label>&nbsp;
                                        <asp:Label ID="lblmessageusername" CssClass="label" Text='<%# DataBinder.Eval(Container,"DataItem.FIRST_NAME") %>'
                                            runat="server" Visible="true"></asp:Label>&nbsp;
                            <asp:Label ID="lblmessageusersurname" CssClass="label" Text='<%# DataBinder.Eval(Container,"DataItem.LAST_NAME") %>'
                                runat="server" Visible="true"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:CommandField ButtonType="Button" SelectText="See Message"
                                    ShowSelectButton="True">

                                    <ControlStyle CssClass="searchbutton" Width="90" />
                                </asp:CommandField>
                            </Columns>
                            <EditRowStyle BackColor="#EDF1F2" />
                            <FooterStyle BackColor="#EDF1F2" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#185AA3" CssClass="label" ForeColor="White" />
                            <PagerStyle BackColor="#EDF1F2" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EDF1F2" Font-Bold="True" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#EDF1F2" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                        
                        <br/>
                        
                     <asp:TextBox ID="Textmessageboxid" runat="server" Visible="false"></asp:TextBox>
                        <asp:TextBox ID="Textmessageuserid" runat="server" Visible="false"></asp:TextBox>
                        <asp:Label ID="lbluserid2" runat="server" Text="" Visible="TRUE"></asp:Label>
                        <asp:Label ID="lblmessageid" runat="server" Text="" Visible="TRUE"></asp:Label>
                    <asp:Label ID="lblmessageboxid" runat="server" Text=""></asp:Label>
                        <asp:Panel runat="server" ID="PnlSeeMessage" Visible="false">
                            <div class="duyurular" style="float: left; width: 955px; height: auto">
                                <div class="ust" style="float: left; width: 938px; height: 52px; line-height: 52px; padding-left: 15px; border: 1px solid #ccc; color: #555; background-color: #EDF1F2;">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Button ID="BtnBack" runat="server" Text="Back" CssClass="searchbutton" OnClick="BtnBack_Click" />
                                                </td><td>
                                                <asp:Button ID="BtnAnswer" runat="server" Text="Answer" CssClass="searchbutton" OnClick="BtnAnswer_Click"  />
                                                </td><td>
                                                <asp:Button ID="BtnDelete" runat="server" Text="Delete Chat" CssClass="searchbutton" OnClick="BtnDelete_Click" />
                                                </td><td>
                                                <asp:Button ID="BtnAnswerBack" runat="server" Text="Back" CssClass="searchbutton" Visible="false" OnClick="BtnAnswerBack_Click"  />
                                                </td><td>
                                                <asp:Label ID="Label4" runat="server" Text="" CssClass="label" ForeColor="Black" Font-Bold="true"></asp:Label></td>
                                            <td class="style36"></td>
                                            <td></td>
                                        </tr>
                                        <tr><td>&nbsp;</td></tr>
                                    </table>
                                </div>
                                <div class="alt" style="float: left; width: 920px; height: auto; padding: 16.5px; border: 1px solid #ccc; background-color: #fff;">
                                    <asp:ListView ID="lstDuyuru" runat="server">

                                        <ItemTemplate>
                                            <div class="duyuru-wrap" style="float: left; width: 920px; height: auto;">
                                                <asp:Label ID="labelmessageusername" runat="server" ForeColor="#185AA3" Font-Size="14px" CssClass="label" Text='<%# Eval("FIRST_NAME") %>'></asp:Label>
                                                <asp:Label ID="labelmessageusersurname" runat="server" ForeColor="#185AA3" Font-Size="14px" CssClass="label" Text='<%# Eval("LAST_NAME") %>'></asp:Label><br />
                                                <br />

                                                <asp:TextBox ID="labelmessagecontent" runat="server" Text='<%# Eval("MESSAGE") %>' TextMode="MultiLine" Width="890px" CssClass="forminput" Height="40px" Font-Size="14px" Wrap="False" ReadOnly="True" ></asp:TextBox><br />
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label3" runat="server" Text="Date & Time :" ForeColor="#185AA3" Font-Size="14px" CssClass="label"></asp:Label>
                                                            <asp:Label ID="label5" runat="server" ForeColor="#185AA3" Font-Size="14px" CssClass="label" Text='<%# Eval("MESSAGE_DATE") %>'></asp:Label>
                                                        </td>

                                                        <td style="width: 160px;">
                                                      
                                                    </tr>
                                                </table>
                                                <hr />
                                            </div>
                                        </ItemTemplate>
                                    </asp:ListView>
                                    <asp:Label ID="labelto" runat="server" Text="To :" Font-Size="14px" CssClass="label" Visible="false"></asp:Label>
                                    <asp:Label ID="labeltoname" runat="server" Text="" Font-Size="14px" CssClass="label" Visible="false"></asp:Label>
                                    <asp:Label ID="labeltosurname" runat="server" Text="" Font-Size="14px" CssClass="label" Visible="false"></asp:Label>
                                    <asp:TextBox ID="TextMessage" runat="server" TextMode="MultiLine" Width="890px" Height="60px" Wrap="False" CssClass="forminput" Visible="false"></asp:TextBox>
                                    <asp:Button ID="BtnSend" runat="server" Text="Send" CssClass="searchbutton" Visible="false" OnClick="BtnSend_Click"/>
                                    <asp:Label ID="lblanswermsg" runat="server" Text="" Visible="false" CssClass="label" Font-Size="14px" ForeColor="Red"></asp:Label>
                                </div>
                            </div>
                        </asp:Panel>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <asp:Button ID="BtnWriteMsgBack" runat="server" Text="Back"  CssClass="searchbutton" />
                        <table>
                            <tr>
                                <td class="style3">
                                    <asp:Label ID="lbluserid" runat="server" Text="" Visible="false"></asp:Label>
                                    <asp:Label ID="Label1" runat="server" Text="Username" CssClass="label"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text=":" CssClass="label"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextSelectUser" runat="server" CssClass="forminput" AutoCompleteType="Disabled" OnTextChanged="TextSelectUser_Textchanged" AutoPostBack="true"></asp:TextBox>
                                    <asp:Label ID="durum" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label8" runat="server" Text="Message" CssClass="label"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Text=":" CssClass="label"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextMessageBox" runat="server" CssClass="forminput" TextMode="MultiLine" Height="150px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td>
                                    <asp:Button ID="BtnWriteMsg" runat="server" Text="Send Message"  CssClass="searchbutton" OnClick="BtnWriteMsg_Click"  /></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td>
                                    <asp:Label ID="lblwritemsg" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>

            </td>
        </tr>
    </table>
    </div>
    </form>
        </center>
</body>
</html>
