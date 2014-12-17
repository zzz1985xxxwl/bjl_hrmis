<%@ Control Language="C#" AutoEventWireup="true" Codebehind="SkillListView.ascx.cs"
    Inherits="SEP.Performance.Views.Skill.SkillListView" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<div width="98%" class="leftitbor">
    <span class="font14b">共查到 </span>
    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="fontred"></asp:Label>
    <span class="font14b">条记录</span>&nbsp;&nbsp;
    <asp:Label ID="lblErrorMsg" runat="server" Text="" CssClass="font14b" />
</div>
<div class="leftitbor2">
    设置技能
</div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td align="left" style="width: 2%;">
            </td>
            <td align="left" style="width: 8%;">
                技能名称</td>
            <td align="left" style="width: 41%">
                <asp:TextBox ID="txtName" runat="server" Width="40%" CssClass="input1"></asp:TextBox>
            </td>
            <td align="left" style="width: 8%;">
                技能类型</td>
            <td align="left" style="width: 41%">
                <asp:DropDownList ID="listSkillTypes" runat="server" Width="40%">
                </asp:DropDownList>
            </td>
            <%--<td align="left" style="width: 2%">
              </td>
          <td align="left" style="width: 8%">
              技能名称</td>
          <td align="left" style="width: 21%">
          <asp:TextBox ID="txtName" runat="server" Width="60%" CssClass="input1"></asp:TextBox></td>
         <td align="left" style="width: 8%">
              技能类型</td>
          <td align="left" style="width: 61%" >
          <asp:DropDownList ID="listSkillTypes"  runat="server" Width="30%"></asp:DropDownList>
          </td>              --%>
        </tr>
    </table>
</div>
<div class="tablebt">
    <asp:Button ID="btnSearch" runat="server" Text="查　询" OnClick="btnSearch_Click" CssClass="inputbt" />
    <asp:Button ID="btnAdd" runat="server" Text="新  增" OnClick="btnAdd_Click" CssClass="inputbt" />
</div>
<div id="tbSkill" runat="server" class="linetablediv">
    <asp:GridView GridLines="None" Width="100%" ID="gvSkill" runat="server" AutoGenerateColumns="False"
        AllowPaging="True" OnPageIndexChanging="gvSkill_PageIndexChanging" OnRowCommand="gvSkill_RowCommand"
        OnRowDataBound="gvSkill_RowDataBound">
        <HeaderStyle Height="28px" CssClass="headerstyleblue" />
        <RowStyle Height="28px" CssClass="GridViewRowLink" />
        <AlternatingRowStyle CssClass="table_g" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnHiddenPostButton" CommandArgument='<%# Eval("SkillID") %>'
                        CommandName="HiddenPostButtonCommand" runat="server" Text="" Style="display: none;" /></ItemTemplate>
                <ItemStyle Width="2%" />
            </asp:TemplateField>
            <%--<asp:TemplateField HeaderText="编号">
                        <ItemTemplate> 
                            <%#Eval("SkillID")%>
                        </ItemTemplate>
                            <ItemStyle Width="20%" />
                    </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="技能名称">
                <ItemTemplate>
                    <%#Eval("SkillName")%>
                </ItemTemplate>
                <ItemStyle Width="20%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="技能类型">
                <ItemTemplate>
                    <%#Eval("SkillType.Name")%>
                </ItemTemplate>
                <ItemStyle Width="20%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnModify" Text="修改" OnCommand="btnModify_Click" runat="server"
                        CommandArgument='<%# Eval("SkillID")%>' />
                </ItemTemplate>
                <ItemStyle Width="20%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnDelete" Text="删除" OnClientClick="Confirmed = confirm('确定要删除吗？'); return Confirmed;"
                        OnCommand="btnDelete_Click" runat="server" CommandArgument='<%# Eval("SkillID")%>' />
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
    <uc1:PageTemplate ID="PageTemplate1" runat="server" />            
        </PagerTemplate>
    </asp:GridView>

</div>
