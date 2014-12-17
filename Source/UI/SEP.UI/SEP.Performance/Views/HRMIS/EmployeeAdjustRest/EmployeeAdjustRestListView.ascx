<%@ Import namespace="SEP.HRMIS.Model"%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeAdjustRestListView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.EmployeeAdjustRest.EmployeeAdjustRestListView" %>
<div class="leftitbor" runat="server" id="divResult">
    <asp:Label ID="lblResult" runat="server" Text="" CssClass="fontred"></asp:Label>
</div>
<div class="leftitbor">
    <span class="font14b">共查到 </span>
    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="fontred"></asp:Label>
    <span class="font14b">条记录</span>
</div>
<div class="leftitbor2">
    查询员工调休
</div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td align="left" style="width: 2%;">
            </td>
            <td align="left" style="width: 8%;">
                员工姓名
            </td>
            <td align="left" style="width: 41%">
                <asp:TextBox ID="txtName" runat="server" CssClass="input1" Width="40%"></asp:TextBox>
            </td>
            <td align="left" style="width: 8%;">
                职位
            </td>
            <td align="left" style="width: 41%">
                <asp:DropDownList ID="listPossition" runat="server" Width="40%" >
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="left">
            </td>
            <td align="left">
                员工类型
            </td>
            <td align="left">
                <asp:DropDownList ID="listEmployeeType" runat="server" Width="40%">
                </asp:DropDownList>
            </td>
            <td align="left">
                部门
            </td>
            <td align="left">
                <asp:DropDownList ID="listDepartment" runat="server" Width="40%">
                </asp:DropDownList><asp:CheckBox ID="cbRecursionDepartment" Checked="true" runat="server" Text="包括子部门" />
            </td>
        </tr>
        <tr>
            <td align="left">
            </td>
            <td align="left">
                员工状态
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlEmployeeStatus" runat="server" Width="40%">
                <asp:ListItem Text="" Value="-1"></asp:ListItem>
                <asp:ListItem Text="在职" Value="0" Selected="True"></asp:ListItem>
                <asp:ListItem Text="离职" Value="1"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td align="left">
            </td>
            <td align="left">
            </td>
        </tr>
    </table>
</div>
<div class="tablebt">
    <asp:Button ID="btnSearch" runat="server" Text="查　询" OnClick="btnSearch_Click" CssClass="inputbt" />
    <asp:Button ID="btnSave" runat="server" Text="保　存" OnClick="btnSave_Click" CssClass="inputbt" />
    <asp:Button ID="btnExport" runat="server" Text="导　出" OnClick="btnExport_Click" CssClass="inputbt" />
