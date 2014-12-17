<%@ Import Namespace="SEP.HRMIS.Model"%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReimburseConfirmHistoryListView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.Reimburse.ReimburseConfirmHistoryListView" %>
<asp:HiddenField ID="hfCount" runat="server" Value="0" />
<div id="tbReimburse" runat="server" >
<div class="leftitbor2">   
  <asp:Label ID="lbOperationType" runat="server" >审核的历史</asp:Label>
</div> 
<div  class="linetablediv" >
 <asp:GridView ID="grd" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                   GridLines="None" OnPageIndexChanging="grd_PageIndexChanging" Width="100%" OnRowCommand="grd_RowCommand" OnRowDataBound="grd_RowDataBound">
                   <HeaderStyle CssClass="headerstyleblue" Height="28px" HorizontalAlign="Center" />
                   <RowStyle Height = "28px" CssClass="GridViewRowLink"/>
                   <AlternatingRowStyle CssClass="table_g" />
                   <Columns>
                       <asp:TemplateField>
                          <ItemTemplate> 
    　　　　　　　　　　　　<asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("ReimburseID") %>' CommandName="HiddenPostButtonCommand" runat="server" Text="" style=" display:none;"/>
                          </ItemTemplate>  
                         <ItemStyle Width="2%" />
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="申请人">
                            <ItemTemplate>
                                <%#Eval("ApplerName")%>
                            </ItemTemplate>         
                           <ItemStyle Width="12%" />
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="申请时间">
                            <ItemTemplate>
                                <%#Eval("ApplyDate", "{0:yyyy-MM-dd}")%>
                            </ItemTemplate>         
                           <ItemStyle Width="12%" />
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="报销状态">
                            <ItemTemplate>
                                <%#Reimburse.GetReimburseStatusNameByReimburseStatus((ReimburseStatusEnum)Eval("ReimburseStatus"))%></a>
                            </ItemTemplate>         
                           <ItemStyle Width="12%" />
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="报销总额">
                            <ItemTemplate>
                                <%#"￥" + Eval("TotalCost")%>
                            </ItemTemplate>         
                           <ItemStyle Width="12%" />
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="报销内容">
                            <ItemTemplate>
                                <%#Eval("ReimburseContentShow")%>
                            </ItemTemplate>         
                           <ItemStyle Width="58%"  HorizontalAlign="Left" />
                       </asp:TemplateField>
                   </Columns>
                    <PagerTemplate>
		<div class="pages">
		    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton" CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    上一页</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton" CommandArgument="Next" CommandName="Page"  Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    下一页</asp:LinkButton>
		</div>                          
                    </PagerTemplate>
               </asp:GridView>
</div>
</div>