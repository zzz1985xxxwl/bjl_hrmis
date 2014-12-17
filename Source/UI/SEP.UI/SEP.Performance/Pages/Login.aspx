<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SEP.Performance.Pages.Login" %>

<%@ Import Namespace="SEP.Model.Utility" %>
<%@ Register Src="../Views/SEP/Accounts/LoginView.ascx" TagName="LoginView" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>
        <%=CompanyConfig.COMPANYTITLE%>
    </title>
    <link href="CSS/style.css" rel="stylesheet" type="text/css" />
    <script language="javascript " type="text/javascript" src="Inc/jquery.js"></script>
</head>
<body>
    <%--<object id="UsbActiveX" classid="clsid:cb9da3eb-89d4-492c-a9eb-adf638f822ea" style="display:none;"></object>--%>
    <div id="web">
        <div id="login">
            <div id="login1">
                <div id="power">
                    <div id="logo01">
                        <img src="image/login02.jpg" width="194" height="195" />
                    </div>
                    <div id="logo02">
                        <img src="image/login01.jpg" width="313" height="93" />
                    </div>
                    <form id="Form1" method="post" runat="server">
                    <uc1:LoginView ID="LoginView1" runat="server" />
                    </form>
                </div>
            </div>
            <div id="login04">
                Email:<a href="<%=companyMailTo%>"><%=CompanyConfig.SYSTEMMAILADDRESS%></a> Tel:
                <%=CompanyConfig.COMPANYTEL%>
                Fax:<%=CompanyConfig.COMPANYFAX%>
                Copyright ShiXin Enterprise Application Software(Shanghai)Co.,Ltd 2009
            </div>
        </div>
    </div>
</body>
</html>
