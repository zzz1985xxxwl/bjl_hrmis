<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StatisticsConditionView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.PayModuleViews.EmployeeSalaryStatistics.AverageStatistics.StatisticsConditionView" %>
<link href="../CSS/style.css" rel="stylesheet" type="text/css" />
<table width="100%" border="0" cellpadding="0" cellspacing="0">
<tr>
    <td align="center">
        <table width="100%" height="28px" class="linetablepart" cellpadding="0" cellspacing="0" style="background-color:White">
          <tr>
              <td class="headerstyleblue" colspan="2" style="text-align:center">
                  ����ͳ������</td>
         </tr>
         </table>
        <table width="100%" class="linetable" cellpadding="0"  cellspacing="10" style="background-color:White;border-collapse:separate;">
          <tr id="trCompany" runat="server">
            <td align="right">
                 ������˾
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlCompany" runat="server" Width="146px" AutoPostBack="true" OnSelectedIndexChanged="ddlCompany_SelectedIndexChanged"></asp:DropDownList>
            </td>
          </tr>
          <tr>
            <td align="right">
                 ��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;��
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlDepartment" runat="server" Width="146px"></asp:DropDownList>
            </td>
          </tr>
          <tr>
            <td align="right">
            </td>
            <td align="left">
                <asp:CheckBox ID="cbIsAccumulated" runat="server" Text="�ۻ������ϼ�����" />
            </td>
          </tr>
          <tr>
            <td align="right">
                ʱ&nbsp;&nbsp;��&nbsp;&nbsp;��
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
            <td align="right">
                ���ײ���
            </td>
            <td align="left">
<asp:DropDownList ID="ddlAccountSetPara" runat="server" Width="146px"></asp:DropDownList>
            </td>
          </tr>
          <tr runat="server" id="trAccountSetParaMsg">
            <td align="right">
            </td>
            <td align="left">
                  <asp:Label ID="lblAccountSetParaMsg" runat="server" CssClass = "psword_f"></asp:Label>                  
            </td>
          </tr>
          <tr>
              <td  style="text-align:center" colspan="2">
                <asp:Button ID="btnStatistics" runat="server" Text="ͳ����" CssClass="inputbt" OnClick="btnStatistics_Click"/>&nbsp;&nbsp;
                <input id="btnExport" runat="server" type="button" value="������" class="inputbt" onclick="location.href='EmployeeSalaryStatisticsExport.aspx?type=AverageExport'"  />
              </td>
          </tr>
        </table>
    </td>
    </tr>
</table>
