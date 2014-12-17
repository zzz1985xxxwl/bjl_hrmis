<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StatisticsConditionView.ascx.cs" Inherits="SEP.Performance.Views.EmployeeStatistics.StatisticsConditionView" %>
<link href="../../CSS/style.css" rel="stylesheet" type="text/css" />
<table width="100%" border="0" cellpadding="0" cellspacing="0">
<tr>
    <td align="center">
        <table width="100%" height="28px" class="linetablepart" cellpadding="0" cellspacing="0" style="background-color:White">
          <tr>
              <td class="headerstyleblue" colspan="2" style="text-align:center">
                  设置统计条件</td>
         </tr>
         </table>
        <table width="100%" class="linetable" cellpadding="0" cellspacing="10" style="background-color:White;border-collapse:separate;">
          <tr>
            <td align="right">
                 部&nbsp;&nbsp;&nbsp;&nbsp;门
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlDepartment" runat="server" Width="154px"></asp:DropDownList>
            </td>
          </tr>
          <tr runat="server" id="trStatisticsTime">
            <td align="right">
                时间点
            </td>
            <td align="left">
                  <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtStatisticsTime">
                  </ajaxToolKit:CalendarExtender>
                  <asp:TextBox ID="txtStatisticsTime" runat="server" CssClass="input1" size="28" Width="142px"></asp:TextBox>
            </td>
          </tr>
          <tr runat="server" id="trStatisticsTimeMsg">
            <td align="right">
            </td>
            <td align="left" valign="top">
                  <asp:Label ID="lblStatisticsTimeMsg" runat="server" CssClass = "psword_f"></asp:Label>                  
            </td>
          </tr>
          <tr>
              <td colspan="2" style="text-align:center">
                <asp:Button ID="btnStatistics" runat="server" Text="统　计" CssClass="inputbt" OnClick="btnStatistics_Click"/>&nbsp;&nbsp;
                <asp:Button ID="btnExport" runat="server" Text="导　出" CssClass="inputbt"  OnClientClick="location.href='EmployeeStatisticExportPage.aspx';return false;"/>
              </td>
          </tr>
        </table>
    </td>
    </tr>
</table>
