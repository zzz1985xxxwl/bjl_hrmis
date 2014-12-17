<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IndividualIncomeTaxView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.PayModuleViews.Tax.IndividualIncomeTaxView" %>
<%@ Register Src="../../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc2" %>
<%@ Register Src="EditTaxBand.ascx" TagName="EditTaxBand" TagPrefix="uc1" %>
<div id="trMessage" runat="server" class="leftitbor">
    <asp:Label ID="ErrorMessage" runat="server" />
</div>
<div class="leftitbor2">
    设置税制</div>

<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td align="left" style="width: 2%;">
            </td>
            <td align="left" style="width: 8%;">
                国内起征点
            </td>
            <td align="left" style="width: 41%">
                <asp:TextBox ID="txtTaxCutoffPoint" class="input1" runat="server"></asp:TextBox>&nbsp;元
                <asp:Label ID="lblTaxCutoffPoint" runat="server" CssClass="psword_f"/>
            </td>
            <td align="left" style="width: 8%;">
            </td>
            <td align="left" style="width: 41%">
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 2%;">
            </td>
            <td align="left" style="width: 8%;">
                国外起征点
            </td>
            <td align="left" style="width: 41%">
                <asp:TextBox ID="txtForeignTaxCutoffPoint" class="input1" runat="server"></asp:TextBox>&nbsp;元
                <asp:Label ID="lblForeignTaxCutoffPoint" runat="server" CssClass="psword_f"/>
            </td>
            <td align="left" style="width: 8%;">
            </td>
            <td align="left" style="width: 41%">
            </td>
        </tr>
    </table>
</div>
<div class="tablebt">
    <asp:Button ID="btnSaveTaxCutoffPoint" runat="server" class="inputbt" Text="保　存"
        OnClick="btnSaveTaxCutoffPoint_Click" />
    <asp:Button ID="btnAddTaxBand" runat="server" class="inputbt" Text="新　增" OnClick="btnAddTaxBand_Click" />
</div>
<div class="linetablediv" id="tbGVTaxBand" runat="server">
    <asp:GridView ID="gvTaxBand" Width="100%" runat="server" AutoGenerateColumns="False"
        BorderStyle="None" GridLines="None" AllowPaging="false" OnPageIndexChanging="gvTaxBand_PageIndexChanging"
        OnRowDataBound="gvTaxBand_RowDataBound">
        <HeaderStyle Height="28px" CssClass="headerstyleblue" />
        <RowStyle Height="28px" CssClass="GridViewRowLink" />
        <AlternatingRowStyle CssClass="table_g" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("TaxBandID") %>' CommandName="HiddenPostButtonCommand"
                        runat="server" Text="" Style="display: none;" />
                </ItemTemplate>
                <ItemStyle Width="2%" />
            </asp:TemplateField>
            <asp:BoundField DataField="TaxBandRange" HeaderText="税阶">
                <ControlStyle Width="30%" />
                <ItemStyle Width="30%" />
            </asp:BoundField>
            <asp:BoundField DataField="TaxRate" HeaderText="税率(%)">
                <ControlStyle Width="20%" />
                <ItemStyle Width="20%" />
            </asp:BoundField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnUpdate" runat="server" Text="修改" CommandArgument='<%# Eval("TaxBandID") %>'
                        OnCommand="UpdateTaxBand_Command" />
                </ItemTemplate>
                <ItemStyle Width="20%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnDelete" runat="server" Text="删除" OnClientClick="Confirmed = confirm('确定要删除吗？'); return Confirmed;"
                        CommandArgument='<%# Eval("TaxBandID") %>' OnCommand="DeleteTaxBand_Command" />
                </ItemTemplate>
                <ItemStyle Width="20%" />
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
    <uc2:PageTemplate ID="PageTemplate1" runat="server" />            
        </PagerTemplate>
    </asp:GridView>

</div>
