<%@ Import Namespace="ShiXin.Security" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OutApplicationSelfListView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.OutApplications.OutApplicationSelfListView" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<asp:HiddenField ID="hfCount" runat="server" Value="0" />
<div class="leftitbor2">
    <asp:Label ID="lbOperationType" runat="server">我的外出单</asp:Label>
    &nbsp; <a href="../../../Pages/HRMIS/OutApplicationPages/AddOutApplication.aspx">新增外出单</a>
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
            <asp:TemplateField HeaderText="外出人员">
                <ItemTemplate>
                    <asp:Label ID="lbAccount" runat="server" Text='<%# Eval("Account.Name") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="7%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="申请日期">
                <ItemTemplate>
                    <asp:Label ID="lbSubmitDate" runat="server" Text='<%# Eval("SubmitDate") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="12%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="开始时间">
                <ItemTemplate>
                    <asp:Label ID="lblFromDate" runat="server" Text='<%# Eval("FromDate") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="12%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="结束时间">
                <ItemTemplate>
                    <asp:Label ID="lblToDate" runat="server" Text='<%# Eval("ToDate") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="12%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="外出类型">
                <ItemTemplate>
                    <%# Eval("OutType.Name") %>
                </ItemTemplate>
                <ItemStyle Width="7%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="外出小时">
                <ItemTemplate>
                    <asp:Label ID="lblCostTime" runat="server" Text='<%# Eval("CostTime") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="7%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="详细项">
                <ItemTemplate>
                    <table width="100%" border="0" cellspacing="5" cellpadding="0">
                        <%#Eval("OutItemsShow")%>
                    </table>
                </ItemTemplate>
                <ItemStyle Width="22%" HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnUpdate" runat="server" Text="编辑" CommandArgument='<%# Eval("PKID") %>'
                        OnCommand="Update_Command"></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle Width="4%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%# Eval("PKID") %>'
                        Enabled='<%# Eval("IfEdit").ToString()=="True" %>' OnCommand="Delete_Command"
                        Text="删除" />
                </ItemTemplate>
                <ItemStyle Width="4%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnFastCancel" runat="server" Enabled='<%# Eval("IfCancel").ToString()=="True" %>'
                        CommandArgument='<%# Eval("PKID") %>' OnCommand="FastCancel_Command" Text="快速取消" />
                </ItemTemplate>
                <ItemStyle Width="7%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnCancel" runat="server" Enabled='<%# Eval("IfCancel").ToString()=="True" %>'
                        CommandArgument='<%# Eval("PKID") %>' OnCommand="Cancel_Command" Text="取消" />
                </ItemTemplate>
                <ItemStyle Width="4%" />
            </asp:TemplateField>
        </Columns>
        <PagerTemplate>
            <%--		<div class="pages">
		    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton" CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    上一页</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton" CommandArgument="Next" CommandName="Page"  Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    下一页</asp:LinkButton>
		</div>     --%>
            <uc1:PageTemplate ID="PageTemplate1" runat="server" />
        </PagerTemplate>
    </asp:GridView>
</div>
