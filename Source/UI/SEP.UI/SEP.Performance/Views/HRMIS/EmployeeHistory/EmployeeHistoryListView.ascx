<%@ Import Namespace="SEP.HRMIS.Model" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="EmployeeHistoryListView.ascx.cs"
    Inherits="SEP.Performance.Views.EmployeeHistory.EmployeeHistoryListView" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<asp:HiddenField ID="hfCount" runat="server" Value="0" />
<div class="leftitbor">
    <span class="font14b">共查到 </span>
    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="fontred"></asp:Label>
    <span class="font14b">条记录</span>
</div>
<div class="leftitbor2">
    <asp:Label ID="lbName" runat="server" Text=""></asp:Label>的历史
</div>
<div id="divEmployeeHistory" runat="server" class="linetablediv">
    <asp:GridView ID="grd" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        GridLines="None" OnPageIndexChanging="grd_PageIndexChanging" Width="100%" OnRowDataBound="grd_RowDataBound"
        OnRowCommand="grd_RowCommand">
        <HeaderStyle CssClass="headerstyleblue" Height="28px" HorizontalAlign="Center" />
        <RowStyle Height="28px" CssClass="GridViewRowLink" />
        <AlternatingRowStyle CssClass="table_g" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("EmployeeHistoryPKID") %>'
                        CommandName="HiddenPostButtonCommand" runat="server" Text="" Style="display: none;" />
                </ItemTemplate>
                <ItemStyle Width="2%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="员工姓名">
                <ItemTemplate>
                    <asp:Label ID="lblEmployeeName" runat="server" Text='<%# Eval("Employee.Account.Name") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="员工类型">
                <ItemTemplate>
                    <%#EmployeeTypeUtility.EmployeeTypeDisplay((EmployeeTypeEnum)Eval("Employee.EmployeeType"))%>
                </ItemTemplate>
                <ItemStyle Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="部门">
                <ItemTemplate>
                    <asp:Label ID="lblDepartmentName" runat="server" Text='<%# Eval("Employee.Account.Dept.Name") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="职位">
                <ItemTemplate>
                    <asp:Label ID="lblPosition" runat="server" Text='<%# Eval("Employee.Account.Position.Name") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="用工类型">
                <ItemTemplate>
                    <asp:Label ID="lblWorkType" runat="server" Text='<%# Eval("Employee.EmployeeDetails.Work.WorkType.Name") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="文化程度">
                <ItemTemplate>
                    <asp:Label ID="lblEducationalBackground" runat="server" Text='<%# Eval("Employee.EmployeeDetails.Education.EducationalBackground.Name") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="10%" />
            </asp:TemplateField>
            <asp:BoundField DataField="OperationTime" HeaderText="操作时间" ItemStyle-Width="15%" />
            <asp:TemplateField HeaderText="操作人">
                <ItemTemplate>
                    <asp:Label ID="lblAccountsName" runat="server" Text='<%# Eval("Operator.Name") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="10%" />
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
