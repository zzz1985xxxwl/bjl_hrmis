<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OutApplicationConfirmListView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.OutApplications.OutApplicationConfirmListView" %>
<%@ Import Namespace="Framework.Common.Encrypt" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<asp:HiddenField ID="hfCount" runat="server" Value="0" />
<div id="tbOutApplication" runat="server" width="100%">
 <div class="leftitbor2">
   ����˵������
    </div>
    <div width="98%" class="linetablediv" cellpadding="0" cellspacing="0">
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
                           <ItemStyle Width="10%" />
                       </asp:TemplateField>
                       <asp:BoundField DataField="FromDate" HeaderText="��ʼʱ��" ItemStyle-Width="15%" />
                       <asp:BoundField DataField="ToDate" HeaderText="����ʱ��" ItemStyle-Width="15%" />
                        <asp:TemplateField HeaderText="�������">
                            <ItemTemplate>
                            <%# Eval("OutType.Name") %>
                            </ItemTemplate>         
                           <ItemStyle Width="7%" />
                       </asp:TemplateField>
                       <asp:BoundField DataField="CostTime" HeaderText="���Сʱ" ItemStyle-Width="8%" />
                       <asp:TemplateField HeaderText="��ϸ��">
                        <ItemTemplate>
                            <table width="100%" border="0" cellspacing="5" cellpadding="0">
                                <%#Eval("OutItemsShow")%>
                            </table>
                        </ItemTemplate>
                        <ItemStyle Width="28%" HorizontalAlign="Left"/>
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
                                <a onclick="Confirmed=false" target="_blank" href="../OutApplicationPages/ConfirmOutApplicationItem.aspx?PKID=<%#SecurityUtil.DECEncrypt(Eval("PKID").ToString())%>">���</a>
                           
                             <%--  <asp:LinkButton ID="btnConfrim" runat="server" Text="���" 
                                CommandArgument='<%# Eval("PKID") %>' 
                              OnCommand="Confrim_Command" ></asp:LinkButton>--%>
                            </ItemTemplate>         
                           <ItemStyle Width="4%" />
                       </asp:TemplateField>
                   </Columns>
                    <PagerTemplate>
<%--		<div class="pages">
		    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton" CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    ��һҳ</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton" CommandArgument="Next" CommandName="Page"  Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    ��һҳ</asp:LinkButton>
		</div>      --%>   
     <uc1:PageTemplate ID="PageTemplate1" runat="server" />		                 
                    </PagerTemplate>
               </asp:GridView>
   
   </div>
</div>