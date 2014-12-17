<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AccountSetParaListView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.PayModuleViews.AccountSetParaListView" %>
<%@ Register Src="../../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<link href="../CSS/style.css" rel="stylesheet" type="text/css" />
<div class="leftitbor">
    <span class="font14b">����ѯ�� </span><span class="fontred">
        <asp:Label ID="LblMessage" runat="server" Text=""></asp:Label></span> <span class="font14b">
            ����¼</span>
</div>
<div class="leftitbor2">
    �������������
</div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td width="2%" align="right">
            </td>
            <td align="left" style="width: 12%">
                ���ײ�������
            </td>
            <td align="left" colspan="3">
                <asp:TextBox runat="server" ID="TxtName" Width="60%" class="input1"></asp:TextBox>&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td align="right" width="2%">
            </td>
            <td align="left">
                Ԥ����������
            </td>
            <td align="left" style="width: 12%">
                <asp:DropDownList ID="ddlFieldAttribute" runat="server" Width="100%">
                </asp:DropDownList>
            </td>
            <td align="left" style="width: 10%">
                ����
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlBindItem" runat="server" Width="38%">
                </asp:DropDownList>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right" width="2%">
            </td>
            <td align="left">
                Ԥ��β������
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlMantissaRound" runat="server" Width="100%">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
</div>
<div class="tablebt">
    <asp:Button ID="BtnSearch" runat="server" Text="��  ѯ" OnClick="BtnSearch_Click" class="inputbt" />
    <asp:Button ID="btnAdd" runat="server" CssClass="inputbt" OnClick="btnAdd_Click"
        Text="��  ��" /></div>
<div id="Result" runat="server" class="linetable">
    <asp:GridView GridLines="None" Width="100%" ID="GridView1" runat="server" AutoGenerateColumns="False"
        AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand"
        OnRowDataBound="GridView1_RowDataBound" PageSize="20">
        <HeaderStyle Height="28px" CssClass="headerstyleblue" />
        <RowStyle Height="28px" CssClass="GridViewRowLink" />
        <AlternatingRowStyle CssClass="table_g" />
        <Columns>
            <asp:TemplateField HeaderStyle-Width="2%">
                <ItemTemplate>
                    <asp:LinkButton ID="btnHiddenPostButton" runat="server" CommandArgument='<%# Eval("AccountSetParaID") %>'
                        CommandName="HiddenPostButtonCommand"></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle Width="2%" />
            </asp:TemplateField>
            <%--<asp:BoundField HeaderText="���ײ������ " DataField="AccountSetParaID" HeaderStyle-Width="10%"
                            ItemStyle-Width="10%" />--%>
            <asp:BoundField HeaderText="���ײ�������" DataField="AccountSetParaName" ItemStyle-Width="26%" />
            <asp:TemplateField HeaderText="Ԥ����������">
                <ItemTemplate>
                    <%# Eval("FieldAttribute.Name") %>
                </ItemTemplate>
                <ItemStyle Width="13%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="����">
                <ItemTemplate>
                    <%# Eval("BindItem.Name") %>
                </ItemTemplate>
                <ItemStyle Width="13%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ԥ��β������">
                <ItemTemplate>
                    <%# Eval("MantissaRound.Name") %>
                </ItemTemplate>
                <ItemStyle Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="��Ա���ɼ�">
                <ItemTemplate>
                    <%# Convert.ToBoolean(Eval("IsVisibleToEmployee").ToString())?"��" :"��"%>
                </ItemTemplate>
                <ItemStyle Width="8%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ϊ0ʱ��ʾ">
                <ItemTemplate>
                    <%# Convert.ToBoolean(Eval("IsVisibleWhenZero").ToString())?"��" :"��"%>
                </ItemTemplate>
                <ItemStyle Width="8%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton runat="server" ID="lbModify" OnCommand="lbModify_Click" CommandArgument='<%# Eval("AccountSetParaID") %>'>�޸�</asp:LinkButton>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="5%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton runat="server" ID="lbDelete" OnCommand="lbDelete_Click" CommandArgument='<%# Eval("AccountSetParaID") %>'>ɾ��</asp:LinkButton>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="5%" />
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
