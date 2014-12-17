<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OverWorksIndexView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.OverWorks.OverWorksIndexView" %>
<table width="99%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="30%" rowspan="2" align="center"><img id="imgOverTime" runat="server" alt="" src="../../../Pages/image/menupic06.jpg" /></td>
    <td width="204" height="22" align="left"><a onclick='window.open("../../Hrmis/OverWorkPages/OverWorkList.aspx")' href="#">你共有<span class="fontred"><asp:Label ID="lblOverTimeNeedConfirm" runat="server"></asp:Label></span>个待审核的加班申请</a></td>
  </tr>
  <tr>
    <td align="left"><img src="../../../Pages/image/menuicon.jpg" width="17" height="16" border="0" align="absmiddle" /><a href="#" onclick='window.open("../../Hrmis/OverWorkPages/AddOverWork.aspx")'>我要加班</a></td>
  </tr>
</table>