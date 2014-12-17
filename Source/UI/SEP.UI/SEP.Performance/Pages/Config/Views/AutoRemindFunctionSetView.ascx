<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AutoRemindFunctionSetView.ascx.cs" Inherits="SEP.Performance.Pages.Config.Views.AutoRemindFunctionSetView" %>
         <div class="leftitbor2">功能设置</div>
         <div class="edittable">
        <table style="width: 100%">
         
            <tr >
                <td colspan="2">
                    自动发起绩效考核</td>
            </tr>
            <tr>
                <td style="width: 20%;">
                    <asp:CheckBox ID="cbIsAutoAssess" runat="server" />开启此功能</td>
                <td style="width: 80%">
                    </td>
            </tr>
            <tr>
                <td colspan="2">
                    自动提醒员工居住证到期，在该居住证到期前XX天，可以发Email提醒人力资源部门和员工本人居住证即将到期</td>
            </tr>
            <tr>
                <td style="width: 20%;">
                    <asp:CheckBox ID="cbIsAutoEmployeeResidenceDateRearch" runat="server" />开启此功能</td>
                <td style="width: 80%">
                    到期前<asp:TextBox ID = "txtBeforeEmployeeResidenceDateRearchDays" runat="server" Width="50px"></asp:TextBox>天提醒&nbsp;
                    <asp:Label
                        ID="lbBeforeEmployeeResidenceDateRearchDaysMsg" runat="server" CssClass="psword_f"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2">
                    月底自动提醒员工核对考勤数据</td>
            </tr>
            <tr>
                <td style="width: 20%;">
                    <asp:CheckBox ID="cbIsAutoRemindEmployeeConfirmAttendance" runat="server" />开启此功能</td>
                <td style="width: 80%">
                    </td>
            </tr>
            <tr >
                <td colspan="2">
                    年假到期前XX天提醒个人，提醒人力资源部</td>
            </tr>
            <tr >
                <td style="width: 20%;">
                    <asp:CheckBox ID="cbIsAutoRemindVacation" runat="server" />开启此功能</td>
                <td style="width: 80%">
                    到期前<asp:TextBox ID = "txtBeforeRemindVacationDays" runat="server" Width="50px"></asp:TextBox>天提醒&nbsp;
                    <asp:Label
                        ID="lbBeforeRemindVacationDaysMsg" runat="server" CssClass="psword_f"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2">
                    员工合同到期前XX天提醒人力资源部</td>
            </tr>
            <tr>
                <td style="width: 20%;">
                    <asp:CheckBox ID="cbIsAutoRemindContract" runat="server" />开启此功能</td>
                <td style="width: 80%">
                    到期前<asp:TextBox ID = "txtBeforeRemindContractDays" runat="server" Width="50px"></asp:TextBox>天提醒&nbsp;
                    <asp:Label
                        ID="lbBeforeRemindContractDaysMsg" runat="server" CssClass="psword_f"></asp:Label></td>
            </tr>
            <tr >
                <td colspan="2">
                    员工试用期到期前XX天提醒人力资源部</td>
            </tr>
            <tr >
                <td style="width: 20%;">
                    <asp:CheckBox ID="cbIsAutoRemindProbationDateRearch" runat="server" />开启此功能</td>
                <td style="width: 80%">
                    到期前<asp:TextBox ID = "txtBeforeRemindProbationDateRearchDays" runat="server" Width="50px"></asp:TextBox>天提醒&nbsp;
                    <asp:Label
                        ID="lbBeforeRemindProbationDateRearchDays" runat="server" CssClass="psword_f"></asp:Label></td>
            </tr>
        </table>
        </div>
