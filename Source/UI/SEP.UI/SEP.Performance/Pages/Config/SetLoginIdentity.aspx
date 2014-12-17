<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetLoginIdentity.aspx.cs" Inherits="SEP.Performance.Pages.Config.SetLoginIdentity" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>设置系统管理员密码</title>
    <link href="../CSS/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <div class="leftitbor2"> 系统管理员登录</div>
     <div class="edittable">
        <table style="width: 100%;">
            <tr>
                <td style="width: 20%; text-align:left">
                    请输入administrator登录密码 * 
                </td>
                <td style="width: 80%">
                    <asp:TextBox ID="txtAdminPWD" runat="server" CssClass="input" Width="200px" TextMode="Password"></asp:TextBox>
                    <asp:Label ID="lblAdminPWDMsg" CssClass="psword_f" runat="server"></asp:Label></td>
            </tr>
        </table>
        </div>
       <div class="tablebt">
                    <asp:Button ID="btnEnter" runat="server" CssClass="inputbtcss" OnClick="btnEnter_Click" Text="下一步" /></td>
        </div>
    </div>
    </form>
</body>
</html>
