<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FBQuesTypeListView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.FBQuesType.FBQuesTypeListView" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<div class="leftitbor">
    <span class="font14b">共查询到 </span>
        <asp:Label ID="LblMessage" runat="server" Text="" CssClass="fontred"></asp:Label>
        <span class="font14b">条记录</span>
</div>
<div class="leftitbor2">
    设置反馈问题类型
</div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td align="left" style="width: 2%;">
                </td>
            <td align="left" style="width: 8%;">
                反馈问题类型</td>
            <td align="left" style="width: 41%">
                <asp:TextBox runat="server" ID="TxtName" CssClass="input1" Width="40%"></asp:TextBox>
            </td>
            <td align="left" style="width: 8%;">
                </td>
            <td align="left" style="width: 41%">
            </td>
            
        </tr>
    </table>
</div>
<div class="tablebt">
    <asp:Button ID="BtnSearch" runat="server" Text="查  询" OnClick="BtnSearch_Click" CssClass="inputbt" />
    <asp:Button ID="btnAdd" runat="server" CssClass="inputbt" OnClick="btnAdd_Click"
        Text="新  增" />
</div>
<div id="Result" runat="server" class="linetablediv">
    <asp:GridView GridLines="None" Width="100%" ID="GridView1" runat="server" AutoGenerateColumns="False"
        AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand"
        OnRowDataBound="GridView1_RowDataBound">
        <HeaderStyle Height="28px" CssClass="headerstyleblue" />
        <RowStyle Height="28px" CssClass="GridViewRowLink" />
         <AlternatingRowStyle CssClass="table_g" />
        <Columns>
            <asp:TemplateField HeaderStyle-Width="2%">
                <ItemTemplate>
                    <asp:LinkButton ID="btnHiddenPostButton" runat="server" CommandArgument='<%# Eval("ParameterID") %>'
                        CommandName="HiddenPostButtonCommand"></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle Width="2%" />
            </asp:TemplateField>
            <%--<asp:BoundField HeaderText="" DataField="ParameterID" HeaderStyle-Width="0%" ItemStyle-Width="0%" />--%>
            <asp:BoundField HeaderText="类型名称" DataField="Name" HeaderStyle-Width="20%" ItemStyle-Width="20%" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton runat="server" ID="lbModify" OnCommand="lbModify_Click" CommandArgument='<%# Eval("ParameterID") %>'>修改</asp:LinkButton>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton runat="server" ID="lbDelete" OnCommand="lbDelete_Click" CommandArgument='<%# Eval("ParameterID") %>'>删除</asp:LinkButton>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="15%" />
            </asp:TemplateField>
        </Columns>
        <PagerTemplate>
       <uc1:PageTemplate ID="PageTemplate1" runat="server" />     
<%--            <div class="pages">
                <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton"
                    CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    上一页</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton"
                    CommandArgument="Next" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    下一页</asp:LinkButton>
            </div>--%>
        </PagerTemplate>
    </asp:GridView>

</div>
