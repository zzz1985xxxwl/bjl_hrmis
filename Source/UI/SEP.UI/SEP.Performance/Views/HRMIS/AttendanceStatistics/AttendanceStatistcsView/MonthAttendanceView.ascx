<%@ Import Namespace="ShiXin.Security" %>
<%@ Import Namespace="SEP.HRMIS.Model.EmployeeAttendance.AttendanceStatistics" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MonthAttendanceView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.AttendanceStatistics.AttendanceStatistcsView.MonthAttendanceView" %>
<%@ Register Src="../../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<div class="leftitbor">
    <asp:Label ID="lblMessage" runat="server"></asp:Label><%--<a href="#" class="fontreda"></a>--%>
</div>
<div class="leftitbor2">
    ����ͳ��</div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td align="left" style="width: 2%;">
            </td>
            <td align="left" style="width: 6%;">
                Ա������
            </td>
            <td align="left" style="width: 17%">
                <asp:TextBox ID="txtEmployeeName" runat="server" CssClass="input1" Width="80%"></asp:TextBox>
            </td>
            <td align="left" style="width: 6%;">
                ����
            </td>
            <td align="left" style="width: 17%">
                <asp:DropDownList ID="ddlDepartment" runat="server" Width="80%" AutoPostBack="True"
                    OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td align="left" style="width: 6%;">
                ְϵ
            </td>
            <td align="left" style="width: 17%">
                <asp:DropDownList ID="ddGrades" runat="server" Width="80%">
                </asp:DropDownList>
            </td>
            <td align="left" style="width: 6%;">
                ��ѯʱ��
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
                <asp:Button ID="btnStatistics" runat="server" Text="�顡ѯ" CssClass="inputbt" OnClick="btnStatistics_Click" />
            </td>
            <td align="left" id="tdExport" runat="server">
                <input id="btnExportClient" type="button" value="������" onclick="document.getElementById('cphCenter_btnExportServer').click();"
                    class="inputbt" />
            </td>
        </tr>
    </table>
