<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AccountSetListView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.PayModuleViews.AccountSetListView" %>
<%@ Register Src="../../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<div class="leftitbor">
    <span class="font14b">����ѯ�� </span><span class="fontred">
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label></span> <span class="font14b">
            ����¼</span>
</div>
<div class="leftitbor2">
    ��������
</div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td align="left" style="width: 2%;">
            </td>
            <td align="left" style="width: 8%;">
                ��������
            </td>
            <td align="left" style="width: 41%">
                <asp:TextBox runat="server" ID="txtName" Width="40%" class="input1"></asp:TextBox>&nbsp;&nbsp;
            </td>
            <td align="left" style="width: 8%;">
            </td>
            <td align="left" style="width: 41%">
            </td>
    </table>
</div>
<div class="tablebt">
    <asp:Button ID="btnSearch" runat="server" Text="��  ѯ" OnClick="btnSearch_Click" class="inputbt" />
    <asp:Button ID="btnAdd" runat="server" CssClass="inputbt" OnClick="btnAdd_Click"
        Text="��  ��" /></div>
<div id="tbAccountSetList" runat="server" class="linetable">
    <asp:GridView GridLines="None" Width="100%" ID="gvAccountSetList" runat="server"
        AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="gvAccountSetList_PageIndexChanging"
        OnRowCommand="gvAccountSetList_RowCommand" OnRowDataBound="gvAccountSetList_RowDataBound"
        PageSize="20">
        <HeaderStyle Height="28px" CssClass="headerstyleblue" />
        <RowStyle Height="28px" CssClass="GridViewRowLink" />
        <AlternatingRowStyle CssClass="table_g" />
        <Columns>
            <asp:TemplateField HeaderStyle-Width="2%">
                <ItemTemplate>
                    <asp:LinkButton ID="btnHiddenPostButton" runat="server" CommandArgument='<%# Eval("AccountSetID") %>'
                        CommandName="HiddenPostButtonCommand"></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle Width="2%" />
            </asp:TemplateField>
            <%--<asp:TemplateField HeaderText="���ױ��">
                            <ItemTemplate>
                                <%# Eval("AccountSetID") %>
                            </ItemTemplate>
                            <ItemStyle Width="15%" />
                        </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="��������">
                <ItemTemplate>
                    <%# Eval("AccountSetName") %>
                </ItemTemplate>
                <ItemStyle Width="25%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="����">
                <ItemTemplate>
                    <%# Eval("Description") %>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="35%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton runat="server" ID="lbModify" OnCommand="lbModify_Click" CommandArgument='<%# Eval("AccountSetID") %>'>�޸�</asp:LinkButton>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="6%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton runat="server" ID="lbDelete" OnCommand="lbDelete_Click" CommandArgument='<%# Eval("AccountSetID") %>'
                        OnClientClick="Confirmed = confirm('ȷ��Ҫɾ����'); return Confirmed;">ɾ��</asp:LinkButton>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="6%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton runat="server" ID="lbCopy" OnCommand="lbCopy_Click" CommandArgument='<%# Eval("AccountSetID") %>'>��������</asp:LinkButton>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="8%" />
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
