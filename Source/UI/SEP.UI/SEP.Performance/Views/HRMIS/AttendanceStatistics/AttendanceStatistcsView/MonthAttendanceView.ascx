<%@ Import Namespace="ShiXin.Security" %>
<%@ Import Namespace="SEP.HRMIS.Model.EmployeeAttendance.AttendanceStatistics" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MonthAttendanceView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.AttendanceStatistics.AttendanceStatistcsView.MonthAttendanceView" %>
<%@ Register Src="../../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<div class="leftitbor">
    <asp:Label ID="lblMessage" runat="server"></asp:Label><%--<a href="#" class="fontreda"></a>--%>
</div>
<div class="leftitbor2">
    考勤统计</div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td align="left" style="width: 2%;">
            </td>
            <td align="left" style="width: 6%;">
                员工姓名
            </td>
            <td align="left" style="width: 17%">
                <asp:TextBox ID="txtEmployeeName" runat="server" CssClass="input1" Width="80%"></asp:TextBox>
            </td>
            <td align="left" style="width: 6%;">
                部门
            </td>
            <td align="left" style="width: 17%">
                <asp:DropDownList ID="ddlDepartment" runat="server" Width="80%" AutoPostBack="True"
                    OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td align="left" style="width: 6%;">
                职系
            </td>
            <td align="left" style="width: 17%">
                <asp:DropDownList ID="ddGrades" runat="server" Width="80%">
                </asp:DropDownList>
            </td>
            <td align="left" style="width: 6%;">
                查询时间
            </td>
            <td align="left" style="width: 30%">
                <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="dtpScopeFrom"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
                <ajaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="dtpScopeTo"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
                <asp:TextBox ID="dtpScopeFrom" runat="server" CssClass="input1" Width="30%"></asp:TextBox>
                ---
                <asp:TextBox ID="dtpScopeTo" runat="server" CssClass="input1" Width="30%"></asp:TextBox>
                <asp:Label ID="lblScopeMsg" runat="server" CssClass="psword_f"></asp:Label>
            </td>
        </tr>
    </table>
</div>
<div class="nolinetablediv">
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td align="left" width="100px">
                <asp:Button ID="btnStatistics" runat="server" Text="查　询" CssClass="inputbt" OnClick="btnStatistics_Click" />
            </td>
            <td align="left" id="tdExport" runat="server">
                <input id="btnExportClient" type="button" value="导　出" onclick="document.getElementById('cphCenter_btnExportServer').click();"
                    class="inputbt" />
            </td>
        </tr>
    </table>
