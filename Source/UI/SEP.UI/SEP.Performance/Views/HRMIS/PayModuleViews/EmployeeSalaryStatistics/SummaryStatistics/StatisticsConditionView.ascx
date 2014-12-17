<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StatisticsConditionView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.PayModuleViews.EmployeeSalaryStatistics.SummaryStatistics.StatisticsConditionView" %>
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
            </td>
            <td align="left">
                <asp:CheckBox ID="cbIsAccumulated" runat="server" Text="累积计算上级部门" />
            </td>
          </tr>
          <tr>
            <td align="right">
                时&nbsp;&nbsp;间&nbsp;&nbsp;段
            </td>
            <td align="left">
                  <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtStatisticsTimeFrom">
                  </ajaxToolKit:CalendarExtender>
                  <asp:TextBox ID="txtStatisticsTimeFrom" runat="server" CssClass="input1" size="28" Width="65px"></asp:TextBox> --
                  <ajaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd" TargetControlID="txtStatisticsTimeTo">
                  </ajaxToolKit:CalendarExtender>
                  <asp:TextBox ID="txtStatisticsTimeTo" runat="server" CssClass="input1" size="28" Width="65px"></asp:TextBox>
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
            <td align="right" valign="top">
                帐套参数
            </td>
            <td align="left" valign="top">
<div style="height: 190px;" class="scrollbarlist">
                <asp:CheckBoxList ID="cblAccountSetPara" runat="server" Width="126px" ></asp:CheckBoxList>
</div>     
<input type="checkbox" runat="server" id="cbAll"/>   全选/清除        
            </td>
          </tr>
          <tr runat="server" id="trAccountSetParaMsg">
            <td align="right">
            </td>
            <td align="left" valign="top">
                  <asp:Label ID="lblAccountSetParaMsg" runat="server" CssClass = "psword_f"></asp:Label>                  
            </td>
          </tr>
          <tr>
              <td style="text-align:center" colspan="2">
                <asp:Button ID="btnStatistics" runat="server" Text="统　计" CssClass="inputbt" OnClick="btnStatistics_Click"/>&nbsp;&nbsp;
                <input id="btnExport" runat="server" type="button" value="导　出" class="inputbt" onclick="location.href='EmployeeSalaryStatisticsExport.aspx?type=SummaryExport'"  />
              </td>
          </tr>
        </table>
    </td>
    </tr>
</table>