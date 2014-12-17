<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AssessActivityIndexView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.AssessActivity.AssessActivityIndexView" %>
<table width="99%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="30%" rowspan="3" align="center"><img id="imgCurrentAssess" runat="server" alt="" src="../../../Pages/image/menupic04.jpg"/></td>
    <td width="204" height="23" align="left">
        <a href="#" onclick='window.open("../../Hrmis/AssessPages/GetCurrentAssess.aspx")'>你共有
        <span class="fontred">
        <asp:Label ID="lblCurrentAssessCount" runat="server"></asp:Label></span>个待处理的绩效考核</a>
    </td>
  </tr>
</table>