<%@ Import Namespace="SEP.HRMIS.Model" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeTableView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.Employee.EmployeeTableView" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<div runat="server" id="tbEmployeeList" class="linetablediv">
    <asp:GridView GridLines="None" Width="100%" ID="gvEmployee" runat="server" AutoGenerateColumns="false"
        AllowPaging="true" OnPageIndexChanging="gvEmployee_PageIndexChanging" OnRowDataBound="gvEmployee_RowDataBound"
        OnRowCommand="gvEmployee_RowCommand" PageSize="15">
        <HeaderStyle Height="28px" CssClass="headerstyleblue" />
        <RowStyle Height="28px" CssClass="GridViewRowLink" />
        <AlternatingRowStyle CssClass="table_g" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("Account.Id") %>'
                        CommandName="HiddenPostButtonCommand" runat="server" Text="" Style="display: none;" />
                </ItemTemplate>
                <ItemStyle Width="2%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="员工姓名">
                <ItemTemplate>
                    <%#Eval("Account.Name")%>
                </ItemTemplate>
                <ItemStyle Width="8%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="员工类型">
                <ItemTemplate>
                    <%#EmployeeTypeUtility.EmployeeTypeDisplay((EmployeeTypeEnum)Eval("EmployeeType"))%>
                </ItemTemplate>
                <ItemStyle Width="8%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="所属部门">
                <ItemTemplate>
                    <%# Eval("Account.Dept.Name")%>
                </ItemTemplate>
                <ItemStyle Width="17%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="所属公司">
                <ItemTemplate>
                    <%# Eval("EmployeeDetails.Work.Company.Name")%>
                </ItemTemplate>
                <ItemStyle Width="17%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="职位">
                <ItemTemplate>
                    <%# Eval("Account.Position.Name")%>
                </ItemTemplate>
                <ItemStyle Width="11%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="入职时间">
                <ItemTemplate>
                    <%# string.Format("{0:yyyy-MM-dd}", Eval("EmployeeDetails.Work.ComeDate")).Equals("0001-01-01")
            ? string.Empty
                                        : string.Format("{0:yyyy-MM-dd}",Eval("EmployeeDetails.Work.ComeDate"))%>
                </ItemTemplate>
                <ItemStyle Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnUpdate" runat="server" Width="100%" Text="查看历史" CausesValidation="false"
                        CommandArgument='<%# Eval("Account.Id") %>' OnCommand="EmplyeeHistoryCommand"
                        ToolTip="查看历史" />
                </ItemTemplate>
                <ItemStyle Width="9%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnVacation" runat="server" Width="100%" Text="年假管理" CausesValidation="false"
                        CommandArgument='<%# Eval("Account.Id") %>' OnCommand="Vacation_Command" ToolTip="年假管理" />
                </ItemTemplate>
                <ItemStyle Width="9%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnContract" runat="server" Width="100%" Text="合同管理" CausesValidation="false"
                        CommandArgument='<%# Eval("Account.Id") %>' OnCommand="Contract_Command" ToolTip="合同管理" />
                </ItemTemplate>
                <ItemStyle Width="9%" />
            </asp:TemplateField>
        </Columns>
        <PagerTemplate>
            <uc1:PageTemplate ID="PageTemplate1" runat="server" />
        </PagerTemplate>
    </asp:GridView>
</div>
