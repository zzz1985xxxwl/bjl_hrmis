<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LeaveRequestsIndexView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.LeaveRequests.LeaveRequestsIndexView" %>
<table width="99%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td rowspan="2" align="center" style="width:30%"><img id="imgLeaveRequest" runat="server" alt="" src="../../../Pages/image/menupic05.jpg"/></td>
    <td width="204" align="left" style="height: 22px"><a onclick='window.open("../../Hrmis/LeaveRequestPages/MyLeaveRequest.aspx");' href="#">�㹲��<span class="fontred"><asp:Label ID="lblLeaveRequestConfirmCount" runat="server"></asp:Label></span>������˵���ٵ�</a></td>
  </tr>
  <tr>
    <td align="left"><a href="#"  onclick='window.open("../../Hrmis/LeaveRequestPages/AddLeaveRequest.aspx");' ><img src="../../../Pages/image/menuicon.jpg" width="17" height="16" border="0" align="absmiddle" />��Ҫ���</a></td>
  </tr>
</table>