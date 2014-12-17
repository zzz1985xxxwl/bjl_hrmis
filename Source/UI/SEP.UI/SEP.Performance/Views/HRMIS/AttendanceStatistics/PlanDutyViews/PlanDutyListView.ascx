<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PlanDutyListView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.AttendanceStatistics.PlanDutyViews.PlanDutyListView" %>
<%@ Register Src="../../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<div class="leftitbor">
    <span class="font14b">���鵽 </span>
    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="fontred"></asp:Label>
    <span class="font14b">����¼</span>
    <asp:Label ID="lblTitleMessage" runat="server" Text="" CssClass="fontred"></asp:Label>
</div>
<div class="leftitbor2">
    �����Ű��
</div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td width="2%" align="left">
            </td>
            <td width="50%" align="left">
                �Ű������
                <asp:TextBox ID="txtPlanDutyTableName" runat="server" CssClass="input1"></asp:TextBox>
            </td>
            <td width="50%" align="left">
                Ա������
                <asp:TextBox ID="txtEmployeeName" runat="server" CssClass="input1"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td width="2%" align="left">
            </td>
            <td width="20%" align="left" colspan="2">
                ʱ�䷶Χ&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtDateFrom" runat="server" CssClass="input1"></asp:TextBox><asp:Label
                    ID="lblDateFrom" runat="server" CssClass="psword_f"></asp:Label>
                <ajaxToolKit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtDateFrom"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
                ����
                <asp:TextBox ID="txtDateTo" runat="server" CssClass="input1"></asp:TextBox><asp:Label
                    ID="lblDateTo" runat="server" CssClass="psword_f"></asp:Label>
            </td>
            <ajaxToolKit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtDateTo"
                Format="yyyy-MM-dd">
            </ajaxToolKit:CalendarExtender>
        </tr>
        <%--</table>
            </td>
        </tr>--%>
    </table>
</div>
<div class="tablebt">
    <asp:Button ID="Button1" runat="server" Text="�顡ѯ" CssClass="inputbt" OnClick="btnSearch_Click" />
    <asp:Button ID="Button2" runat="server" Text="�¡���" CssClass="inputbt" OnClick="btnAdd_Click" />
</div>
<div id="tbPlanDutyTable" runat="server" class="linetable">
    <asp:GridView GridLines="None" Width="100%" ID="gvPlanDutyTable" runat="server" AutoGenerateColumns="False"
        AllowPaging="True" OnPageIndexChanging="gvPlanDutyTable_PageIndexChanging" OnRowCommand="gvPlanDutyTable_RowCommand"
        OnRowDataBound="gvPlanDutyTable_RowDataBound">
        <HeaderStyle Height="28px" CssClass="headerstyleblue" />
        <RowStyle Height="28px" CssClass="GridViewRowLink" />
        <AlternatingRowStyle CssClass="table_g" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnHiddenPostButton" CommandArgument='<%# Eval("PlanDutyTableID") %>'
                        CommandName="HiddenPostButtonCommand" runat="server" Text="" Style="display: none;" /></ItemTemplate>
                <ItemStyle Width="2%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="�Ű������">
                <ItemTemplate>
                    <%#Eval("PlanDutyTableName")%>
                </ItemTemplate>
                <ItemStyle Width="20%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ʱ�䷶Χ">
                <ItemTemplate>
                    <%#Eval("FromTime", "{0:yyyy-MM-dd}")%>
                    ---
                    <%#Eval("ToTime", "{0:yyyy-MM-dd}")%>
                </ItemTemplate>
                <ItemStyle Width="25%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ա��">
                <ItemTemplate>
                    <%#Eval("PlanDutyEmployeeNameList")%>
                </ItemTemplate>
                <ItemStyle Width="30%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnModify" Text="�޸�" OnCommand="btnModify_Click" runat="server"
                        CommandArgument='<%# Eval("PlanDutyTableID")%>' />
                </ItemTemplate>
                <ItemStyle Width="3%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" Text="ɾ��" OnClientClick="Confirmed = confirm('ȷ��Ҫɾ����'); return Confirmed;"
                        OnCommand="btnDelete_Click" runat="server" CommandArgument='<%# Eval("PlanDutyTableID")%>' />
                </ItemTemplate>
                <ItemStyle Width="3%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnCopy" Text="����" OnCommand="btnCopy_Click" runat="server" CommandArgument='<%# Eval("PlanDutyTableID")%>' />
                </ItemTemplate>
                <ItemStyle Width="3%" />
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
