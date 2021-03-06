<%@ Import namespace="SEP.HRMIS.Model.PayModule"%>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeSalaryHistoryListView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.PayModuleViews.EmployeeSalaryHistoryListView" %>
<%@ Register Src="../../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<div class="leftitbor" >
			<asp:Label ID="lblMessage" runat="server" Text="" CssClass="font14b"></asp:Label>
	   </div>
  
   <div class="leftitbor2" >
            <asp:Label ID="lbEmployeeName" runat="server"></asp:Label>的发薪历史</div>
  
<div id = "tbEmployeeGridView" runat="server" class="linetablediv" >
        <asp:GridView GridLines="None" Width="100%" ID="grv" runat="server" AutoGenerateColumns="False" AllowPaging="True" 
        OnPageIndexChanging="grv_PageIndexChanging" PageSize="10" OnRowDataBound="grv_RowDataBound" >
        <RowStyle Height = "28px" CssClass="GridViewRowLink"/>
        <AlternatingRowStyle CssClass="table_g" />            
        <HeaderStyle Height="28px" CssClass="headerstyleblue"/>
        <Columns>
            <asp:TemplateField HeaderStyle-Width="2%">
                <ItemTemplate>
                <asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("HistoryId") %>' CommandName="HiddenPostButtonCommand" runat="server" Text="" style=" display:none;"/></ItemTemplate> 
                            <ItemStyle Width="2%" />
</asp:TemplateField>          
            <asp:TemplateField HeaderText="历史编号" HeaderStyle-Width="8%">
                <ItemTemplate><%# Eval("HistoryId")%></ItemTemplate> 
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="工资套" HeaderStyle-Width="14%" >
                <ItemTemplate><%#Eval("EmployeeAccountSet.AccountSetName")%></ItemTemplate> 
            </asp:TemplateField>
            <asp:TemplateField HeaderText="发薪时间" HeaderStyle-Width="18%" >
                <ItemTemplate><%#Eval("SalaryDateTime")%></ItemTemplate> 
            </asp:TemplateField>
            <asp:TemplateField HeaderText="状态" HeaderStyle-Width="10%" >
                <ItemTemplate>
                <asp:Label ID="lblEmployeeType" runat="server" Text='<%# EmployeeSalaryStatusEnum.EmployeeSalaryStatusDisplay((EmployeeSalaryStatusEnum)Eval("EmployeeSalaryStatus")) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="备注" HeaderStyle-Width="38%" >
                <ItemTemplate><%#Eval("Description")%></ItemTemplate> 
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="6%">
           <ItemTemplate>
             <asp:LinkButton ID="btnEdit" runat="server" Text="详情" CausesValidation="false"
                    CommandArgument='<%# Eval("HistoryId") %>'  OnCommand="Detail_Command"/>     
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            </Columns>
            <RowStyle Height = "28px" CssClass="GridViewRowLink"/>
            <SelectedRowStyle BackColor="#F7F3FF" />
                    <PagerTemplate>
<%--		<div class="pages">
		    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton" CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    上一页</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton" CommandArgument="Next" CommandName="Page"  Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    下一页</asp:LinkButton>
		</div>   --%>  
            <uc1:PageTemplate ID="PageTemplate1" runat="server" />		                     
                    </PagerTemplate>
        </asp:GridView>
	 </div>
        <div class="tablebt">
            <asp:Button Text="返　回" ID="btnCancel" OnClick="btnCancel_Click" runat="server" class="inputbt" />

        </div>
