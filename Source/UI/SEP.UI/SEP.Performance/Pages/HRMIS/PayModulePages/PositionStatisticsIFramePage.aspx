<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PositionStatisticsIFramePage.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.PayModulePages.PositionStatisticsIFramePage" %>

<%@ Register Src="../../../Views/HRMIS/PayModuleViews/EmployeeSalaryStatistics/SummaryStatistics/IndexView/PositionStatisticsIndexView.ascx"
    TagName="PositionStatisticsIndexView" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
   <link href="../../CSS/style.css" rel="stylesheet" type="text/css" />
      <script language="javascript " type="text/javascript" src="../../Inc/jquery.js"></script>
    <script language="javascript " type="text/javascript" src="../../Inc/BaseScript.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"> </asp:ScriptManager>
    <div>
        <uc1:PositionStatisticsIndexView ID="PositionStatisticsIndexView1" runat="server" />
    
    </div>
    </form>
</body>
</html>
