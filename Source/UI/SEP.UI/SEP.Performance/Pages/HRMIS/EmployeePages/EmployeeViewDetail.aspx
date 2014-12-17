<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeViewDetail.aspx.cs" Inherits="SEP.Performance.Pages.EmployeeViewDetail" %>
<%@ Import Namespace="SEP.Model.Utility"%>
<%@ Register Src="../../../Views/HRMIS/EmployeeInformation/EmployeeView.ascx" TagName="EmployeeView"
    TagPrefix="uc4" %>
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title><%=CompanyConfig.COMPANYTITLE%> 员工详情</title>
        <link href="../../CSS/style.css" rel="stylesheet" type="text/css" />
                    <script language="javascript " type="text/javascript" src="../../Inc/jquery.js"></script>
    <script language="javascript " type="text/javascript" src="../../Inc/BaseScript.js" charset="gb2312"></script>
        <script language="javascript " type="text/javascript" src="../../Inc/jquery.validation.js" charset="gb2312"></script>
    <script language="javascript " type="text/javascript" src="../../Inc/jquery.cookie.js" charset="gb2312"></script>
    <script language="javascript " type="text/javascript" src="../../Inc/jquery.json-2.2.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
        </asp:ScriptManager>
        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height: 420px">
            <tr>
                <td align="center" valign="top" id="widthfrom" class="placeholder" style="height: 297px; width:79%;">
                <uc4:EmployeeView id="EmployeeView1" runat="server"></uc4:EmployeeView>

                </td>
            </tr>
        </table>
<div class="footer">
Copyright ShiXin Enterprise Application Software(Shanghai)Co.,Ltd 2009
</div>
    </form>
</body>
</html>