</div>
<div class="nolinetablediv" id="trSearch" runat="server">
    <div style="text-align: left; line-height: 20px">
        说明：出勤率=(应出勤天数-事假天数-病假天数-旷工天数-产前假天数-产假天数-哺乳假天数)/应出勤天，各类请假天数计算不包含节假日休息日。</div>
    <table cellpadding="0" cellspacing="0" class="linetablepart green1" border="0" width="100%"
        height="28">
        <tr class="tittdbagbg">
            <td width="33%">
            </td>
            <td class="kqtop" width="34%">
                <asp:Label ID="lblScopeDateFrom" runat="server"></asp:Label>至<asp:Label ID="lblScopeDateTo"
                    runat="server"></asp:Label>考勤记录
            </td>
            <td width="28%" align="right">
                <span class="kqtop">显示方式&nbsp;&nbsp;</span>
            </td>
            <td width="5%" align="left" nowrap>
                <asp:ImageButton ID="ibHour" runat="server" ToolTip="按小时为单位" ImageUrl="../../../../Pages/image/hour.png"
                    OnClick="ibHour_Click" />
                <asp:ImageButton ID="ibDay" runat="server" ToolTip="按天为单位" ImageUrl="../../../../Pages/image/day.png"
                    OnClick="ibDay_Click" />
            </td>
        </tr>
    </table>
    <asp:GridView GridLines="None" Width="100%" ID="gvMonthAttendanceList" AllowSorting="true"
        runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="gvMonthAttendanceList_PageIndexChanging"
        OnRowCommand="gvMonthAttendanceList_RowCommand" OnRowDataBound="gvMonthAttendanceList_RowDataBound"
        PageSize="15" OnSorting="gvMonthAttendanceList_Sorting">
        <HeaderStyle Height="28px" HorizontalAlign="Center" CssClass="green1" />
        <RowStyle Height="28px" CssClass="GridViewRowLink" HorizontalAlign="Center" />
        <AlternatingRowStyle CssClass="table_g" />
        <Columns>
            <asp:TemplateField HeaderText="员工姓名" SortExpression="Name">
                <ItemTemplate>
                    <table width="100%">
                        <tr>
                            <td style="width: 70%;">
                                <a style="margin-left: 2px;" onclick="window.open('../../HRMIS/EmployeePages/EmployeeViewDetail.aspx?employeeID=<%# SecurityUtil.DECEncrypt(Convert.ToString(Eval("Account.Id")))%> ','PopupWindow'); Confirmed=false;">
                                    <%# Eval("Account.Name") %>
                                </a>
                            </td>
                            <td align="left">
                                <div style="background: url(../../image/icon01.gif) no-repeat  center center; display: block;
                                    width: 16px; height: 16px;">
                                </div>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <ItemStyle Width="8%" CssClass="kqfont02" HorizontalAlign="Center" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="应出勤天">
                <ItemTemplate>
                    <asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("Account.Id")+ ";"+Eval("Account.Name")%>'
                        CommandName="HiddenPostButtonCommand" runat="server" Text="" Style="display: none;" />
                    <%# Convert.ToSingle(Eval("EmployeeAttendance.MonthAttendance.ExpectedOnDutyDays"))%>
                </ItemTemplate>
                <ItemStyle Width="7%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="出勤天">
                <ItemTemplate>
                    <%# Convert.ToSingle(Eval("EmployeeAttendance.MonthAttendance.ActualOnDutyDays"))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="年假(天)" SortExpression="DaysofLunarPeriodLeave">
                <ItemTemplate>
                    <%# Convert.ToSingle(Convert.ToDecimal(Eval("EmployeeAttendance.MonthAttendance.DaysofLunarPeriodLeave")))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="事假(天)" SortExpression="DaysofPersonalReasonLeave">
                <ItemTemplate>
                    <%#  Convert.ToSingle(Convert.ToDecimal(Eval("EmployeeAttendance.MonthAttendance.DaysofPersonalReasonLeave")))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="病假(天)" SortExpression="DaysofSickLeave">
                <ItemTemplate>
                    <%# Convert.ToSingle(Convert.ToDecimal(Eval("EmployeeAttendance.MonthAttendance.DaysofSickLeave")))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="调休(天)" SortExpression="DaysofAdjustRestLeave">
                <ItemTemplate>
                    <%# Convert.ToSingle(Convert.ToDecimal(Eval("EmployeeAttendance.MonthAttendance.DaysofAdjustRestLeave")))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="其他(天)" SortExpression="DaysofOtherLeave">
                <ItemTemplate>
                    <%# Convert.ToSingle(Convert.ToDecimal(Eval("EmployeeAttendance.MonthAttendance.DaysofOtherLeave")))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="旷工(天)" SortExpression="DaysofNoReasonLeave">
                <ItemTemplate>
                    <%# Convert.ToSingle(Convert.ToDecimal(Eval("EmployeeAttendance.MonthAttendance.DaysofNoReasonLeave")))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="迟到" SortExpression="ArriveLate">
                <ItemTemplate>
                    <%# ((EmployeeAttendance)Eval("EmployeeAttendance")).MonthAttendance.LateToString() %>
                </ItemTemplate>
                <ItemStyle Width="7%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="早退" SortExpression="LeaveEarly">
                <ItemTemplate>
                    <%# ((EmployeeAttendance)Eval("EmployeeAttendance")).MonthAttendance.EarlyLeaveToString() %>
                </ItemTemplate>
                <ItemStyle Width="7%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="加班(天)" SortExpression="DaysofOvertime">
                <ItemTemplate>
                    <%# Convert.ToSingle(Convert.ToDecimal(Eval("EmployeeAttendance.MonthAttendance.DaysofOvertime")))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="普通加班(天)" SortExpression="DaysofCommonOvertime">
                <ItemTemplate>
                    <%# Convert.ToSingle(Convert.ToDecimal(Eval("EmployeeAttendance.MonthAttendance.DaysofCommonOvertime")))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="双休日加班(天)" SortExpression="DaysofWeekendOvertime">
                <ItemTemplate>
                    <%# Convert.ToSingle(Convert.ToDecimal(Eval("EmployeeAttendance.MonthAttendance.DaysofWeekendOvertime")))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="法定加班(天)" SortExpression="DaysofHolidayOvertime">
                <ItemTemplate>
                    <%# Convert.ToSingle(Convert.ToDecimal(Eval("EmployeeAttendance.MonthAttendance.DaysofHolidayOvertime")))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="剩余调休(天)" SortExpression="DaysofAdjustRestRemained">
                <ItemTemplate>
                    <%# Convert.ToSingle(Convert.ToDecimal(Eval("EmployeeAttendance.MonthAttendance.DaysofAdjustRestRemained")))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="剩余年假(天)" SortExpression="SurplusDayNum">
                <ItemTemplate>
                    <%# Convert.ToSingle(Convert.ToDecimal(Eval("EmployeeAttendance.Vacation.SurplusDayNum")))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="年假(时)" SortExpression="HoursofLunarPeriodLeave">
                <ItemTemplate>
                    <%# Convert.ToSingle(decimal.Round(Convert.ToDecimal(Eval("EmployeeAttendance.MonthAttendance.HoursofLunarPeriodLeave")), 2))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="事假(时)" SortExpression="HoursofPersonalReasonLeave">
                <ItemTemplate>
                    <%#  Convert.ToSingle(decimal.Round(Convert.ToDecimal(Eval("EmployeeAttendance.MonthAttendance.HoursofPersonalReasonLeave")), 2))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="病假(时)" SortExpression="HoursofSickLeave">
                <ItemTemplate>
                    <%# Convert.ToSingle(decimal.Round(Convert.ToDecimal(Eval("EmployeeAttendance.MonthAttendance.HoursofSickLeave")), 2))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="调休(时)" SortExpression="HoursofAdjustRestLeave">
                <ItemTemplate>
                    <%# Convert.ToSingle(decimal.Round(Convert.ToDecimal(Eval("EmployeeAttendance.MonthAttendance.HoursofAdjustRestLeave")), 2))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="其他(时)" SortExpression="HoursofOtherLeave">
                <ItemTemplate>
                    <%# Convert.ToSingle(decimal.Round(Convert.ToDecimal(Eval("EmployeeAttendance.MonthAttendance.HoursofOtherLeave")), 2))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="旷工(时)" SortExpression="HoursofNoReasonLeave">
                <ItemTemplate>
                    <%# Convert.ToSingle(decimal.Round(Convert.ToDecimal(Eval("EmployeeAttendance.MonthAttendance.HoursofNoReasonLeave")), 2))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="迟到" SortExpression="ArriveLate">
                <ItemTemplate>
                    <%# ((EmployeeAttendance)Eval("EmployeeAttendance")).MonthAttendance.LateToString() %>
                </ItemTemplate>
                <ItemStyle Width="7%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="早退" SortExpression="LeaveEarly">
                <ItemTemplate>
                    <%# ((EmployeeAttendance)Eval("EmployeeAttendance")).MonthAttendance.EarlyLeaveToString() %>
                </ItemTemplate>
                <ItemStyle Width="7%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="加班(时)" SortExpression="HoursofOvertime">
                <ItemTemplate>
                    <%# Convert.ToSingle(decimal.Round(Convert.ToDecimal(Eval("EmployeeAttendance.MonthAttendance.HoursofOvertime")), 2))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="普通加班(时)" SortExpression="HoursofCommonOvertime">
                <ItemTemplate>
                    <%# Convert.ToSingle(decimal.Round(Convert.ToDecimal(Eval("EmployeeAttendance.MonthAttendance.HoursofCommonOvertime")), 2))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="双休日加班(时)" SortExpression="HoursofWeekendOvertime">
                <ItemTemplate>
                    <%# Convert.ToSingle(decimal.Round(Convert.ToDecimal(Eval("EmployeeAttendance.MonthAttendance.HoursofWeekendOvertime")), 2))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="法定加班(时)" SortExpression="HoursofHolidayOvertime">
                <ItemTemplate>
                    <%# Convert.ToSingle(decimal.Round(Convert.ToDecimal(Eval("EmployeeAttendance.MonthAttendance.HoursofHolidayOvertime")), 2))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="剩余调休(时)" SortExpression="HoursofAdjustRestRemained">
                <ItemTemplate>
                    <%# Convert.ToSingle(decimal.Round(Convert.ToDecimal(Eval("EmployeeAttendance.MonthAttendance.HoursofAdjustRestRemained")), 2))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="剩余年假(时)" SortExpression="SurplusDayNum">
                <ItemTemplate>
                    <%# Convert.ToSingle(decimal.Round(Convert.ToDecimal(Eval("EmployeeAttendance.Vacation.SurplusDayNum"))*8,2))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="出勤率" SortExpression="RateofOnDuty">
                <ItemTemplate>
                    <%# Convert.ToSingle(decimal.Round(Convert.ToDecimal(Eval("EmployeeAttendance.MonthAttendance.RateofOnDuty"))*100,2))%>%
                </ItemTemplate>
                <ItemStyle Width="6%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
        </Columns>
        <PagerTemplate>
            <uc1:PageTemplate ID="PageTemplate1" runat="server" />
            <%--            <div class="pages">
                <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton"
                    CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    上一页</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton"
                    CommandArgument="Next" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    下一页</asp:LinkButton>
            </div>--%>
        </PagerTemplate>
    </asp:GridView>
</div>
