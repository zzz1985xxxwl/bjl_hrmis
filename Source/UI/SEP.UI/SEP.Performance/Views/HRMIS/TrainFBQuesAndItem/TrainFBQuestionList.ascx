<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TrainFBQuestionList.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.TrainFBQuesAndItem.TrainFBQuestionList" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<div class="leftitbor">
    <span class="font14b">����ѯ�� </span>
    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="fontred"></asp:Label>
    <span class="font14b">����¼</span>
</div>
<div class="leftitbor2">
    ��ѵ�����������</div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td align="left" style="width: 2%;">
            </td>
            <td align="left" style="width: 8%;">
                ��������
            </td>
            <td align="left" style="width: 41%">
                <asp:TextBox ID="txtFBQuesName" runat="server" CssClass="input1" Width="40%" />
            </td>
            <td align="left" style="width: 8%;">
                ������������
            </td>
            <td align="left" style="width: 41%">
                <asp:DropDownList ID="ddType" runat="server" Width="40%">
                </asp:DropDownList>
            </td>
            <%--<td align="right" style="width: 14%">��������</td>
          <td align="left" style="width: 36%">
          <asp:TextBox ID="txtFBQuesName" runat="server" CssClass="input1" Width="60%"/>
          </td>    
          <td align="right" style="width: 14%">������������</td>
          <td align="left" style="width: 36%">
              <asp:DropDownList ID="ddType" runat="server" Width="60%">
              </asp:DropDownList></td>   --%>
        </tr>
    </table>
</div>
<div class="tablebt">
    <asp:Button ID="Button1" runat="server" Text="��  ѯ" OnClick="btnSearch_Click" class="inputbt" />
    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="��  ��" class="inputbt" />
</div>
<div class="linetable" id="listQuestion" runat="server">
    <asp:GridView GridLines="None" Width="100%" ID="grv" runat="server" AutoGenerateColumns="False"
        AllowPaging="True" BorderStyle="None" OnPageIndexChanging="grv_PageIndexChanging"
        OnRowCommand="grv_RowCommand" OnRowDataBound="grv_RowDataBound">
        <AlternatingRowStyle CssClass="table_g" />
        <HeaderStyle Height="28px" CssClass="headerstyleblue" />
        <RowStyle Height="28px" CssClass="GridViewRowLink" />
        <AlternatingRowStyle CssClass="table_g" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("FBQuestioniD") %>'
                        CommandName="HiddenPostButtonCommand" runat="server" Text="" Style="display: none;" /></ItemTemplate>
                <ItemStyle Width="2%" />
            </asp:TemplateField>
            <%--<asp:BoundField HeaderText="������" DataField="FBQuestioniD" HeaderStyle-Width="10%" />--%>
            <asp:BoundField DataField="Description" HeaderText="��������" HeaderStyle-Width="25%" />
            <asp:TemplateField HeaderText=" ��������" HeaderStyle-Width="15%">
                <ItemTemplate>
                    <%# Eval("TrainFBQuesType.Name")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnUpdate" runat="server" OnCommand="btnUpdate_Click" CommandArgument='<%# Eval("FBQuestioniD") %>'
                        Width="80px" Text="�޸�" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="15%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="false" CommandArgument='<%# Eval("FBQuestioniD") %>'
                        OnClientClick="Confirmed = confirm('ȷ��Ҫɾ����'); return Confirmed;" OnCommand="Delete_Command"
                        Text="ɾ��" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="15%" />
            </asp:TemplateField>
        </Columns>
        <PagerTemplate>
            <%--                        <div class="pages">
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
