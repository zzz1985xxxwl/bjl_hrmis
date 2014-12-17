<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InAndOutStatisticsView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.AttendanceStatistics.AttendanceInAndOutStatistics.InAndOutStatisticsView" %>
<%@ Register Src="../../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<link href="../../../../Pages/CSS/style.css" rel="stylesheet" type="text/css" />
<div class="leftitbor">
    <span class="font14b">���鵽 </span>
    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="fontred"></asp:Label>
    <span class="font14b">����¼</span>
    <asp:Label ID="lblErrorMessage" runat="server" CssClass="fontred"></asp:Label>
</div>
<div class="leftitbor2">
    Ա������Ϣ
</div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td width="2%" align="right">
            </td>
            <td width="10%" align="left">
                Ա������
            </td>
            <td width="88%" align="left">
                <asp:TextBox ID="txtEmployeeName" runat="server" CssClass="input1"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;����
                <asp:DropDownList ID="listDepartment" runat="server" Width="160px" Height="24px">
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ְϵ
                <asp:DropDownList ID="ddGrades" runat="server" Width="160px" Height="24px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td width="2%" align="right">
            </td>
            <td width="10%" align="left" style="height: 36px">
                ��ѯʱ��
            </td>
            <td align="left" width="88%">
                <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="dtpScopeFrom"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
                <asp:TextBox ID="dtpScopeFrom" runat="server" CssClass="input1"></asp:TextBox>
                <asp:DropDownList ID="listHourFrom" runat="server" Width="50px">
                </asp:DropDownList>
                ʱ
                <asp:DropDownList ID="listMinutesFrom" runat="server" Width="50px">
                </asp:DropDownList>
                �� -- &nbsp;
                <%--                  <asp:textbox id="dtpScopeTo" runat="server" CssClass="input1"></asp:textbox>--%>
                <asp:DropDownList ID="listHourTo" runat="server" Width="50px">
                </asp:DropDownList>
                ʱ
                <asp:DropDownList ID="listMinutesTo" runat="server" Width="50px">
                </asp:DropDownList>
                ��
            </td>
        </tr>
        <tr>
            <td width="2%" align="right" style="height: 36px">
            </td>
            <td width="10%" align="left" style="height: 36px">
                ����ʱ��
            </td>
            <td width="12%" align="left" style="height: 36px">
                <asp:DropDownList ID="ddInOutTimeCondition" runat="server" Width="160px" Height="24px">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
</div>
<div class="tablebt">
    <asp:Button ID="btnSearch" runat="server" CssClass="inputbt" OnClick="btnSearch_Click"
        Text="�顡ѯ" />
    <input id="btnExport" type="button" value="������" class="inputbt" onclick="location.href='InAndOutStatisticsRecordExport.aspx?type=default';" />
    <asp:Button ID="btnSetReadTime" runat="server" CssClass="inputbtlong" OnClick="btnSetReadTime_Click"
        Text="���ö�ȡʱ��" />
    <asp:Button ID="btnReadAccessData" runat="server" CssClass="inputbtlong" OnClick="btnReadAccessData_Click"
        Text="��Access����" />
    <asp:Button ID="btnReadExcelData" runat="server" CssClass="inputbtlong" OnClick="btnReadExcelData_Click"
        Text="��Excel����" />
</div>
<div id="tbInAndOutStatistics" runat="server" class="linetable">
    <asp:GridView ID="gvInAndOutStatistics" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        GridLines="None" OnPageIndexChanging="gvInAndOutStatistics_PageIndexChanging"
        OnRowCommand="gvInAndOutStatistics_RowCommand" OnRowDataBound="gvInAndOutStatistics_RowDataBound"
        Width="100%">
        <HeaderStyle CssClass="headerstyleblue" Height="28px" HorizontalAlign="Center" />
        <RowStyle Height="28px" CssClass="GridViewRowLink" />
        <AlternatingRowStyle CssClass="table_g" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnHiddenPostButton" runat="server" CommandArgument='<%# Eval("Account.Id") %>'
                        CommandName="HiddenPostButtonCommand" Style="display: none;" Text=""></asp:LinkButton></ItemTemplate>
                <ItemStyle Width="2%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ա������">
                <ItemTemplate>
                    <%#Eval("Account.Name")%>
                </ItemTemplate>
                <ItemStyle Width="15%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="����ʱ��">
                <ItemTemplate>
                    <%#Eval("EmployeeAttendance.AttendanceInAndOutStatistics.InTime", "{0:yyyy-MM-dd}").Equals("2999-12-31") ? "" : Eval("EmployeeAttendance.AttendanceInAndOutStatistics.InTime")%>
                </ItemTemplate>
                <ItemStyle Width="15%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="�뿪ʱ��">
                <ItemTemplate>
                    <%#Eval("EmployeeAttendance.AttendanceInAndOutStatistics.OutTime", "{0:yyyy-MM-dd}").Equals("1900-01-01") ? "" : Eval("EmployeeAttendance.AttendanceInAndOutStatistics.OutTime")%>
                </ItemTemplate>
                <ItemStyle Width="15%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="������Ϣ">
                <ItemTemplate>
                    <%#Eval("EmployeeAttendance.AttendanceInAndOutStatistics.LeaveRequestAndOut")%>
                </ItemTemplate>
                <ItemStyle Width="30%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnSendMessage" runat="server" CommandArgument='<%# Eval("Account.Id")+","+ Eval("Account.Name")+","+ Eval("EmployeeAttendance.AttendanceInAndOutStatistics.InTime")+","+ Eval("EmployeeAttendance.AttendanceInAndOutStatistics.OutTime")+","+ Eval("EmployeeAttendance.AttendanceInAndOutStatistics.LeaveRequestAndOut")%>'
                        OnCommand="btnSendMessage_Click" Text="���Ͷ���"></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnSendEmail" runat="server" CommandArgument='<%# Eval("Account.Id")+","+ Eval("Account.Name")+","+ Eval("EmployeeAttendance.AttendanceInAndOutStatistics.InTime")+","+ Eval("EmployeeAttendance.AttendanceInAndOutStatistics.OutTime")+","+ Eval("EmployeeAttendance.AttendanceInAndOutStatistics.LeaveRequestAndOut")%>'
                        OnCommand="btnSendEmail_Click" Text="�����ʼ�"></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle Width="10%" />
            </asp:TemplateField>
        </Columns>
        <PagerTemplate>
            <uc1:PageTemplate ID="PageTemplate1" runat="server" />
            <%--                   <div class="pages">
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
