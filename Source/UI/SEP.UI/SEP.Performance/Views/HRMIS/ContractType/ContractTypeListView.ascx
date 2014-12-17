<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContractTypeListView.ascx.cs"
    Inherits="SEP.Performance.Views.ContractType.ContractTypeListView" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<div class="leftitbor">
    <span class="font14b">
        <asp:Label ID="lblMessage" runat="server"></asp:Label></span>
</div>
<div class="leftitbor2">
    设置合同类型
</div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td align="left" style="width: 2%;">
            </td>
            <td align="left" style="width: 8%;">
                名称
            </td>
            <td align="left" style="width: 41%">
                <asp:TextBox ID="txtName" runat="server" Width="40%" class="input1"></asp:TextBox>
            </td>
            <td align="left" style="width: 8%;">
                
            </td>
            <td align="left" style="width: 41%">
            </td>
        </tr>
    </table>
</div>
<div class="tablebt">
    <asp:Button ID="btnSearch" runat="server" Text="查　询" OnClick="btnSearch_Click" CssClass="inputbt" />
    <asp:Button ID="btnAdd" runat="server" CssClass="inputbt" OnClick="btnAdd_Click"
        Text="新  增" />
</div>
<div id="Result" runat="server" class="linetablediv">
    <asp:GridView GridLines="None" Width="100%" ID="dg" runat="server" AutoGenerateColumns="False"
        AllowPaging="True" OnPageIndexChanging="dg1_PageIndexChanging" OnRowCommand="dg_RowCommand"
        OnRowDataBound="dg_RowDataBound">
        <HeaderStyle Height="28px" CssClass="headerstyleblue" />
        <RowStyle Height="28px" CssClass="GridViewRowLink" />
        <AlternatingRowStyle CssClass="table_g" />
        <Columns>
            <asp:TemplateField HeaderStyle-Width="2%">
                <ItemTemplate>
                    <asp:LinkButton ID="btnHiddenPostButton" runat="server" CommandArgument='<%# Eval("ContractTypeID") %>'
                        CommandName="HiddenPostButtonCommand"></asp:LinkButton></ItemTemplate>
                <ItemStyle Width="2%" />
            </asp:TemplateField>
            <%--<asp:BoundField HeaderText="编号"  DataField="ContractTypeID"  HeaderStyle-Width="10%" ItemStyle-Width="10%"/>--%>
            <asp:BoundField HeaderText="合同类型名称" DataField="ContractTypeName" HeaderStyle-Width="30%"
                ItemStyle-Width="35%" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnDownLoad" runat="server" Text="下载模板" Enabled="false" CausesValidation="false"
                        CommandName='<%#Eval("ContractTypeName") %>' CommandArgument='<%# Eval("ContractTypeID") %>'
                        OnCommand="DownLoad_Command" />
                </ItemTemplate>
                <ItemStyle Width="15%" />
            </asp:TemplateField>
            <asp:TemplateField Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblHasTemplate" runat="server" Text='<%# Eval("HasTemplate") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton runat="server" ID="lbModify" OnCommand="lbModify_Click" CommandArgument='<%# Eval("ContractTypeID") %>'>修改</asp:LinkButton>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="15%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton runat="server" ID="lbDelete" OnCommand="lbDelete_Click" CommandArgument='<%# Eval("ContractTypeID") %>'>删除</asp:LinkButton>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="15%" />
            </asp:TemplateField>
        </Columns>
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
