<%@ Control Language="C#" AutoEventWireup="true" Codebehind="LeaveRequestItemHistoryView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.LeaveRequests.LeaveRequestItemHistoryView" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
<div id="divLeaveRequestItemHistory" runat="server">
            <div class="linetablediv">
                            <asp:GridView ID="grd" runat="server" AllowPaging="True" AutoGenerateColumns="False" 
                                GridLines="None" OnPageIndexChanging="grd_PageIndexChanging" Width="100%" OnRowDataBound="grd_RowDataBound"
                                OnRowCommand="grd_RowCommand">
                                <HeaderStyle CssClass="headerstyleblue" Height="28px" HorizontalAlign="Center" />
                                <RowStyle Height = "28px" CssClass="GridViewRowLink"/>
                                <AlternatingRowStyle CssClass="table_g" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("LeaveRequestItem.LeaveRequestItemID") %>'
                                                CommandName="HiddenPostButtonCommand" runat="server" Text="" Style="display: none;" />
                                        </ItemTemplate>
                                        <ItemStyle Width="2%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="编号">
                                        <ItemTemplate>
                                            <asp:Label ID="lblType" runat="server" Text='<%# Eval("LeaveRequestItem.LeaveRequestItemID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="4%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="开始时间">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFromDate" runat="server" Text='<%# Eval("LeaveRequestItem.FromDate") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="结束时间">
                                        <ItemTemplate>
                                            <asp:Label ID="lblToDate" runat="server" Text='<%# Eval("LeaveRequestItem.ToDate") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="小时">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCostTime" runat="server" Text='<%# Eval("LeaveRequestItem.CostTime") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="5%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="操作">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRequestStatus" runat="server" Text='<%# Eval("LeaveRequestStatus.Name") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="8%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="操作人">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAccount" runat="server" Text='<%# Eval("Account.Name") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="5%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="操作时间">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOperationTime" runat="server" Text='<%# Eval("OperationTime") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="备注">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRemark" runat="server" Text='<%# Eval("Remark") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="20%" />
                                    </asp:TemplateField>
                                </Columns>
                    <PagerTemplate>
		<%--<div class="pages">
		    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton" CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    上一页</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton" CommandArgument="Next" CommandName="Page"  Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    下一页</asp:LinkButton>
		</div>  --%>      
             <uc1:PageTemplate ID="PageTemplate1" runat="server" />		              
                    </PagerTemplate>
                            </asp:GridView>  

             </div>     
</div>
   </ContentTemplate>
</asp:UpdatePanel>