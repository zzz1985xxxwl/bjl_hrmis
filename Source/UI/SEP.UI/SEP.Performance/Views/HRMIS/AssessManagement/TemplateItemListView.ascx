<%@ Import Namespace="ShiXin.Security" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TemplateItemListView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.AssessManagement.TemplateItemListView" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<div id="tbMessage" runat="server" class="leftitbor">
    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="font14b"/>
    <asp:Label ID="lblDelMsg" runat="server" Text="" CssClass="font14b" />
</div>
<div class="leftitbor2">
    设置绩效考核项
</div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td align="left" style="width: 2%;">
            </td>
            <td align="left" style="width: 10%;">
                指标项描述
            </td>
            <td width="15%" align="left">
                <asp:TextBox ID="txtQuestion" runat="server" CssClass="input1" />
            </td>
            <td width="4%" align="left">
                题型
            </td>
            <td width="15%" align="left">
                <asp:DropDownList ID="ddItemType" runat="server" Width="60%">
                 <asp:ListItem></asp:ListItem>
                 <asp:ListItem>选择项</asp:ListItem>
                 <asp:ListItem>开放项</asp:ListItem>
                 <asp:ListItem>打分项</asp:ListItem>
                 <asp:ListItem>公式项</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td width="4%" align="left">
                分类
            </td>
            <td width="15%" align="left">
                <asp:DropDownList ID="listItemClassfication" runat="server" Width="60%">
                </asp:DropDownList>
            </td>
            <td width="4%" align="left">
                类型
            </td>
            <td width="15%" align="left">
                <asp:DropDownList ID="listOperateType" runat="server" Width="60%">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>人力资源项</asp:ListItem>
                    <asp:ListItem>非人力资源项</asp:ListItem>
                </asp:DropDownList>
            </td>
            
        </tr>
    </table>
</div>
<div class="tablebt">
    <asp:Button ID="btnSearch" runat="server" Text="查　询" OnClick="btnSearch_Click" CssClass="inputbt" />
    <asp:Button ID="btnAdd" runat="server" Text="新　增" CssClass="inputbt" OnClick="btnAdd_Click" />
</div>
<div id="tbSearch" runat="server" class="linetablediv">
    <asp:GridView GridLines="None" Width="100%" ID="grvitemlist" runat="server" AutoGenerateColumns="False"
        AllowPaging="True" OnPageIndexChanging="grvitemlist_PageIndexChanging" OnRowCommand="grvitemlist_RowCommand"
        OnRowDataBound="grvitemlist_RowDataBound">
        <HeaderStyle Height="28px" HorizontalAlign="Center" CssClass="headerstyleblue" />
        <AlternatingRowStyle CssClass="table_g" />
        <Columns>
            <asp:TemplateField HeaderStyle-Width="2%">
                <ItemTemplate>
                    <asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("AssessTemplateItemID") %>'
                        CommandName="HiddenPostButtonCommand" runat="server" Text="" Style="display: none;" /></ItemTemplate>
                <ItemStyle Width="2%" />
            </asp:TemplateField>
            <%--<asp:TemplateField HeaderStyle-Width="5%" HeaderText="编号">
                           <ItemTemplate >
                    <asp:LinkButton ID="btnDetail" runat="server" Width="30px" Text='<%# Eval("AssessTemplateItemID") %>' CausesValidation="false"
                       href='<%# string.Format("AssessTemplateItemDetail.aspx?ItemID={0}", Eval("AssessTemplateItemID")) %>'/>
                </ItemTemplate>
            </asp:TemplateField>--%>
            <asp:BoundField DataField="Question" HeaderText="指标项描述" HeaderStyle-Width="39%" />
             <asp:BoundField DataField="AssessTemplateItemTypeName" HeaderText="题型" HeaderStyle-Width="7%" />
            <asp:TemplateField HeaderText="分&nbsp;类" HeaderStyle-Width="7%">
                <ItemTemplate>
                    <asp:Label ID="lblType" runat="server" Text='<%# Eval("Classfication") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField  DataField="OptionToShow" HeaderStyle-Width="25%"
                ItemStyle-HorizontalAlign="Left" />
            <asp:TemplateField HeaderText="人力资源项" HeaderStyle-Width="8%">
                <ItemTemplate>
                    <asp:CheckBox ID="chbType" runat="server" Text='<%# Eval("ItsOperateType") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="5%">
                <ItemTemplate>
                    <asp:LinkButton ID="btnUpdate" runat="server" Width="30px" Text="修改" href='<%# string.Format("AssessTemplateItemUpdate.aspx?ItemID={0}", SecurityUtil.DECEncrypt(Eval("AssessTemplateItemID").ToString())) %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="5%">
                <ItemTemplate>
                    <asp:LinkButton ID="btnDelete" runat="server" Text="删除" CausesValidation="false"
                        CommandArgument='<%# Eval("AssessTemplateItemID") %>' OnClientClick="Confirmed = confirm('确定要删除吗？'); return Confirmed;"
                        OnCommand="Delete_Command" ToolTip="删除" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <RowStyle Height="28px" CssClass="GridViewRowLink" />
        <SelectedRowStyle BackColor="#F7F3FF" />
        <PagerTemplate>
<%--            <div class="pages">
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
