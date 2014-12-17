<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PersonalInAndOutListView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.AttendanceStatistics.AttendanceInAndOutStatistics.PersonalInAndOutListView" %>
<%@ Register Src="../../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<link href="../../CSS/style.css" rel="stylesheet" type="text/css" />
<div class="leftitbor">
    <span class="font14b">���鵽 </span>
    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="fontred"></asp:Label>
    <span class="font14b">����¼</span>
    <asp:Label ID="lblErrorMessage" runat="server" CssClass="fontred"></asp:Label>
</div>
<div class="leftitbor2">
    ��ѯ�򿨼�¼
</div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td width="2%" align="right">
            </td>
            <td width="6%" align="left">
                Ա������
            </td>
            <td align="left" style="width: 10%;">
                <asp:TextBox ID="txtEmployeeName" runat="server" CssClass="input1"></asp:TextBox>
                <asp:HiddenField ID="HfemployeeId" runat="server" />
                &nbsp;
            </td>
            <td align="left" width="5%">
                ����
            </td>
            <td width="10%" align="left">
                <asp:DropDownList ID="listDepartment" runat="server" Width="160px">
                </asp:DropDownList>
            </td>
            <td align="right" style="width: 5%;">
                ״̬
            </td>
            <td width="25%" align="left">
                <asp:DropDownList ID="listStatus" runat="server" Width="160px">
                </asp:DropDownList>
                <asp:HiddenField ID="HftempTimeFrom" runat="server" />
            </td>
        </tr>
        <tr>
            <td width="2%" align="right">
            </td>
            <td width="6%" align="left">
                ����ʱ�䷶Χ
            </td>
            <td align="left" colspan="6">
                <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="dtpScopeFrom"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
                <asp:TextBox ID="dtpScopeFrom" runat="server" CssClass="input1"></asp:TextBox>&nbsp;&nbsp;
                <asp:DropDownList ID="listHourFrom" runat="server" Width="60px">
                </asp:DropDownList>
                &nbsp;ʱ&nbsp;<asp:DropDownList ID="listMinutesFrom" runat="server" Width="60px">
                </asp:DropDownList>
                &nbsp; ��&nbsp; &nbsp;&nbsp; ---
                <asp:TextBox ID="dtpScopeTo" runat="server" CssClass="input1"></asp:TextBox>
                &nbsp;&nbsp;
                <asp:DropDownList ID="listHourTo" runat="server" Width="60px">
                </asp:DropDownList>
                &nbsp; ʱ
                <asp:DropDownList ID="listMinutesTo" runat="server" Width="60px">
                </asp:DropDownList>
                &nbsp; ��
                <asp:Label ID="lblTimeError" runat="server" CssClass="psword_f"></asp:Label>
                <ajaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="dtpScopeTo"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td width="2%" align="right">
            </td>
            <td width="6%" align="left">
                ����ʱ���ѯ
            </td>
            <td align="left" style="height: 36px; width: 10%;">
                <asp:TextBox ID="txtOperatimeFrom" runat="server" Width="158px" CssClass="input1"></asp:TextBox>
                <ajaxToolKit:CalendarExtender ID="CalendarExtender3" runat="server" Format="yyyy-MM-dd"
                    TargetControlID="txtOperatimeFrom">
                </ajaxToolKit:CalendarExtender>
            </td>
            <td align="left" width="15%" colspan="2">
                &nbsp;--- &nbsp;
                <asp:TextBox ID="txtOperatimeTo" runat="server" CssClass="input1"></asp:TextBox>
                <ajaxToolKit:CalendarExtender ID="CalendarExtender4" runat="server" Format="yyyy-MM-dd"
                    TargetControlID="txtOperatimeTo">
                </ajaxToolKit:CalendarExtender>
            </td>
            <td align="right" style="width: 5%;">
                ������Դ
            </td>
            <td width="25%" align="left">
                <asp:DropDownList ID="listOperator" runat="server" Width="160px">
                </asp:DropDownList>
                <asp:HiddenField ID="HftempTimeTo" runat="server" />
            </td>
        </tr>
        <%--</table>
            </td>
        </tr>--%>
    </table>
</div>
<div class="tablebt">
    <asp:Button ID="btnSearch" runat="server" CssClass="inputbt" OnClick="btnSearch_Click"
        Text="�顡ѯ" />
    <asp:Button ID="btnAdd" runat="server" CssClass="inputbt" Text="��  ��" OnClick="btnAdd_Click" />
    <input id="btnExport" type="button" value="������" class="inputbt" onclick="location.href='InAndOutStatisticsRecordExport.aspx?type=personList';" />
</div>
<div id="tbInAndOutStatistics" runat="server" class="linetable">
    <asp:GridView ID="gvInAndOutStatistics" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        GridLines="None" OnPageIndexChanging="gvInAndOutStatistics_PageIndexChanging"
        OnRowCommand="gvInAndOutStatistics_RowCommand" OnRowDataBound="gvLeaveRequestType_RowDataBound"
        Width="100%">
        <HeaderStyle CssClass="headerstyleblue" Height="28px" HorizontalAlign="Center" />
        <RowStyle Height="28px" CssClass="GridViewRowLink" />
        <AlternatingRowStyle CssClass="table_g" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnHiddenPostButton" runat="server" CommandArgument='<%# Eval("RecordID") %>'
                        CommandName='<%# Eval("EmployeeId") %>' Style="display: none;" Text=""></asp:LinkButton></ItemTemplate>
                <ItemStyle Width="2%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ա��">
                <ItemTemplate>
                    <%# Eval("EmployeeName") %>
                </ItemTemplate>
                <ItemStyle Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="״̬">
                <ItemTemplate>
                    <asp:Label ID="lblIoStatus" runat="server" Text='<%# Eval("IOStatus") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ʱ��">
                <ItemTemplate>
                    <%#Eval("IOTime")%>
                </ItemTemplate>
                <ItemStyle Width="15%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="������Դ">
                <ItemTemplate>
                    <asp:Label ID="lblOperateStatus" runat="server" Text='<%# Eval("OperateStatus") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="15%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="����ʱ��">
                <ItemTemplate>
                    <%#Eval("OperateTime")%>
                </ItemTemplate>
                <ItemStyle Width="15%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnModify" runat="server" CommandArgument='<%# Eval("RecordID")%>'
                        OnCommand="btnModify_Click" Text="�޸�"></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle Width="15%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%# Eval("RecordID")%>'
                        OnCommand="btnDelete_Click" Text="ɾ��"></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle Width="15%" />
            </asp:TemplateField>
        </Columns>
        <PagerTemplate>
            <%--                        <div class="pages">
                            <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton"
                                CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    ��һҳ</asp:LinkButton>
                            <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton"
                                CommandArgument="Next" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    ��һҳ</asp:LinkButton>
                        </div>--%>
            <uc1:PageTemplate ID="PageTemplate1" runat="server" />
        </PagerTemplate>
    </asp:GridView>
</div>
