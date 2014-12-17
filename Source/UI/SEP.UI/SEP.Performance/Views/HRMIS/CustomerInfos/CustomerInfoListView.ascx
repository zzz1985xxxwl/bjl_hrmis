<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CustomerInfoListView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.CustomerInfos.CustomerInfoListView" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<div class="leftitbor">
        <asp:Label ID="lblMessage" runat="server" Text="" ></asp:Label>
</div>
<div class="leftitbor2">
    设置客户信息
</div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>   
            <td align="left" style=" width:10%;padding-left:35px;">
               客户名称</td>
            <td align="left" style=" width:90%;">
                <asp:TextBox ID="txtName" runat="server" Width="150px" class="input1"></asp:TextBox>
            </td>
        </tr>
    </table>
</div>
<div class="tablebt">
    <asp:Button ID="btnSearch" runat="server" Text="查　询" OnClick="btnSearch_Click" CssClass="inputbt" />
    <asp:Button ID="btnAdd" runat="server" Text="新  增" OnClick="btnAdd_Click" CssClass="inputbt" />
</div>
<div class="nolinetablediv">
                <asp:GridView CssClass="linetable"  GridLines="None" Width="100%" ID="gvAdjustRule" runat="server" AutoGenerateColumns="False"
                    AllowPaging="True" OnPageIndexChanging="gvAdjustRule_PageIndexChanging" OnRowCommand="gvAdjustRule_RowCommand"
                    OnRowDataBound="gvAdjustRule_RowDataBound">
                    <HeaderStyle Height="28px" CssClass="headerstyleblue" />
                    <RowStyle Height="28px" CssClass="GridViewRowLink" />
                    <AlternatingRowStyle CssClass="table_g" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnHiddenPostButton" CommandArgument='<%# Eval("CustomerInfoId") %>'
                                    CommandName="HiddenPostButtonCommand" runat="server" Text="" Style="display: none;" /></ItemTemplate>
                            <ItemStyle Width="5%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="客户名称">
                            <ItemTemplate>
                                <%#Eval("CompanyName")%>
                            </ItemTemplate>
                            <ItemStyle Width="75%" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnModify" Text="修改" OnCommand="btnModify_Click" runat="server"
                                    CommandArgument='<%# Eval("CustomerInfoId")%>' />
                            </ItemTemplate>
                            <ItemStyle Width="10%" />
                        </asp:TemplateField>
                         <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnDelete" Text="删除" OnCommand="btnDelete_Click" runat="server"
                                    CommandArgument='<%# Eval("CustomerInfoId")%>' />
                            </ItemTemplate>
                            <ItemStyle Width="10%" />
                        </asp:TemplateField>
                    </Columns>
                    <PagerTemplate>
<%--                        <div class="pages">
                            <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton"
                                CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    上一页</asp:LinkButton>
                            <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton"
                                CommandArgument="Next" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    下一页</asp:LinkButton>
                        </div>--%>
    <uc1:PageTemplate ID="PageTemplate1" runat="server" />                        
                    </PagerTemplate>
                </asp:GridView>

</div>