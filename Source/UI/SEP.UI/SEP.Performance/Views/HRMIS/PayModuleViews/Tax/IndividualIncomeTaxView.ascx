<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IndividualIncomeTaxView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.PayModuleViews.Tax.IndividualIncomeTaxView" %>
<%@ Register Src="../../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc2" %>
<%@ Register Src="EditTaxBand.ascx" TagName="EditTaxBand" TagPrefix="uc1" %>
<div id="trMessage" runat="server" class="leftitbor">
    <asp:Label ID="ErrorMessage" runat="server" />
</div>
<div class="leftitbor2">
    ����˰��</div>

<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td align="left" style="width: 2%;">
            </td>
            <td align="left" style="width: 8%;">
                ����������
            </td>
            <td align="left" style="width: 41%">
                <asp:TextBox ID="txtTaxCutoffPoint" class="input1" runat="server"></asp:TextBox>&nbsp;Ԫ
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
                ����������
            </td>
            <td align="left" style="width: 41%">
                <asp:TextBox ID="txtForeignTaxCutoffPoint" class="input1" runat="server"></asp:TextBox>&nbsp;Ԫ
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
    <asp:Button ID="btnSaveTaxCutoffPoint" runat="server" class="inputbt" Text="������"
        OnClick="btnSaveTaxCutoffPoint_Click" />
    <asp:Button ID="btnAddTaxBand" runat="server" class="inputbt" Text="�¡���" OnClick="btnAddTaxBand_Click" />
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
            <asp:BoundField DataField="TaxBandRange" HeaderText="˰��">
                <ControlStyle Width="30%" />
                <ItemStyle Width="30%" />
            </asp:BoundField>
            <asp:BoundField DataField="TaxRate" HeaderText="˰��(%)">
                <ControlStyle Width="20%" />
                <ItemStyle Width="20%" />
            </asp:BoundField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnUpdate" runat="server" Text="�޸�" CommandArgument='<%# Eval("TaxBandID") %>'
                        OnCommand="UpdateTaxBand_Command" />
                </ItemTemplate>
                <ItemStyle Width="20%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnDelete" runat="server" Text="ɾ��" OnClientClick="Confirmed = confirm('ȷ��Ҫɾ����'); return Confirmed;"
                        CommandArgument='<%# Eval("TaxBandID") %>' OnCommand="DeleteTaxBand_Command" />
                </ItemTemplate>
                <ItemStyle Width="20%" />
            </asp:TemplateField>
        </Columns>
        <PagerTemplate>
<%--            <div class="pages">
                <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton"
                    CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    ��һҳ</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton"
                    CommandArgument="Next" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    ��һҳ</asp:LinkButton>
            </div>--%>
    <uc2:PageTemplate ID="PageTemplate1" runat="server" />            
        </PagerTemplate>
    </asp:GridView>

</div>
