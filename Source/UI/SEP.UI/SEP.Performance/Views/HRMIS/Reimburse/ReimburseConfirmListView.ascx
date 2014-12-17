<%@ Import Namespace="SEP.HRMIS.Model"%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReimburseConfirmListView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.Reimburse.ReimburseConfirmListView" %>
<asp:HiddenField ID="hfCount" runat="server" Value="0" />
<div id="tbReimburse" runat="server" >
<div class="leftitbor2" >
<asp:Label ID="lbOperationType" runat="server" >����˱�����</asp:Label>
</div>
<div class="linetablediv" >
<asp:GridView ID="grd" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                   GridLines="None" OnPageIndexChanging="grd_PageIndexChanging" Width="100%" OnRowCommand="grd_RowCommand" OnRowDataBound="grd_RowDataBound">
                   <HeaderStyle CssClass="headerstyleblue" Height="28px" HorizontalAlign="Center" />
                   <RowStyle Height = "28px" CssClass="GridViewRowLink"/>
                   <AlternatingRowStyle CssClass="table_g" />
                   <Columns>
                       <asp:TemplateField>
                          <ItemTemplate> 
    ������������������������<asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("ReimburseID") %>' CommandName="HiddenPostButtonCommand" runat="server" Text="" style=" display:none;"/>
                            <asp:HiddenField ID="hfReimburseID" Value='<%# Eval("ReimburseID") %>' runat="server" />
                          </ItemTemplate>  
                         <ItemStyle Width="2%" />
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="������">
                            <ItemTemplate>
                                <%#Eval("ApplerName")%>
                            </ItemTemplate>         
                           <ItemStyle Width="12%" />
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="����ʱ��">
                            <ItemTemplate>
                                <%#Eval("ApplyDate", "{0:yyyy-MM-dd}")%>
                            </ItemTemplate>         
                           <ItemStyle Width="12%" />
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="����״̬">
                            <ItemTemplate>
                                <asp:Label ID="lblStatus" runat="server" Text='<%#Reimburse.GetReimburseStatusNameByReimburseStatus((ReimburseStatusEnum)Eval("ReimburseStatus"))%>'>
                                 </asp:Label></a>
                            </ItemTemplate>         
                           <ItemStyle Width="12%" />
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="�����ܶ�">
                            <ItemTemplate>
                                <%#"��" + Eval("TotalCost")%>
                            </ItemTemplate>         
                           <ItemStyle Width="12%" />
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="��������">
                            <ItemTemplate>
                                <%#Eval("ReimburseContentShow")%>
                            </ItemTemplate>         
                           <ItemStyle Width="34%" HorizontalAlign="Left" />
                       </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnQuickPass" runat="server" Text="����ͨ��" CausesValidation="false"
                                                        CommandArgument='<%# Eval("ReimburseID") %>' OnCommand="QuickPass_Command"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle Width="8%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnApprove" runat="server" Text="���" CausesValidation="false"
                                                        CommandArgument='<%# Eval("ReimburseID") %>' OnCommand="Approve_Command"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle Width="4%" />
                                            </asp:TemplateField>
                   </Columns>
                    <PagerTemplate>
		<div class="pages">
		    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton" CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    ��һҳ</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton" CommandArgument="Next" CommandName="Page"  Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    ��һҳ</asp:LinkButton>
		</div>                          
                    </PagerTemplate>
               </asp:GridView>
</div>
</div>