</div>
<div class="nolinetablediv" id="trSearch" runat="server">
    <div style="text-align: left; line-height: 20px">
        ˵����������=(Ӧ��������-�¼�����-��������-��������-��ǰ������-��������-���������)/Ӧ�����죬��������������㲻�����ڼ�����Ϣ�ա�</div>
    <table cellpadding="0" cellspacing="0" class="linetablepart green1" border="0" width="100%"
        height="28">
        <tr class="tittdbagbg">
            <td width="33%">
            </td>
            <td class="kqtop" width="34%">
                <asp:Label ID="lblScopeDateFrom" runat="server"></asp:Label>��<asp:Label ID="lblScopeDateTo"
                    runat="server"></asp:Label>���ڼ�¼
            </td>
            <td width="28%" align="right">
                <span class="kqtop">��ʾ��ʽ&nbsp;&nbsp;</span>
            </td>
            <td width="5%" align="left" nowrap>
                <asp:ImageButton ID="ibHour" runat="server" ToolTip="��СʱΪ��λ" ImageUrl="../../../../Pages/image/hour.png"
                    OnClick="ibHour_Click" />
                <asp:ImageButton ID="ibDay" runat="server" ToolTip="����Ϊ��λ" ImageUrl="../../../../Pages/image/day.png"
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
            <asp:TemplateField HeaderText="Ա������" SortExpression="Name">
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
            <asp:TemplateField HeaderText="Ӧ������">
                <ItemTemplate>
                    <asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("Account.Id")+ ";"+Eval("Account.Name")%>'
                        CommandName="HiddenPostButtonCommand" runat="server" Text="" Style="display: none;" />
                    <%# Convert.ToSingle(Eval("EmployeeAttendance.MonthAttendance.ExpectedOnDutyDays"))%>
                </ItemTemplate>
                <ItemStyle Width="7%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="������">
                <ItemTemplate>
                    <%# Convert.ToSingle(Eval("EmployeeAttendance.MonthAttendance.ActualOnDutyDays"))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="���(��)" SortExpression="DaysofLunarPeriodLeave">
                <ItemTemplate>
                    <%# Convert.ToSingle(Convert.ToDecimal(Eval("EmployeeAttendance.MonthAttendance.DaysofLunarPeriodLeave")))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="�¼�(��)" SortExpression="DaysofPersonalReasonLeave">
                <ItemTemplate>
                    <%#  Convert.ToSingle(Convert.ToDecimal(Eval("EmployeeAttendance.MonthAttendance.DaysofPersonalReasonLeave")))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="����(��)" SortExpression="DaysofSickLeave">
                <ItemTemplate>
                    <%# Convert.ToSingle(Convert.ToDecimal(Eval("EmployeeAttendance.MonthAttendance.DaysofSickLeave")))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="����(��)" SortExpression="DaysofAdjustRestLeave">
                <ItemTemplate>
                    <%# Convert.ToSingle(Convert.ToDecimal(Eval("EmployeeAttendance.MonthAttendance.DaysofAdjustRestLeave")))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="����(��)" SortExpression="DaysofOtherLeave">
                <ItemTemplate>
                    <%# Convert.ToSingle(Convert.ToDecimal(Eval("EmployeeAttendance.MonthAttendance.DaysofOtherLeave")))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="����(��)" SortExpression="DaysofNoReasonLeave">
                <ItemTemplate>
                    <%# Convert.ToSingle(Convert.ToDecimal(Eval("EmployeeAttendance.MonthAttendance.DaysofNoReasonLeave")))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="�ٵ�" SortExpression="ArriveLate">
                <ItemTemplate>
                    <%# ((EmployeeAttendance)Eval("EmployeeAttendance")).MonthAttendance.LateToString() %>
                </ItemTemplate>
                <ItemStyle Width="7%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="����" SortExpression="LeaveEarly">
                <ItemTemplate>
                    <%# ((EmployeeAttendance)Eval("EmployeeAttendance")).MonthAttendance.EarlyLeaveToString() %>
                </ItemTemplate>
                <ItemStyle Width="7%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="�Ӱ�(��)" SortExpression="DaysofOvertime">
                <ItemTemplate>
                    <%# Convert.ToSingle(Convert.ToDecimal(Eval("EmployeeAttendance.MonthAttendance.DaysofOvertime")))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="��ͨ�Ӱ�(��)" SortExpression="DaysofCommonOvertime">
                <ItemTemplate>
                    <%# Convert.ToSingle(Convert.ToDecimal(Eval("EmployeeAttendance.MonthAttendance.DaysofCommonOvertime")))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="˫���ռӰ�(��)" SortExpression="DaysofWeekendOvertime">
                <ItemTemplate>
                    <%# Convert.ToSingle(Convert.ToDecimal(Eval("EmployeeAttendance.MonthAttendance.DaysofWeekendOvertime")))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="�����Ӱ�(��)" SortExpression="DaysofHolidayOvertime">
                <ItemTemplate>
                    <%# Convert.ToSingle(Convert.ToDecimal(Eval("EmployeeAttendance.MonthAttendance.DaysofHolidayOvertime")))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ʣ�����(��)" SortExpression="DaysofAdjustRestRemained">
                <ItemTemplate>
                    <%# Convert.ToSingle(Convert.ToDecimal(Eval("EmployeeAttendance.MonthAttendance.DaysofAdjustRestRemained")))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ʣ�����(��)" SortExpression="SurplusDayNum">
                <ItemTemplate>
                    <%# Convert.ToSingle(Convert.ToDecimal(Eval("EmployeeAttendance.Vacation.SurplusDayNum")))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="���(ʱ)" SortExpression="HoursofLunarPeriodLeave">
                <ItemTemplate>
                    <%# Convert.ToSingle(decimal.Round(Convert.ToDecimal(Eval("EmployeeAttendance.MonthAttendance.HoursofLunarPeriodLeave")), 2))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="�¼�(ʱ)" SortExpression="HoursofPersonalReasonLeave">
                <ItemTemplate>
                    <%#  Convert.ToSingle(decimal.Round(Convert.ToDecimal(Eval("EmployeeAttendance.MonthAttendance.HoursofPersonalReasonLeave")), 2))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="����(ʱ)" SortExpression="HoursofSickLeave">
                <ItemTemplate>
                    <%# Convert.ToSingle(decimal.Round(Convert.ToDecimal(Eval("EmployeeAttendance.MonthAttendance.HoursofSickLeave")), 2))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="����(ʱ)" SortExpression="HoursofAdjustRestLeave">
                <ItemTemplate>
                    <%# Convert.ToSingle(decimal.Round(Convert.ToDecimal(Eval("EmployeeAttendance.MonthAttendance.HoursofAdjustRestLeave")), 2))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="����(ʱ)" SortExpression="HoursofOtherLeave">
                <ItemTemplate>
                    <%# Convert.ToSingle(decimal.Round(Convert.ToDecimal(Eval("EmployeeAttendance.MonthAttendance.HoursofOtherLeave")), 2))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="����(ʱ)" SortExpression="HoursofNoReasonLeave">
                <ItemTemplate>
                    <%# Convert.ToSingle(decimal.Round(Convert.ToDecimal(Eval("EmployeeAttendance.MonthAttendance.HoursofNoReasonLeave")), 2))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="�ٵ�" SortExpression="ArriveLate">
                <ItemTemplate>
                    <%# ((EmployeeAttendance)Eval("EmployeeAttendance")).MonthAttendance.LateToString() %>
                </ItemTemplate>
                <ItemStyle Width="7%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="����" SortExpression="LeaveEarly">
                <ItemTemplate>
                    <%# ((EmployeeAttendance)Eval("EmployeeAttendance")).MonthAttendance.EarlyLeaveToString() %>
                </ItemTemplate>
                <ItemStyle Width="7%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="�Ӱ�(ʱ)" SortExpression="HoursofOvertime">
                <ItemTemplate>
                    <%# Convert.ToSingle(decimal.Round(Convert.ToDecimal(Eval("EmployeeAttendance.MonthAttendance.HoursofOvertime")), 2))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="��ͨ�Ӱ�(ʱ)" SortExpression="HoursofCommonOvertime">
                <ItemTemplate>
                    <%# Convert.ToSingle(decimal.Round(Convert.ToDecimal(Eval("EmployeeAttendance.MonthAttendance.HoursofCommonOvertime")), 2))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="˫���ռӰ�(ʱ)" SortExpression="HoursofWeekendOvertime">
                <ItemTemplate>
                    <%# Convert.ToSingle(decimal.Round(Convert.ToDecimal(Eval("EmployeeAttendance.MonthAttendance.HoursofWeekendOvertime")), 2))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="�����Ӱ�(ʱ)" SortExpression="HoursofHolidayOvertime">
                <ItemTemplate>
                    <%# Convert.ToSingle(decimal.Round(Convert.ToDecimal(Eval("EmployeeAttendance.MonthAttendance.HoursofHolidayOvertime")), 2))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ʣ�����(ʱ)" SortExpression="HoursofAdjustRestRemained">
                <ItemTemplate>
                    <%# Convert.ToSingle(decimal.Round(Convert.ToDecimal(Eval("EmployeeAttendance.MonthAttendance.HoursofAdjustRestRemained")), 2))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ʣ�����(ʱ)" SortExpression="SurplusDayNum">
                <ItemTemplate>
                    <%# Convert.ToSingle(decimal.Round(Convert.ToDecimal(Eval("EmployeeAttendance.Vacation.SurplusDayNum"))*8,2))%>
                </ItemTemplate>
                <ItemStyle Width="5%" CssClass="kqfont02" />
                <HeaderStyle CssClass="kqfont02" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="������" SortExpression="RateofOnDuty">
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
		    ��һҳ</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton"
                    CommandArgument="Next" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    ��һҳ</asp:LinkButton>
            </div>--%>
        </PagerTemplate>
    </asp:GridView>
</div>
