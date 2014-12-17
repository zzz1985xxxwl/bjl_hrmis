<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DutyClassListView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.AttendanceStatistics.PlanDutyViews.DutyClassListView" %>
<%@ Register Src="../../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<div class="leftitbor">
    <span class="font14b">共查到 </span>
    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="fontred"></asp:Label>
    <span class="font14b">条记录</span>
</div>
<div class="leftitbor2">
    设置班别
</div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td align="left" style="width: 2%;">
            </td>
            <td align="left" style="width: 8%;">
                班别名称
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
    <asp:Button ID="btnAdd" runat="server" Text="新  增" OnClick="btnAdd_Click" CssClass="inputbt" />
</div>
<div id="tbDutyClass" runat="server" class="linetable">
    <asp:GridView GridLines="None" Width="100%" ID="gvDutyClass" runat="server" AutoGenerateColumns="False"
        AllowPaging="True" OnPageIndexChanging="gvDutyClass_PageIndexChanging" OnRowCommand="gvDutyClass_RowCommand"
        OnRowDataBound="gvDutyClass_RowDataBound">
        <HeaderStyle Height="28px" CssClass="headerstyleblue" />
        <RowStyle Height="28px" CssClass="GridViewRowLink" />
        <AlternatingRowStyle CssClass="table_g" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnHiddenPostButton" CommandArgument='<%# Eval("DutyClassID") %>'
                        CommandName="HiddenPostButtonCommand" runat="server" Text="" Style="display: none;" /></ItemTemplate>
                <ItemStyle Width="2%" />
            </asp:TemplateField>
            <%--<asp:TemplateField HeaderText="编号">
                        <ItemTemplate> 
                            <%#Eval("DutyClassID")%>
                        </ItemTemplate>
                            <ItemStyle Width="20%" />
                    </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="班别名称">
                <ItemTemplate>
                    <%#Eval("DutyClassName")%>
                </ItemTemplate>
                <ItemStyle Width="34%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnModify" Text="修改" OnCommand="btnModify_Click" runat="server"
                        CommandArgument='<%# Eval("DutyClassID")%>' />
                </ItemTemplate>
                <ItemStyle Width="20%" />
            </asp:TemplateField>
            <%--  <asp:TemplateField>--%>
            <%--                <ItemTemplate>
                        <asp:LinkButton ID="btnDelete" Text="删除" OnCommand="btnDelete_Click" 
                        runat="server" CommandArgument='<%# Eval("ParameterID")%>'/>
                      </ItemTemplate>--%>
            <%--              <ItemStyle Width="20%" />
                    </asp:TemplateField>--%>
        </Columns>
        <PagerTemplate>
            <%--                        <div class="pages">
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
