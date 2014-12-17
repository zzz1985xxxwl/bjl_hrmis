<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VacationUsedDetailsView.ascx.cs"
    Inherits="SEP.Performance.VacationUsedDetailsView" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<div id="UsedDetail" runat="server">
    <div class="font14px marginepx" style="text-align: left; margin-bottom: 0px;">
        使用情况</div>
    <div class="linetablediv" style="margin-top: 0px;">
        <asp:GridView ID="gdUsedDetail" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            GridLines="None" Width="100%" OnPageIndexChanging="gdUsedDetail_PageIndexChanging"
            OnRowDataBound="gdUsedDetail_RowDataBound">
            <HeaderStyle CssClass="headerstyleblue" Height="28px" />
            <RowStyle Height="28px" CssClass="GridViewRowLink" />
            <AlternatingRowStyle CssClass="table_g" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnHiddenPostButton" CommandName="HiddenPostButtonCommand" runat="server"
                            Text="" Style="display: none;" />
                    </ItemTemplate>
                    <ItemStyle Width="4%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="请假时间段">
                    <ItemTemplate>
                        <%#Eval("FromDate")%>---<%#Eval("ToDate")%>
                    </ItemTemplate>
                    <HeaderStyle Width="32%" />
                </asp:TemplateField>
                <asp:BoundField DataField="CostTime" HeaderText="请假小时">
                    <ItemStyle Width="32%" />
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Remark" HeaderText="理由">
                    <ItemStyle Width="32%" HorizontalAlign="Left" />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:BoundField>
            </Columns>
            <PagerTemplate>
                <uc1:PageTemplate ID="PageTemplate1" runat="server" />
                <%--                	<div class="pages">
	                    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton" CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
	                    上一页</asp:LinkButton>
	                    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton" CommandArgument="Next" CommandName="Page"  Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
	                    下一页</asp:LinkButton>
	                </div>   --%>
            </PagerTemplate>
        </asp:GridView>
    </div>
</div>
