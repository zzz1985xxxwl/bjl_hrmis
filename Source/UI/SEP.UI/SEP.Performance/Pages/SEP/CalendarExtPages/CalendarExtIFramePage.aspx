<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalendarExtIFramePage.aspx.cs" Inherits="SEP.Performance.Pages.SEP.CalendarExtPages.CalendarExtIFramePage" %>
<%@ Register Src="../../../Views/SEP/CalendarExt/CalendarExtView.ascx" TagName="CalendarExtView"
    TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:CalendarExtView ID="CalendarExtView1" runat="server" />
    </div>
    </form>
</body>
</html>