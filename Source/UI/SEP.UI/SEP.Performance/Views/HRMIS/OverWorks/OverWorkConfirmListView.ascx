<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OverWorkConfirmListView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.OverWorks.OverWorkConfirmListView" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<asp:HiddenField ID="hfCount" runat="server" Value="0" />
<div id="tbOverWork" runat="server" >
<div class="leftitbor2">
����˵ļӰ൥
</div> 
<div  class="linetablediv" >
               <asp:GridView ID="grd" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                   GridLines="None" OnPageIndexChanging="grd_PageIndexChanging" Width="100%" OnRowDataBound="grd_RowDataBound" OnRowCommand="grd_RowCommand" >
                   <HeaderStyle CssClass="headerstyleblue" Height="28px" HorizontalAlign="Center" />
                   <RowStyle Height = "28px" CssClass="GridViewRowLink"/>
                   <AlternatingRowStyle CssClass="table_g" />
                   <Columns>
                       <asp:TemplateField>
                          <ItemTemplate> 
                          ��<asp:LinkButton ID="btnHiddenPostButton" CommandArgument='<%# Eval("PKID") %>' CommandName="HiddenPostButtonCommand" runat="server" Text="" style=" display:none;"/> 
                          </ItemTemplate>  
                         <ItemStyle Width="2%" />
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Ա������">
                            <ItemTemplate>
                                <asp:Label ID="lbAccount" runat ="server" Text='<%# Eval("Account.Name") %>'></asp:Label>
                            </ItemTemplate>         
                           <ItemStyle Width="7%" />
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="����">
                            <ItemTemplate>
                                <%# Eval("Account.Dept.Name") %>
                            </ItemTemplate>         
                           <ItemStyle Width="14%" />
                       </asp:TemplateField>
                       <asp:BoundField DataField="FromDate" HeaderText="��ʼʱ��" ItemStyle-Width="15%" />
                       <asp:BoundField DataField="ToDate" HeaderText="����ʱ��" ItemStyle-Width="15%" />
                       <asp:BoundField DataField="CostTime" HeaderText="�Ӱ�Сʱ" ItemStyle-Width="7%" />
                       <asp:TemplateField HeaderText="ʣ�����">
                            <ItemTemplate>
                                <%# Eval("SurplusAdjustRest") %>
                            </ItemTemplate>         
                           <ItemStyle Width="7%" />
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="��ϸ��">
                        <ItemTemplate>
                            <table width="100%" border="0" cellspacing="5" cellpadding="0">
                                <%#Eval("OutItemsShow")%>
                            </table>
                        </ItemTemplate>
                        <ItemStyle Width="18%" HorizontalAlign="Left"/>
                      </asp:TemplateField>
                       <asp:TemplateField>
                           <ItemTemplate>
                               <asp:LinkButton ID="btnApprove" runat="server" Text="��ϸ" 
                                CommandArgument='<%# Eval("PKID") %>' 
                               OnCommand="Detail_Command"></asp:LinkButton>
                            </ItemTemplate>         
                           <ItemStyle Width="4%" />
                       </asp:TemplateField>
                       <asp:TemplateField>
                           <ItemTemplate>
                               <asp:LinkButton ID="btnQuickPass" runat="server" Text="����ͨ��" 
                                CommandArgument='<%# Eval("PKID") %>' 
                              OnCommand="QuickPass_Command" ></asp:LinkButton>
                            </ItemTemplate>         
                           <ItemStyle Width="7%" />
                       </asp:TemplateField>
                       <asp:TemplateField>
                           <ItemTemplate>
                               <asp:LinkButton ID="btnConfirm" runat="server" Text="���" 
                                CommandArgument='<%# Eval("PKID") %>' 
                              OnCommand="Confirm_Command" ></asp:LinkButton>
                            </ItemTemplate>         
                           <ItemStyle Width="4%" />
                       </asp:TemplateField>
                   </Columns>
                    <PagerTemplate>
            <uc1:PageTemplate id="PageTemplate1" runat="server">
    </uc1:PageTemplate>            
<%--		<div class="pages">
		    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton" CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    ��һҳ</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton" CommandArgument="Next" CommandName="Page"  Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    ��һҳ</asp:LinkButton>
		</div>    --%>                      
                    </PagerTemplate>
               </asp:GridView>
</div>
</div>     