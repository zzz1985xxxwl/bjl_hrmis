<%@ Import Namespace="ShiXin.Security" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OutApplicationSelfListView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.OutApplications.OutApplicationSelfListView" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<asp:HiddenField ID="hfCount" runat="server" Value="0" />
<div class="leftitbor2">
    <asp:Label ID="lbOperationType" runat="server">�ҵ������</asp:Label>
    &nbsp; <a href="../../../Pages/HRMIS/OutApplicationPages/AddOutApplication.aspx">���������</a>
</div>
<div class="marginepx">
    <asp:GridView ID="grd" runat="server" CssClass="linetable" GridLines="None" AllowPaging="True"
        AutoGenerateColumns="False" OnPageIndexChanging="grd_PageIndexChanging" Width="100%"
        OnRowDataBound="grd_RowDataBound" OnRowCommand="grd_RowCommand">
        <HeaderStyle CssClass="headerstyleblue" Height="28px" HorizontalAlign="Center" />
        <RowStyle Height="28px" CssClass="GridViewRowLink" />
        <AlternatingRowStyle CssClass="table_g" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnHiddenPostButton" CommandArgument='<%# Eval("PKID") %>' CommandName="HiddenPostButtonCommand"
                        runat="server" Text="" Style="display: none;" />
                </ItemTemplate>
                <ItemStyle Width="2%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="�����Ա">
                <ItemTemplate>
                    <asp:Label ID="lbAccount" runat="server" Text='<%# Eval("Account.Name") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="7%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="��������">
                <ItemTemplate>
                    <asp:Label ID="lbSubmitDate" runat="server" Text='<%# Eval("SubmitDate") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="12%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="��ʼʱ��">
                <ItemTemplate>
                    <asp:Label ID="lblFromDate" runat="server" Text='<%# Eval("FromDate") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="12%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="����ʱ��">
                <ItemTemplate>
                    <asp:Label ID="lblToDate" runat="server" Text='<%# Eval("ToDate") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="12%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="�������">
                <ItemTemplate>
                    <%# Eval("OutType.Name") %>
                </ItemTemplate>
                <ItemStyle Width="7%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="���Сʱ">
                <ItemTemplate>
                    <asp:Label ID="lblCostTime" runat="server" Text='<%# Eval("CostTime") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="7%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="��ϸ��">
                <ItemTemplate>
                    <table width="100%" border="0" cellspacing="5" cellpadding="0">
                        <%#Eval("OutItemsShow")%>
                    </table>
                </ItemTemplate>
                <ItemStyle Width="22%" HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnUpdate" runat="server" Text="�༭" CommandArgument='<%# Eval("PKID") %>'
                        OnCommand="Update_Command"></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle Width="4%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%# Eval("PKID") %>'
                        Enabled='<%# Eval("IfEdit").ToString()=="True" %>' OnCommand="Delete_Command"
                        Text="ɾ��" />
                </ItemTemplate>
                <ItemStyle Width="4%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnFastCancel" runat="server" Enabled='<%# Eval("IfCancel").ToString()=="True" %>'
                        CommandArgument='<%# Eval("PKID") %>' OnCommand="FastCancel_Command" Text="����ȡ��" />
                </ItemTemplate>
                <ItemStyle Width="7%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnCancel" runat="server" Enabled='<%# Eval("IfCancel").ToString()=="True" %>'
                        CommandArgument='<%# Eval("PKID") %>' OnCommand="Cancel_Command" Text="ȡ��" />
                </ItemTemplate>
                <ItemStyle Width="4%" />
            </asp:TemplateField>
        </Columns>
        <PagerTemplate>
            <%--		<div class="pages">
		    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton" CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    ��һҳ</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton" CommandArgument="Next" CommandName="Page"  Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    ��һҳ</asp:LinkButton>
		</div>     --%>
            <uc1:PageTemplate ID="PageTemplate1" runat="server" />
        </PagerTemplate>
    </asp:GridView>
</div>
