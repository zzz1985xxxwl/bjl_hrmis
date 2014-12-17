<%@ Import Namespace="SEP.HRMIS.Model.Request" %>
<%@ Import Namespace="SEP.HRMIS.Presenter.LeaveRequests" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="MyLeaveRequestListView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.LeaveRequests.MyLeaveRequestListView" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<div class="leftitbor2"> 
<asp:Label ID="lbOperationType" runat="server" >�ҵ���ٵ�</asp:Label>
                        &nbsp;
                        <asp:LinkButton ID="btnAdd" runat="server" OnClick="Add_Command">������ٵ�</asp:LinkButton>
                        <asp:HiddenField ID="hfEmployeeID" runat="server" />
                        <asp:HiddenField ID="hfCount" runat="server" Value="0" />
</div>
<div id="divLeaveRequest" runat="server" class="linetablediv">
     <asp:GridView ID="grd" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                GridLines="None" OnPageIndexChanging="grd_PageIndexChanging" Width="100%" OnRowDataBound="grd_RowDataBound"
                                OnRowCommand="grd_RowCommand">
                                <HeaderStyle CssClass="headerstyleblue" Height="28px" HorizontalAlign="Center" />
                                <RowStyle Height="28px"  CssClass="GridViewRowLink" HorizontalAlign="Left"/>
                                <AlternatingRowStyle CssClass="table_g" />
                                <Columns>
                                      <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("PKID") %>' CommandName="HiddenPostButtonCommand"
                                                runat="server" Text="" Style="display: none;" /></ItemTemplate>
                                        <ItemStyle Width="2%" />
                                    </asp:TemplateField>
                                        <asp:TemplateField HeaderText="����">
                                        <ItemTemplate>
                                            <asp:Label ID="lblType" runat="server" Text='<%# Eval("LeaveRequestType.Name") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="4%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="��ʼʱ��">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFromDate" runat="server" Text='<%# Eval("FromDate") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="14%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="����ʱ��">
                                        <ItemTemplate>
                                            <asp:Label ID="lblToDate" runat="server" Text='<%# Eval("ToDate") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="15%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="���Сʱ">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCostTime" runat="server" Text='<%# Eval("CostTime") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="7%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="��ϸ��">
                                        <ItemTemplate>
                                            <table width="100%" border="0" cellspacing="5" cellpadding="0">
                                                <%#Eval("LeaveRequestItemsShow")%>
                                            </table>
                                        </ItemTemplate>
                                        <ItemStyle Width="36%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnUpdate" runat="server"
                                                CausesValidation="false" CommandArgument='<%# Eval("PKID") %>' OnCommand="Update_Command"
                                                Text="�༭" />
                                        </ItemTemplate>
                                        <ItemStyle Width="4%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnDelete" runat="server" Enabled='<%# Eval("IfEdit").ToString()=="True" %>'
                                                CausesValidation="false" CommandArgument='<%# Eval("PKID") %>' OnCommand="Delete_Command"
                                                Text="ɾ��" />
                                        </ItemTemplate>
                                        <ItemStyle Width="4%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnCancel" runat="server" Enabled='<%# Eval("IfCancel").ToString()=="True" %>'
                                                CausesValidation="false" CommandArgument='<%# Eval("PKID") %>' OnCommand="Cancel_Command"
                                                Text="����ȡ��" />
                                        </ItemTemplate>
                                        <ItemStyle Width="7%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnCancelItem" runat="server" Enabled="true"
                                                CausesValidation="false" CommandArgument='<%# Eval("PKID") %>' OnCommand="CancelItem_Command"
                                                Text="ȡ�����" />
                                        </ItemTemplate>
                                        <ItemStyle Width="7%" />
                                    </asp:TemplateField>
                                </Columns>
                    <PagerTemplate>
<%--		<div class="pages">
		    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton" CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    ��һҳ</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton" CommandArgument="Next" CommandName="Page"  Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    ��һҳ</asp:LinkButton>
		</div>            --%>  
    <uc1:PageTemplate ID="PageTemplate1" runat="server" />		            
                    </PagerTemplate>
                            </asp:GridView>                  

</div>
