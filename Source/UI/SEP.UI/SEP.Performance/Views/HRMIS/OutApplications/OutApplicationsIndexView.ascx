<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OutApplicationsIndexView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.OutApplications.OutApplicationsIndexView" %>
<table width="99%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="30%" rowspan="3" align="center"><img id="imgOutWork" runat="server" alt="" src="../../../Pages/image/menupic06.jpg" /></td>
    <td width="204" height="23" align="left"><a onclick='window.open("../../Hrmis/OutApplicationPages/OutApplicationList.aspx")'  href="#">你共有<span class="fontred"><asp:Label ID="lblOutWorkNeedConfirm" runat="server"></asp:Label></span>个待审核的外出申请</a></td>
  </tr>
  <tr>
    <td align="left"><img src="../../../Pages/image/menuicon.jpg" width="17" height="16" border="0" align="absmiddle" /><a  onclick='window.open("../../Hrmis/OutApplicationPages/AddOutApplication.aspx")' href="#">我要外出</a></td>
  </tr>
</table>