<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ApplicationSearchView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.AttendanceStatistics.ApplicationSearchView" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<div class="leftitbor">
    <span class="font14b">���鵽 </span>
    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="fontred"></asp:Label>
    <span class="font14b">����¼</span>
    <asp:Label ID="lblErrorMessage" runat="server" CssClass="fontred"></asp:Label>
</div>
<div class="leftitbor2">
    ��ѯ����</div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td align="left" style="width: 2%;">
            </td>
            <td align="left" style="width: 8%;">
                Ա������
            </td>
            <td align="left" style="width: 25%">
                <asp:TextBox ID="txtEmployeeName" runat="server" CssClass="input1" Width="40%"></asp:TextBox>
            </td>
            <td align="left" style="width: 8%;">
                ����
            </td>
            <td align="left" style="width: 25%">
                <asp:DropDownList ID="listDepartment" runat="server" Width="40%">
                </asp:DropDownList>
            </td>
            <td align="left" style="width: 8%;">
                ְϵ
            </td>
            <td align="left" style="width: 25%">
                <asp:DropDownList ID="ddGrades" runat="server" Width="40%">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="left">
            </td>
            <td align="left">
                ��������
            </td>
            <td align="left">
                <asp:DropDownList ID="ddApplicationType" runat="server" Width="40%">
                </asp:DropDownList>
            </td>
            <td align="left">
                ״̬
            </td>
            <td align="left">
                <asp:DropDownList ID="ddStatus" runat="server" Width="40%">
                </asp:DropDownList>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td align="left">
            </td>
            <td align="left">
                ��ѯʱ�䷶Χ
            </td>
            <td align="left" colspan="5">
                <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="dtpScopeFrom"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
                <ajaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="dtpScopeTo"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
                <asp:TextBox ID="dtpScopeFrom" runat="server" CssClass="input1"></asp:TextBox>
                &nbsp;-- &nbsp;&nbsp;<asp:TextBox ID="dtpScopeTo" runat="server" CssClass="input1"></asp:TextBox>&nbsp;<asp:Label
                    ID="lblValidateTime" runat="server" CssClass="psword_f"></asp:Label>
            </td>
        </tr>
    </table>
</div>
<div class="tablebt">
    <asp:Button ID="btnSearch" runat="server" CssClass="inputbt" OnClick="btnSearch_Click"
        Text="�顡ѯ" />
    <asp:Button ID="btnExport" runat="server" CssClass="inputbt" OnClick="btnExport_Click"
        Text="��  ��" />
</div>
<div id="tbInAndOutStatistics" runat="server" class="linetable">
    <asp:GridView ID="gvApplicationList" OnPageIndexChanging="gvApplicationList_PageIndexChanging"
        OnRowDataBound="gvApplicationList_RowDataBound" OnRowCommand="gvApplicationList_OnRowCommand"
        Width="100%" runat="server" AutoGenerateColumns="False" AllowPaging="True" BorderStyle="None"
        GridLines="None">
        <HeaderStyle Height="28px" CssClass="headerstyleblue" />
        <RowStyle Height="28px" CssClass="GridViewRowLink" />
        <AlternatingRowStyle CssClass="table_g" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("PKID")+";"+Eval("RequestType") %>'
                        CommandName="HiddenPostButtonCommand" runat="server" Text="" Style="display: none;" /></ItemTemplate>
                <ItemStyle Width="2%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="������">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Account.Name") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="8%" />
            </asp:TemplateField>
            <asp:BoundField DataField="FromDate" HeaderText="��ʼ����">
                <ItemStyle Width="12%" />
            </asp:BoundField>
            <asp:BoundField DataField="ToDate" HeaderText="��������">
                <ItemStyle Width="12%" />
            </asp:BoundField>
            <asp:BoundField DataField="RequestTime" HeaderText="����Сʱ">
                <ItemStyle Width="8%" />
            </asp:BoundField>
            <asp:BoundField DataField="RequestTypeShow" HeaderText="��������">
                <ItemStyle Width="8%" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="��ϸ��">
                <ItemTemplate>
                    <table width="100%" border="0" cellspacing="5" cellpadding="0">
                        <%#Eval("ItemsShow")%>
                    </table>
                </ItemTemplate>
                <ItemStyle Width="25%" HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="������Ϣ">
                <ItemTemplate>
                    <%#Eval("MoreDetailShow")%>
                </ItemTemplate>
                <ItemStyle Width="25%" HorizontalAlign="Left" />
            </asp:TemplateField>
        </Columns>
        <PagerTemplate>
            <uc1:PageTemplate ID="PageTemplate1" runat="server" />
            <%--                        <div class="pages">
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
