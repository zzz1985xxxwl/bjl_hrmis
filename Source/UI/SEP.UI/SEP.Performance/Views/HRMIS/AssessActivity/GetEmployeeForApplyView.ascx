<%@ Control Language="C#" AutoEventWireup="true" Codebehind="GetEmployeeForApplyView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.AssessActivity.GetEmployeeForApplyView" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<div class="leftitbor">
    <span class="font14b">你可以为 </span>
    <asp:Label ID="lblMessage" runat="server" CssClass="fontred"></asp:Label>
    <span class="font14b">个员工申请绩效考核</span>
</div>
<div id="trEmployee" runat="server" class="leftitbor2">
    发起绩效考核
</div>
<div id="trSearch" runat="server" class="edittable">
    <table width="100%" border="0">
        <tr>
            <td align="left" style="width: 2%;">
            </td>
            <td align="left" style="width: 8%;">
                员工姓名
            </td>
            <td align="left" style="width: 41%">
                <asp:TextBox ID="txtEmployeeName" runat="server" CssClass="input1" Width="40%"></asp:TextBox>
            </td>
            <td align="left" style="width: 8%;">
                职位
            </td>
            <td align="left" style="width: 41%">
                <asp:DropDownList ID="listPossition" runat="server" Width="40%" Height="24px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 2%;">
            </td>
            <td align="left" style="width: 8%;">
                员工类型
            </td>
            <td align="left" style="width: 41%">
                <asp:DropDownList ID="listEmployeeType" runat="server" Width="40%">
                </asp:DropDownList>
            </td>
            <td align="left" style="width: 8%;">
                部门
            </td>
            <td align="left" style="width: 41%">
                <asp:DropDownList ID="listDepartment" runat="server" Width="40%">
                </asp:DropDownList><asp:CheckBox ID="cbRecursionDepartment" Checked="true" runat="server" Text="包括子部门" />
            </td>
        </tr>
    </table>
</div>

<div id="trSearchBtn" runat="server" class="tablebt">
    <asp:Button ID="btnSearch" runat="server" Text="查　询" OnClick="btnSearch_Click" class="inputbt" />
</div>
<div id="tbSearch" runat="server" class="linetablediv">
    <asp:GridView GridLines="None" Width="100%" ID="gvEmployeeForApply" runat="server"
        AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="gvEmployeeForApply_PageIndexChanging"
        OnRowDataBound="gvEmployeeForApply_RowDataBound">
        <HeaderStyle Height="28px" CssClass="headerstyleblue" />
        <RowStyle Height="28px" CssClass="GridViewRowLink" />
        <AlternatingRowStyle CssClass="table_g" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                </ItemTemplate>
                <ItemTemplate>
                    <asp:Button ID="btnHiddenPostButton" CommandName="HiddenPostButtonCommand" runat="server"
                        Text="" Style="display: none;" />
                </ItemTemplate>
                <ItemStyle Width="2%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="员工姓名">
                <ItemTemplate>
                    <%#Eval("Name")%>
                </ItemTemplate>
                <ItemStyle Width="17%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="部  门">
                <ItemTemplate>
                    <%#Eval("Dept.Name")%>
                </ItemTemplate>
                <ItemStyle Width="32%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnApply" runat="server" CommandArgument='<%# Eval("Id")%>' CommandName="Apply"
                        OnCommand="btnApply_Click" Text="申请" />
                </ItemTemplate>
                <ItemStyle Width="16%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                </ItemTemplate>
                <ItemStyle Width="29%" />
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
    <uc1:PageTemplate id="PageTemplate1" runat="server">
    </uc1:PageTemplate>            
        </PagerTemplate>
    </asp:GridView>
</div>
