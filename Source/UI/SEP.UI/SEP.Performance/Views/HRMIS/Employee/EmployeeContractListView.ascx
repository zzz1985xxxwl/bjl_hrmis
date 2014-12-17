<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeContractListView.ascx.cs" Inherits="SEP.Performance.Views.Employee.EmployeeContractListView" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>

<div id = "tbNoDataMessage" runat = "server" class="leftitbor" >
<asp:Label ID="lblResult" runat="server" Text="" CssClass="font14b"></asp:Label>
</div>

<div id="tbEmployeeName" runat = "server" class="leftitbor2">
<asp:Label ID="lblEmployeeName" runat="server"></asp:Label>
</div>
  
<div id = "tbEmployeeGridView" runat="server" class="linetablediv">
        <asp:GridView GridLines="None" Width="100%" ID="grvcontractlist" runat="server" AutoGenerateColumns="False" AllowPaging="True" 
        OnPageIndexChanging="grvcontractlist_PageIndexChanging" PageSize="10" OnRowCommand="grvcontractlist_RowCommand" OnRowDataBound="grvcontractlist_RowDataBound" >
        <RowStyle Height = "28px" CssClass="GridViewRowLink"/>
        <AlternatingRowStyle CssClass="table_g" />            
        <HeaderStyle Height="28px" CssClass="headerstyleblue"/>
        <Columns>
            <asp:TemplateField HeaderStyle-Width="2%">
                <ItemTemplate><asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("ContractID") %>' CommandName="HiddenPostButtonCommand" runat="server" Text="" style=" display:none;"/></ItemTemplate> 
            </asp:TemplateField>          
            <asp:TemplateField HeaderText="编号">
                <ItemTemplate>
                <%# Eval("ContractID")%>
                </ItemTemplate> 
              <ItemStyle Width="6%" />
            </asp:TemplateField>     
            <asp:TemplateField HeaderText="合同类型" HeaderStyle-Width="16%">
                <ItemTemplate>
                      <%# Eval("ContractType.ContractTypeName")%>
                </ItemTemplate>
            </asp:TemplateField>         
            <asp:TemplateField HeaderText="合同开始时间"  HeaderStyle-Width="14%"><%--DataFormatString="" HtmlEncode="false">--%>
                <ItemTemplate>
                <%#Eval("StartDate", "{0:yyyy-MM-dd}")%>
                </ItemTemplate> 
            </asp:TemplateField>   
         
            <asp:TemplateField HeaderText="合同结束时间" HeaderStyle-Width="14%" ><%--DataFormatString="{0:yyyy/MM/dd}" HtmlEncode="false">--%>
                <ItemTemplate>
                <%#Eval("EndDate", "{0:yyyy-MM-dd}").Equals("2999-12-31") ? "" : Eval("EndDate", "{0:yyyy-MM-dd}")%>
                </ItemTemplate> 
            </asp:TemplateField>          
            <asp:TemplateField HeaderText="备注" HeaderStyle-Width="30%">
                <ItemTemplate>
                      <%# Eval("Remark")%>
                </ItemTemplate>
            </asp:TemplateField>
            
             <asp:TemplateField HeaderStyle-Width="8%">
             <ItemTemplate>
             <asp:LinkButton ID="btnDownLoad" runat="server" Text="合同下载" CausesValidation="false"
                    CommandArgument='<%# Eval("ContractID") %>'  OnCommand="DownLoad_Command"/>     
             </ItemTemplate>
            </asp:TemplateField> 
            
            <asp:TemplateField HeaderStyle-Width="5%">
           <ItemTemplate>
             <asp:LinkButton ID="btnEdit" runat="server" Text="修改" CausesValidation="false"
                    CommandArgument='<%# Eval("ContractID") %>'  OnCommand="Update_Command"/>     
            </ItemTemplate>
        </asp:TemplateField>    
        <asp:TemplateField HeaderStyle-Width="5%">
           <ItemTemplate>
             <asp:LinkButton ID="btnDelete" runat="server"  Text="删除" CausesValidation="false"
                    CommandArgument='<%# Eval("ContractID") %>' 
                    OnCommand="Delete_Command"/>     
            </ItemTemplate>
        </asp:TemplateField>     
            </Columns>
                    <RowStyle Height = "28px" CssClass="GridViewRowLink"/>
            <SelectedRowStyle BackColor="#F7F3FF" />
                    <PagerTemplate>
        <uc1:PageTemplate ID="PageTemplate1" runat="server" />                
<%--	<div class="pages">
		    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton" CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    上一页</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton" CommandArgument="Next" CommandName="Page"  Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    下一页</asp:LinkButton>
		</div>      --%>         
                    </PagerTemplate>
        </asp:GridView>
</div>

<div id = "tbAdd" runat="server" class="tablebt">
    <asp:Button ID="btnAdd" Text="新增合同" runat="server"  CausesValidation="false" OnCommand="Add_Command" ToolTip="Add" CssClass="inputbt" />
    <asp:Button ID="btnCancle" runat="server" Text="取消" CssClass="inputbt" OnClick="btnCancle_Click" />


</div>
