<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AttendanceSettingView.ascx.cs" Inherits="SEP.Performance.Pages.Config.Views.AttendanceSettingView" %>
        <div class="leftitbor2">考勤开始日</div>
        <div class="edittable">
        <table style="width: 100%">
            <tr>
                <td style="width:11%;text-align:left">
                    每月几号开始计算考勤</td>
                <td style="width: 89%">
                    <asp:TextBox ID="txtAttendanceStartDay" runat="server" Width="80px"></asp:TextBox>  填写范围1-28
                    <asp:Label ID="lbAttendanceStartDayMsg" runat="server" CssClass="psword_f"></asp:Label></td>
            </tr>
        </table>
        </div>
