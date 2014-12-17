<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FeedBackPaperListView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.Train.FeedBackPaperListView" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<div class="leftitbor">
    <span class="font14b">���鵽 </span>
    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="fontred"></asp:Label>
    <span class="font14b">����¼</span>
</div>
<div class="leftitbor2">
    ���÷����ʾ�</div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td align="left" style="width: 2%;">
            </td>
            <td align="left" style="width: 8%;">
                ����</td>
            <td align="left" style="width: 41%">
                <asp:TextBox ID="txtPaperName" runat="server" CssClass="input1" />
            </td>
            <td align="left" style="width: 8%;">
            </td>
            <td align="left" style="width: 41%">
            </td>
        </tr>
    </table>
</div>
<div class="tablebt">
    <asp:Button ID="Button1" runat="server" Text="��  ѯ" OnClick="btnSearch_Click" class="inputbt" />
    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="��  ��" class="inputbt" />
</div>
<div id="listpaper" runat="server">
    <div class="linetablediv" id="tbPaperList" runat="server">
        <asp:GridView GridLines="None" Width="100%" ID="grvPaperlist" runat="server" AutoGenerateColumns="False"
            AllowPaging="True" OnPageIndexChanging="grvPaperlist_PageIndexChanging" BorderStyle="None"
            OnRowCommand="grvPaperlist_RowCommand" OnRowDataBound="gvPaperlist_RowDataBound">
            <HeaderStyle Height="28px" CssClass="headerstyleblue" />
            <RowStyle Height="28px" CssClass="GridViewRowLink" />
            <AlternatingRowStyle CssClass="table_g" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="btnHiddenPostButton" CommandArgument='<%# Eval("FeedBackPaperId") %>'
                            CommandName="HiddenPostButtonCommand" runat="server" /></ItemTemplate>
                    <ItemStyle Width="2%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="����">
                    <ItemTemplate>
                        <%#Eval("FeedBackPaperName")%>
                    </ItemTemplate>
                    <ItemStyle Width="50%" HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="btnModify" Text="�޸�" OnCommand="btnModify_Command" runat="server"
                            CommandArgument='<%# Eval("FeedBackPaperId")%>' />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="3%" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="btnDelete" Text="ɾ��" runat="server" CausesValidation="false"
                            CommandArgument='<%# Eval("FeedBackPaperId") %>'
                            OnCommand="btnDelete_Command" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="3%" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="tbnCopy" Text="����" OnCommand="tbnCopy_Command"
                            CommandArgument='<%# Eval("FeedBackPaperId") %>'></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="3%" />
                </asp:TemplateField>
            </Columns>
            <PagerTemplate>
 <%--               <div class="pages">
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
</div>