<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainPageView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.MainPage.MainPageView" %>
<%@ Register Src="../../SEP/Calendar/DragCalendar.ascx" TagName="DragCalendar" TagPrefix="uc1" %>
<%@ Register Src="../OutApplications/OutApplicationsIndexView.ascx" TagName="OutApplicationsIndexView"
    TagPrefix="uc2" %>
<%@ Register Src="../OverWorks/OverWorksIndexView.ascx" TagName="OverWorksIndexView"
    TagPrefix="uc3" %>
<%@ Register Src="../LeaveRequests/LeaveRequestsIndexView.ascx" TagName="LeaveRequestsIndexView"
    TagPrefix="uc4" %>

<div runat="server" id="all" class="marginepx">


<table width="100%" border="0" cellspacing="0" >
  <tr>
    <td style="width:70%; padding-right:8px;" valign="top" >
    <div class="linetable">
<table width="100%" border="0" cellspacing="0" >
<tr  >
<td class="tdbgpic" style=" padding-left:20px;">
 日历  
</td>
</tr>
<tr>
<td style="padding:8px;">
   <uc1:DragCalendar ID="DragCalendar1" runat="server" />
</td>
</tr>
</table>
</div>
    </td>
    <td style="width:30%" valign="top">
                <table width="100%" border="0" cellspacing="0" >
                <tr>
                <td style="padding-bottom:8px;">
                <div class="linetable">
                <table width="100%" border="0" cellspacing="0" >
                <tr  >
                <td class="tdbgpic" style=" padding-left:20px;">
                 请假 
                </td>
                </tr>
                <tr>
                <td style="padding:8px;">
                <uc4:LeaveRequestsIndexView ID="LeaveRequestsIndexView1" runat="server" />
                </td>
                </tr>
                </table>
                </div>
                </td>
                </tr>
                <tr>
                <td style="padding-bottom:8px;">
                <div class="linetable">
                <table width="100%" border="0" cellspacing="0" >
                <tr  >
                <td class="tdbgpic" style=" padding-left:20px;">
                 外出 
                </td>
                </tr>
                <tr>
                <td style="padding:8px;">
                  <uc2:OutApplicationsIndexView ID="OutApplicationsIndexView1" runat="server" />
                </td>
                </tr>
                </table>
                </div>
                </td>
                </tr>
                <tr>
                <td >
                <div class="linetable">
                <table width="100%" border="0" cellspacing="0" >
                <tr  >
                <td class="tdbgpic" style=" padding-left:20px;">
                 加班 
                </td>
                </tr>
                <tr>
                <td style="padding:8px;">
                 <uc3:OverWorksIndexView ID="OverWorksIndexView1" runat="server" />
                </td>
                </tr>
                </table>
                </div>
                </td>
                </tr>
                </table>
    
    </td>
  </tr>
</table>



</div>