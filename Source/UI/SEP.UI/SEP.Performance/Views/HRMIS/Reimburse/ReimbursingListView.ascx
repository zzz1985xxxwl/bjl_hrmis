<%@ Import Namespace="SEP.HRMIS.Model" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReimbursingListView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.Reimburse.ReimbursingListView" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<asp:HiddenField ID="hfCount" runat="server" Value="0" />
<div class="leftitbor2">
    <asp:Label ID="lbOperationType" runat="server">我的报销单</asp:Label>
    &nbsp;
    <asp:LinkButton ID="btnAdd" runat="server" OnClick="btnAdd_Command">新增报销单</asp:LinkButton>
</div>
<div id="tbReimburse" runat="server" class="linetablediv">
    <asp:GridView ID="grd" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        GridLines="None" OnPageIndexChanging="grd_PageIndexChanging" Width="100%" OnRowCommand="grd_RowCommand"
        OnRowDataBound="grd_RowDataBound">
        <HeaderStyle CssClass="headerstyleblue" Height="28px" HorizontalAlign="Center" />
        <RowStyle Height="28px" CssClass="GridViewRowLink" />
        <AlternatingRowStyle CssClass="table_g" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("ReimburseID") %>'
                        CommandName="HiddenPostButtonCommand" runat="server" Text="" Style="display: none;" />
                    <asp:HiddenField ID="hfReimburseID" Value='<%# Eval("ReimburseID") %>' runat="server" />
                    <asp:HiddenField ID="hfReimburseCategoriesEnum" Value='<%# Eval("ReimburseCategoriesEnum.Id") %>'
                        runat="server" />
                </ItemTemplate>
                <ItemStyle Width="2%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="申请时间">
                <ItemTemplate>
                    <%#Eval("ApplyDate", "{0:yyyy-MM-dd}")%>
                </ItemTemplate>
                <ItemStyle Width="12%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="报销状态">
                <ItemTemplate>
                    <asp:Label ID="lblStatus" runat="server" Text='<%#Reimburse.GetReimburseStatusNameByReimburseStatus((ReimburseStatusEnum)Eval("ReimburseStatus"))%>'>
                    </asp:Label></a>
                </ItemTemplate>
                <ItemStyle Width="12%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="报销总额">
                <ItemTemplate>
                    <%#Eval("ExchangeSymbol")%><%#Eval("TotalCost")%>
                </ItemTemplate>
                <ItemStyle Width="12%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="报销内容">
                <ItemTemplate>
                    <%#Eval("ReimburseContentShow")%>
                </ItemTemplate>
                <ItemStyle Width="45%" HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnUpdate" runat="server" Enabled="false" Text="编辑" CausesValidation="false"
                        CommandArgument='<%# Eval("ReimburseID") %>' OnCommand="btnUpdate_Command"></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle Width="5%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnDelete" runat="server" Enabled="false" CausesValidation="false"
                        CommandArgument='<%# Eval("ReimburseID") %>' OnCommand="btnDelete_Command" Text="删除"
                        OnClientClick="Confirmed = false; return confirm('确定要移除此报销单吗？');" />
                </ItemTemplate>
                <ItemStyle Width="5%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnPrint" runat="server" Enabled="false" CausesValidation="false"
                        CommandArgument='<%# Eval("ReimburseID") %>' Text="打印" />
                </ItemTemplate>
                <ItemStyle Width="5%" />
            </asp:TemplateField>
            <%--                       <asp:TemplateField>
                           <ItemTemplate>
                               <asp:LinkButton ID="btnCancel" runat="server" Enabled ="false"
                               CausesValidation="false" CommandArgument='<%# Eval("ReimburseID") %>' OnCommand="Cancel_Command"
                               Text="取消" 
                               OnClientClick= "Confirmed = false; return confirm('确定要取消此报销单吗？');"  />  
                            </ItemTemplate>         
                           <ItemStyle Width="5%" />
                       </asp:TemplateField>--%>
        </Columns>
        <PagerTemplate>
            <%--		<div class="pages">
		    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton" CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    上一页</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton" CommandArgument="Next" CommandName="Page"  Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    下一页</asp:LinkButton>
		</div>                 --%>
            <uc1:PageTemplate ID="PageTemplate1" runat="server" />
        </PagerTemplate>
    </asp:GridView>
</div>
