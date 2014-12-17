<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeDatagridListView.ascx.cs"
    Inherits="SEP.Performance.Views.SEP.Employees.EmployeeDatagridListView" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<div class="leftitbor">
    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="font14b"></asp:Label>
</div>
<div class="leftitbor2">
    ��ѯ�û�<asp:HiddenField ID="hfProjectID" runat="server" />
</div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td width="1%" align="right">
            </td>
            <td width="6%" align="left">
                Ա������
            </td>
            <td width="20%" align="left">
                <asp:TextBox ID="txtName" runat="server" CssClass="input1"></asp:TextBox>
            </td>
            <td width="6%" align="left">
                ְϵ
            </td>
            <td width="20%" align="left">
                <asp:DropDownList ID="ddlGrades" runat="server" Width="160px" Height="24px">
                </asp:DropDownList>
            </td>
            <td width="6%" align="left">
                ����
            </td>
            <td width="20%" align="left">
                <asp:DropDownList ID="ddlDepartment" runat="server" Width="160px" Height="24px">
                </asp:DropDownList>
                <asp:CheckBox ID="cbRecursionDepartment" Checked="true" runat="server" Text="�����Ӳ���" />
            </td>
        </tr>
        <tr>
            <td align="right">
            </td>
            <td  align="left">
                ְλ
            </td>
            <td  align="left">
                <asp:DropDownList ID="ddlPosition" runat="server" Width="160px" Height="24px">
                </asp:DropDownList>
            </td>
            <td  align="left">
                ��Ч��
            </td>
            <td  align="left">
                <asp:DropDownList ID="ddlValidate" runat="server" Width="160px" Height="24px">
                    <asp:ListItem Text="" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="��Ч" Value="0"></asp:ListItem>
                    <asp:ListItem Text="��Ч" Value="1" Selected="True"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td></td><td></td>
        </tr>
    </table>
</div>
<div class="tablebt">
    <asp:Button ID="btnSearch" runat="server" Text="�顡ѯ" OnClick="btnSearch_Click" CssClass="inputbt" />
    <asp:Button ID="btnAdd" runat="server" Text="�¡���" OnClick="Add_Command" CssClass="inputbt" />
</div>
<div id="tbEmployeeGridView" runat="server" class="linetablediv">
    <asp:GridView GridLines="None" Width="100%" ID="grvEmployee" runat="server" AutoGenerateColumns="False"
        AllowPaging="True" OnPageIndexChanging="grvEmployee_PageIndexChanging" PageSize="15"
        OnRowCommand="grvEmployee_RowCommand" OnRowDataBound="grvEmployee_RowDataBound">
        <RowStyle Height="28px" CssClass="GridViewRowLink" />
        <AlternatingRowStyle CssClass="table_g" />
        <HeaderStyle Height="28px" CssClass="headerstyleblue" />
        <Columns>
            <asp:TemplateField HeaderStyle-Width="2%">
                <ItemTemplate>
                    <asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("Id") %>' CommandName="HiddenPostButtonCommand"
                        runat="server" Text="" Style="display: none;" /></ItemTemplate>
                <ItemStyle Width="2%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="����" HeaderStyle-Width="6%">
                <ItemTemplate>
                    <%# Eval("Id")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ա������" HeaderStyle-Width="8%">
                <ItemTemplate>
                    <%# Eval("Name")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="����" HeaderStyle-Width="20%">
                <ItemTemplate>
                    <%#Eval("Dept.Name")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ְλ" HeaderStyle-Width="15%">
                <ItemTemplate>
                    <%#Eval("Position.Name")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="�ֻ�" HeaderStyle-Width="12%">
                <ItemTemplate>
                    <%#Eval("MobileNum")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Email" HeaderStyle-Width="23%">
                <ItemTemplate>
                    <%#Eval("Email1")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="6%">
                <ItemTemplate>
                    <asp:LinkButton ID="btnUpdate" runat="server" Text="�޸�" CausesValidation="false"
                        CommandArgument='<%# Eval("Id") %>' OnCommand="Update_Command" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="8%">
                <ItemTemplate>
                    <asp:LinkButton ID="btnResetPassword" runat="server" Text="��������" CausesValidation="false"
                        CommandArgument='<%# Eval("LoginName") %>' OnCommand="ResetPassword_Command" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <RowStyle Height="28px" CssClass="GridViewRowLink" />
        <SelectedRowStyle BackColor="#F7F3FF" />
        <PagerTemplate>
            <uc1:PageTemplate ID="PageTemplate1" runat="server" />
            <%--		<div class="pages">
		    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton" CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    ��һҳ</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton" CommandArgument="Next" CommandName="Page"  Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    ��һҳ</asp:LinkButton>
		</div>           --%>
        </PagerTemplate>
    </asp:GridView>
</div>