</div>
<div id="Result" runat="server" class="linetablediv">
    <asp:GridView GridLines="None" Width="100%" ID="gvEmployeeAdjustRest" runat="server" AutoGenerateColumns="False"
        AllowPaging="True" PageSize="15"
        OnPageIndexChanging="gvEmployeeAdjustRest_PageIndexChanging" 
        OnRowDataBound="gvEmployeeAdjustRest_RowDataBound">
        <HeaderStyle Height="28px" CssClass="headerstyleblue" />
        <RowStyle Height="28px" CssClass="GridViewRowLink" />
        <AlternatingRowStyle CssClass="table_g" />
        <Columns>
            <asp:TemplateField HeaderStyle-Width="2%">
                <ItemTemplate>
                    <asp:LinkButton ID="btnHiddenPostButton" runat="server" CommandArgument='<%# Eval("AdjustRestID") %>'
                        CommandName="HiddenPostButtonCommand"></asp:LinkButton>
                    <asp:HiddenField ID="hfAccountID" runat="server" Value='<%# Eval("Employee.Account.Id") %>'/>
                    <asp:HiddenField ID="hfAdjustRestID" runat="server" Value='<%# Eval("AdjustRestID") %>'/>
                </ItemTemplate>
                <ItemStyle Width="2%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="员工姓名">
                <ItemTemplate>
                    <span style='color:<%# Convert.ToBoolean(Eval("Expired"))?"Gray":"Black"%>'><%# Eval("Employee.Account.Name")%></span>
                </ItemTemplate>
                <ItemStyle Width="8%" />
            </asp:TemplateField>
             <asp:TemplateField HeaderText="调休有效期">
                <ItemTemplate> 
                    <span style='color:<%# Convert.ToBoolean(Eval("Expired"))?"Gray":"Black"%>'><%# Eval("AdjustYear.Year")%></span>
                </ItemTemplate>
                    <ItemStyle Width="8%" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="员工类型">
                <ItemTemplate> 
                    <span style='color:<%# Convert.ToBoolean(Eval("Expired"))?"Gray":"Black"%>'><%#EmployeeTypeUtility.EmployeeTypeDisplay((EmployeeTypeEnum)Eval("Employee.EmployeeType"))%></span>
                </ItemTemplate>
                    <ItemStyle Width="8%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="所属部门">
                <ItemTemplate> 
                   <span style='color:<%# Convert.ToBoolean(Eval("Expired"))?"Gray":"Black"%>'><%# Eval("Employee.Account.Dept.Name")%></span>
                </ItemTemplate>
                    <ItemStyle Width="11%"/>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="职位">
                <ItemTemplate> 
                    <span style='color:<%# Convert.ToBoolean(Eval("Expired"))?"Gray":"Black"%>'><%# Eval("Employee.Account.Position.Name")%></span>
                </ItemTemplate>
                    <ItemStyle Width="11%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="入职时间">
                <ItemTemplate> 
                    <span style='color:<%# Convert.ToBoolean(Eval("Expired"))?"Gray":"Black"%>'><%#string.Format("{0:yyyy-MM-dd}", Eval("Employee.EmployeeDetails.Work.ComeDate"))%></span>
                </ItemTemplate>
                    <ItemStyle Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="剩余调休">
                <ItemTemplate>
                    <asp:TextBox ID="txtSurplusHours" Width="83%" runat="server" Text='<%# Eval("SurplusHours")%>' CssClass="input1"></asp:TextBox>
                    <asp:HiddenField ID="hfOldSurplusHours" runat="server" Value='<%# Eval("SurplusHours")%>'></asp:HiddenField>
                </ItemTemplate>
                <ItemStyle Width="7%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="修改原因">
                <ItemTemplate>
                    <asp:TextBox ID="txtReason" Width="95%" runat="server" CssClass="input1"></asp:TextBox>
                </ItemTemplate>
                <ItemStyle Width="28%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
           <asp:LinkButton ID="lbDetail" runat="server" Text="查看详情" CommandArgument='<%# Eval("Employee.Account.Id") %>' OnCommand="lbDetail_Click"/>
                </ItemTemplate>
                <ItemStyle Width="7%" />
            </asp:TemplateField>
        </Columns>
        <PagerTemplate>
        		<div class="pages">
		    共&nbsp;<%# ((GridView)Container.NamingContainer).PageCount %>&nbsp;页&nbsp;
		    第&nbsp;<%# ((GridView)Container.NamingContainer).PageIndex+1 %>&nbsp;页&nbsp;
		    <asp:LinkButton ID="LinkButtonFirstPage" runat="server" CssClass="pagefirstbutton" CommandArgument="First" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>" OnClientClick="return confirm('翻页后，本页修改信息将丢失，是否要继续？');">
		    首页</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton" CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>" OnClientClick="return confirm('翻页后，本页修改信息将丢失，是否要继续？');">
		    上一页</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton" CommandArgument="Next" CommandName="Page"  Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>" OnClientClick="return confirm('翻页后，本页修改信息将丢失，是否要继续？');">
		    下一页</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonLastPage" runat="server" CssClass="pagelastbutton" CommandArgument="Last" CommandName="Page"  Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>" OnClientClick="return confirm('翻页后，本页修改信息将丢失，是否要继续？');">
		    末页</asp:LinkButton>
		    转到&nbsp;<asp:TextBox ID="txtGoPage" runat="server" CssClass="input1" Width="20px"></asp:TextBox>&nbsp;页
		    <asp:LinkButton ID="LinkButtonGoPage" runat="server" CssClass="pagegobutton" OnClick="LinkButtonGoPage_Click" OnClientClick="return confirm('翻页后，本页修改信息将丢失，是否要继续？');">GO</asp:LinkButton>
		</div>       
<%--            <div class="pages">
                <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton"
                    CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>"
                    OnClientClick="return confirm('翻页后，本页修改信息将丢失，是否要继续？');">
		    上一页</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton"
                    CommandArgument="Next" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>"
                    OnClientClick="return confirm('翻页后，本页修改信息将丢失，是否要继续？');">
		    下一页</asp:LinkButton>
            </div>--%>
        </PagerTemplate>
    </asp:GridView>
</div>
