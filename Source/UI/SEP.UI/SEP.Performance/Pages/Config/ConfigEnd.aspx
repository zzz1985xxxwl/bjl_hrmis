<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfigEnd.aspx.cs" Inherits="SEP.Performance.Pages.Config.ConfigEnd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>完成</title>
    <link href="../CSS/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
  <div class="leftitbor2">设置完成</div>
  <div class="tablebt">
<asp:button ID="btnBack" runat="server" CssClass="inputbtcss" text="上一步" OnClick="btnBack_Click" />
<asp:button ID="btnLogin" runat="server" CssClass="inputbtcss" text="完成，登录系统" OnClick="btnLogin_Click" />
</div>
    </div>
    </form>
</body>
</html>
