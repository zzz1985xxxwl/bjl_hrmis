<%@ Control Language="C#" AutoEventWireup="true" Codebehind="CompanyLinkManListView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.CompanyTeleBooks.CompanyLinkManListView" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<div class="leftitbor">
    <span class="font14b">���鵽 </span>
    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="fontred"></asp:Label>
    <span class="font14b">����¼</span>
</div>
<div class="leftitbor2">
    ������ϵ��</div>
<%--  <div class="linetabledivbg" style="text-align:left;">   
          <table width="700" height="56" border="0" cellpadding="0" style="border-collapse:separate;" cellspacing="10">--%>
<div class="edittable">
    <table width="100%" border="0">
        <td align="left" style="width: 2%;">
        </td>
        <td align="left" style="width: 8%;">
            ����
        </td>
        <td align="left" style="width: 41%">
            <asp:TextBox ID="txtName" runat="server" Width="40%" class="input1"></asp:TextBox>
        </td>
        <td align="left" style="width: 8%;">
        </td>
        <td align="left" style="width: 41%">
        </td>
    </table>
</div>
<div class="tablebt">
    <asp:Button ID="btnSearch" runat="server" Text="�顡ѯ" OnClick="btnSearch_Click" CssClass="inputbt" />
    <asp:Button ID="btnAdd" runat="server" Text="��  ��" OnClick="btnAdd_Click" CssClass="inputbt" />
</div>
<div class="marginepx">
    <asp:GridView GridLines="None" Width="100%" ID="gvLeaveRequestType" runat="server"
        AutoGenerateColumns="False" CssClass="linetable" AllowPaging="True" OnPageIndexChanging="gvLeaveRequestType_PageIndexChanging"
        OnRowCommand="gvLeaveRequestType_RowCommand" OnRowDataBound="gvLeaveRequestType_RowDataBound">
        <HeaderStyle Height="28px" CssClass="headerstyleblue" />
        <RowStyle Height="28px" CssClass="GridViewRowLink" />
        <AlternatingRowStyle CssClass="table_g" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnHiddenPostButton" CommandArgument='<%# Eval("Id") %>' CommandName="HiddenPostButtonCommand"
                        runat="server" Text="" Style="display: none;" /></ItemTemplate>
                <ItemStyle Width="2%" />
            </asp:TemplateField>
            <%--<asp:TemplateField HeaderText="���">
                        <ItemTemplate> 
                            <%#Eval("LeaveRequestTypeID")%>
                        </ItemTemplate>
                            <ItemStyle Width="15%" />
                    </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="����">
                <ItemTemplate>
                    <%#Eval("Name")%>
                </ItemTemplate>
                <ItemStyle Width="16%" />
            </asp:TemplateField>
            <%--            <asp:TemplateField HeaderText="�ֻ�">
                <ItemTemplate>
                    <%#Eval("mobile")%>
                </ItemTemplate>
                <ItemStyle Width="16%" />
            </asp:TemplateField>--%>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnModify" Text="�޸�" OnCommand="btnModify_Click" runat="server"
                        CommandArgument='<%# Eval("Id")%>' />
                </ItemTemplate>
                <ItemStyle Width="13%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnDelete" Text="ɾ��" OnCommand="btnDelete_Click" runat="server"
                        CommandArgument='<%# Eval("Id")%>' />
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
