<%@ Import Namespace="ShiXin.Security" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TemplateItemListView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.AssessManagement.TemplateItemListView" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<div id="tbMessage" runat="server" class="leftitbor">
    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="font14b"/>
    <asp:Label ID="lblDelMsg" runat="server" Text="" CssClass="font14b" />
</div>
<div class="leftitbor2">
    ���ü�Ч������
</div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td align="left" style="width: 2%;">
            </td>
            <td align="left" style="width: 10%;">
                ָ��������
            </td>
            <td width="15%" align="left">
                <asp:TextBox ID="txtQuestion" runat="server" CssClass="input1" />
            </td>
            <td width="4%" align="left">
                ����
            </td>
            <td width="15%" align="left">
                <asp:DropDownList ID="ddItemType" runat="server" Width="60%">
                 <asp:ListItem></asp:ListItem>
                 <asp:ListItem>ѡ����</asp:ListItem>
                 <asp:ListItem>������</asp:ListItem>
                 <asp:ListItem>�����</asp:ListItem>
                 <asp:ListItem>��ʽ��</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td width="4%" align="left">
                ����
            </td>
            <td width="15%" align="left">
                <asp:DropDownList ID="listItemClassfication" runat="server" Width="60%">
                </asp:DropDownList>
            </td>
            <td width="4%" align="left">
                ����
            </td>
            <td width="15%" align="left">
                <asp:DropDownList ID="listOperateType" runat="server" Width="60%">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>������Դ��</asp:ListItem>
                    <asp:ListItem>��������Դ��</asp:ListItem>
                </asp:DropDownList>
            </td>
            
        </tr>
    </table>
</div>
<div class="tablebt">
    <asp:Button ID="btnSearch" runat="server" Text="�顡ѯ" OnClick="btnSearch_Click" CssClass="inputbt" />
    <asp:Button ID="btnAdd" runat="server" Text="�¡���" CssClass="inputbt" OnClick="btnAdd_Click" />
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
            <%--<asp:TemplateField HeaderStyle-Width="5%" HeaderText="���">
                           <ItemTemplate >
                    <asp:LinkButton ID="btnDetail" runat="server" Width="30px" Text='<%# Eval("AssessTemplateItemID") %>' CausesValidation="false"
                       href='<%# string.Format("AssessTemplateItemDetail.aspx?ItemID={0}", Eval("AssessTemplateItemID")) %>'/>
                </ItemTemplate>
            </asp:TemplateField>--%>
            <asp:BoundField DataField="Question" HeaderText="ָ��������" HeaderStyle-Width="39%" />
             <asp:BoundField DataField="AssessTemplateItemTypeName" HeaderText="����" HeaderStyle-Width="7%" />
            <asp:TemplateField HeaderText="��&nbsp;��" HeaderStyle-Width="7%">
                <ItemTemplate>
                    <asp:Label ID="lblType" runat="server" Text='<%# Eval("Classfication") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField  DataField="OptionToShow" HeaderStyle-Width="25%"
                ItemStyle-HorizontalAlign="Left" />
            <asp:TemplateField HeaderText="������Դ��" HeaderStyle-Width="8%">
                <ItemTemplate>
                    <asp:CheckBox ID="chbType" runat="server" Text='<%# Eval("ItsOperateType") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="5%">
                <ItemTemplate>
                    <asp:LinkButton ID="btnUpdate" runat="server" Width="30px" Text="�޸�" href='<%# string.Format("AssessTemplateItemUpdate.aspx?ItemID={0}", SecurityUtil.DECEncrypt(Eval("AssessTemplateItemID").ToString())) %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="5%">
                <ItemTemplate>
                    <asp:LinkButton ID="btnDelete" runat="server" Text="ɾ��" CausesValidation="false"
                        CommandArgument='<%# Eval("AssessTemplateItemID") %>' OnClientClick="Confirmed = confirm('ȷ��Ҫɾ����'); return Confirmed;"
                        OnCommand="Delete_Command" ToolTip="ɾ��" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <RowStyle Height="28px" CssClass="GridViewRowLink" />
        <SelectedRowStyle BackColor="#F7F3FF" />
        <PagerTemplate>
<%--            <div class="pages">
                <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton"
                    CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    ��һҳ</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton"
                    CommandArgument="Next" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    ��һҳ</asp:LinkButton>
            </div>--%>
    <uc1:PageTemplate ID="PageTemplate1" runat="server" />            
        </PagerTemplate>
    </asp:GridView>

</div>
