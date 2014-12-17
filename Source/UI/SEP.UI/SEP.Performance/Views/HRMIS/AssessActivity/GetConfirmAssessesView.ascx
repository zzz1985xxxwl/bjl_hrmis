<%@ Import Namespace="SEP.HRMIS.Model" %>
<%--<%@ Import namespace="MyCmmiWebSite.Model"%>--%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GetConfirmAssessesView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.AssessActivity.GetConfirmAssessesView" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<div class="leftitbor">
    <span class="font14b">共有 </span><span class="fontred">
        <%Response.Write(AssessActivitys.Count.ToString()); %></span> <span class="font14b">
            个待确认绩效考核</span>
</div>
<div id="tbMessage" runat="server" class="leftitbor">
    <asp:Label ID="lblMessage" runat="server" CssClass="fontred"></asp:Label><%--<a href="#" class="fontreda"></a>--%>
</div>
<div id="tbAssess" runat="server">
    <div class="leftitbor2">
        待确认绩效考核
    </div>
    <div class="linetablediv">
        <asp:GridView GridLines="None" Width="100%" ID="grvitemlist" runat="server" AutoGenerateColumns="False"
            AllowPaging="True" OnPageIndexChanging="grvitemlist_PageIndexChanging" OnRowCommand="grvitemlist_RowCommand"
            OnRowDataBound="grvitemlist_RowDataBound">
            <HeaderStyle Height="28px" CssClass="headerstyleblue" />
            <RowStyle Height="28px" CssClass="GridViewRowLink" />
            <AlternatingRowStyle CssClass="table_g" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("AssessActivityID") %>'
                            CommandName="HiddenPostButtonCommand" runat="server" Text="" Style="display: none;" />
                    </ItemTemplate>
                    <ItemStyle Width="2%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="考核对象">
                    <ItemTemplate>
                        <%#Eval("ItsEmployee.Account.Name")%></a>
                    </ItemTemplate>
                    <ItemStyle Width="20%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="部  门">
                    <ItemTemplate>
                        <%#Eval("EmployeeDept")%></a>
                    </ItemTemplate>
                    <ItemStyle Width="20%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="考核性质">
                    <ItemTemplate>
                        <%#AssessActivityUtility.GetCharacterNameByType((AssessCharacterType)Eval("AssessCharacterType"))%></a>
                    </ItemTemplate>
                    <ItemStyle Width="20%" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="btnConfirm" runat="server" CommandArgument='<%# Eval("AssessActivityID")%>'
                            CommandName="Confirm" OnCommand="btnConfirm_Click" Text="确认" />
                    </ItemTemplate>
                    <ItemStyle Width="15%" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                    </ItemTemplate>
                    <ItemStyle Width="19%" />
                </asp:TemplateField>
            </Columns>
            <PagerTemplate>
                <%--		<div class="pages">
		    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton" CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    上一页</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton" CommandArgument="Next" CommandName="Page"  Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    下一页</asp:LinkButton>
		</div>        --%>
                <uc1:PageTemplate ID="PageTemplate1" runat="server"></uc1:PageTemplate>
            </PagerTemplate>
        </asp:GridView>
    </div>
</div>
