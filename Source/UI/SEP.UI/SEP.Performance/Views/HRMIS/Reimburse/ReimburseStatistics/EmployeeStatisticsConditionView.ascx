<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeStatisticsConditionView.ascx.cs" 
Inherits="SEP.Performance.Views.HRMIS.Reimburse.ReimburseStatistics.EmployeeStatisticsConditionView" %>
<link href="../CSS/style.css" rel="stylesheet" type="text/css" />
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
          <tr id="trCompany" runat="server">
            <td align="right">
                 所属公司
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlCompany" runat="server" Width="146px" AutoPostBack="true" OnSelectedIndexChanged="ddlCompany_SelectedIndexChanged"></asp:DropDownList>
            </td>
          </tr>
          <tr>
            <td align="right">
                 部&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;门
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlDepartment" runat="server" Width="146px"></asp:DropDownList>
            </td>
          </tr>
          <tr>
            <td align="right">
                 员工姓名
            </td>
            <td align="left">
                <asp:TextBox ID="txtEmployeeName" runat="server" CssClass="input1" Width="146px"></asp:TextBox></td>
          </tr>
          <tr>
            <td align="right">
                记账时间
            </td>
            <td align="left">
                  <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtStatisticsTimeFrom">
                  </ajaxToolKit:CalendarExtender>
                  <asp:TextBox ID="txtStatisticsTimeFrom" runat="server" CssClass="input1" Width="65px"></asp:TextBox> --
                  <ajaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd" TargetControlID="txtStatisticsTimeTo">
                  </ajaxToolKit:CalendarExtender>
                  <asp:TextBox ID="txtStatisticsTimeTo" runat="server" CssClass="input1" Width="65px"></asp:TextBox>
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
                <asp:Button ID="btnExport" runat="server" Text="导　出" CssClass="inputbt" OnClientClick="location.href='ReimburseStatisticsExportPage.aspx?type=employee';return false;"/>
              </td>
          </tr>
        </table>
    </td>
    </tr>
</table>