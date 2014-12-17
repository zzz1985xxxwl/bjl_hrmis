<%@ Control Language="C#" AutoEventWireup="true" Codebehind="DiyProcessListView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.DiyProcesses.DiyProcessListView" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<div class="leftitbor">
    <span class="font14b">���鵽 </span>
    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="fontred"></asp:Label>
    <span class="font14b">����¼</span>
</div>
<div class="leftitbor2">
    �����Զ�������</div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td align="left" style="width: 2%;">
            </td>
            <td align="left" style="width: 8%;">
                ����</td>
            <td align="left" style="width: 41%">
                <asp:TextBox runat="server" ID="tbName" CssClass="input1" Width="40%"></asp:TextBox>
            </td>
            <td align="left" style="width: 8%;">
                ����</td>
            <td align="left" style="width: 41%">
                <asp:DropDownList ID="ddlType" runat="server" Width="40%">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
</div>
<div class="tablebt">
    <asp:Button ID="btnSearch" runat="server" Text="�顡ѯ" OnClick="btnSearch_Click" CssClass="inputbt" />
    <asp:Button ID="btnAdd" runat="server" Text="��  ��" OnClick="btnAdd_Click" CssClass="inputbt" />
</div>
<div class="marginepx">
    <asp:GridView GridLines="None" Width="100%" ID="gvDiyProcess" runat="server" AutoGenerateColumns="False"
        CssClass="linetable" AllowPaging="True" OnPageIndexChanging="gvDiyProcess_PageIndexChanging"
        OnRowCommand="gvDiyProcess_RowCommand" OnRowDataBound="gvDiyProcess_RowDataBound">
        <HeaderStyle Height="28px" CssClass="headerstyleblue" />
        <RowStyle Height="28px" CssClass="GridViewRowLink" />
        <AlternatingRowStyle CssClass="table_g" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnHiddenPostButton" CommandArgument='<%# Eval("ID") %>' CommandName="HiddenPostButtonCommand"
                        runat="server" Text="" Style="display: none;" /></ItemTemplate>
                <ItemStyle Width="2%" />
            </asp:TemplateField>
            <%--<asp:TemplateField HeaderText="���">
                <ItemTemplate>
                    <%#Eval("ID")%>
                </ItemTemplate>
                <ItemStyle Width="15%" />
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="����">
                <ItemTemplate>
                    <%#Eval("Name")%>
                </ItemTemplate>
                <ItemStyle Width="16%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="����">
                <ItemTemplate>
                    <%#Eval("Type.Name")%>
                </ItemTemplate>
                <ItemStyle Width="16%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnModify" Text="�޸�" OnCommand="btnModify_Click" runat="server"
                        CommandArgument='<%# Eval("ID")%>' />
                </ItemTemplate>
                <ItemStyle Width="13%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnDelete" Text="ɾ��" OnCommand="btnDelete_Click" runat="server"
                        CommandArgument='<%# Eval("ID")%>' />
                </ItemTemplate>
                <ItemStyle Width="13%" />
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
   <uc1:PageTemplate ID="PageTemplate1" runat="server" />            
        </PagerTemplate>
    </asp:GridView>
 
</div>
