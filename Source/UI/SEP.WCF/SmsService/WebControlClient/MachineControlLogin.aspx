<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MachineControlLogin.aspx.cs" Inherits="WebControlClient.MachineControlLogin" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>短信机管理调试页面</title>
    <link href="CSS/style.css" rel="stylesheet" type="text/css" />
</head>
<body style="margin:5px 10px;">
  <form id="form1" runat="server">
   <input id="lbUsbKeyCount" type="hidden" runat="server" />
    <input id="lbUsbKey" type="hidden"  runat="server" />
    <div>
      <div id="Panel1" >

            <table width="100%" class="linetable_3" border="1" cellpadding="0" cellspacing="0" bordercolor="#259517">
              <tr>
                <td height="28" background="image/tdbg02.jpg"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                      <td width="3%" height="23" align="center"><img src="image/icon04.jpg" width="23" height="14"/></td>
                      <td width="61%" align="left"><strong>短信机管理调试页面</strong></td>
                      <td width="36%" align="left">&nbsp;</td>
                    </tr>
                </table></td>
              </tr>
              <tr>
                <td><table width="100%" border="0" cellspacing="0" cellpadding="8">
                    <tr>
                      <td width="33%" height="34" align="center">&nbsp;</td>
                    </tr>
                    <tr>
                      <td align="center" style="height: 57px"><table width="400" height="111" border="0" cellpadding="0" cellspacing="5">
                        <tr>
                          <td width="88" align="right"><span id="Label10">请输入验证码</span></td>
                          <td width="297" align="left"><asp:TextBox ID="TextBox1" CssClass="inputtxtl" runat="server" TextMode="Password"></asp:TextBox>&nbsp;<br/>
                           
                           </td>
                        </tr>
                        <tr>
                          <td align="left">&nbsp;<asp:DropDownList ID="DropDownList1" runat="server">
                                  <asp:ListItem>客户管理中心</asp:ListItem>
                                  <asp:ListItem>短信机管理中心</asp:ListItem>
                              </asp:DropDownList></td>
                          <td align="left"><asp:Button ID="Button1" CssClass="inputbt6" runat="server" OnClick="Button1_Click" Text="进入管理页面" />
                          &nbsp; &nbsp;<asp:Label ID="Label3" runat="server" ForeColor="Red"></asp:Label></td>
                        </tr>
                      </table>
                      <br /></td>
                    </tr>
                </table></td>
              </tr>
        </table>
    </div>
        </div>
         <script language= "javascript " type="text/javascript" src="Inc/UsbKey.js">
</script>
</form>
</body>
</html>