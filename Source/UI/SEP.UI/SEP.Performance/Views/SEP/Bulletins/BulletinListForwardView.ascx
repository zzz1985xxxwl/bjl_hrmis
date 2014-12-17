<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BulletinListForwardView.ascx.cs" Inherits="SEP.Performance.Views.SEP.Bulletins.BulletinListForwardView" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>

<div class="leftitbor">
	    <span class="font14b">共有 </span>     
        <span class="fontred"><asp:Label ID="lblCurrentCount" runat="server" ></asp:Label></span>
        <span class="font14b"> 条公告</span>		  
 </div>
<div class="nolinetablediv">
<asp:GridView ID="gvBulletinList" runat="server" Width="100%" AutoGenerateColumns="False"  AllowPaging="True" 
OnPageIndexChanging="BulletinList_PageIndexChanging"  class="linetable" GridLines="None"  OnRowCommand="gvBulletinList_RowCommand"
 OnRowDataBound="gvBulletinList_RowDataBound">
<HeaderStyle Height="28px" CssClass="headerstyleblue"/>
<RowStyle Height = "28px" CssClass="GridViewRowLink"/>
<AlternatingRowStyle CssClass="table_g" />
                <Columns>  
                    <asp:TemplateField><ItemTemplate ><asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("BulletinID") %>' CommandName="HiddenPostButtonCommand" runat="server" Text="" style=" display:none;"/></ItemTemplate>
                        <ItemStyle Width="2%" VerticalAlign="Middle" />
                    </asp:TemplateField>                                  
                    <asp:TemplateField>
                    <ItemTemplate ><img src="../../../Pages/Image/icon06.gif" alt="" id="t" runat="server"/></ItemTemplate>
                        <ItemStyle Width="3%" VerticalAlign="Middle" />
                    </asp:TemplateField>   
                    <asp:TemplateField><ItemTemplate ></ItemTemplate>
                        <ItemStyle Width="3%" VerticalAlign="Middle" />
                    </asp:TemplateField>                        
                    <asp:HyperLinkField  HeaderText="标题" DataTextField="Title" >                         
                      <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <HeaderStyle HorizontalAlign="Left" />
                     </asp:HyperLinkField>
                      
               <%--       <asp:TemplateField HeaderText="所属部门">
                                <ItemTemplate>
                                    <%# Eval("Dept.Name") %>
                                </ItemTemplate>
                                <ItemStyle Width="18%"  />
                            </asp:TemplateField>--%>
                                              
                    <asp:TemplateField>
                    <ItemTemplate><span class="fontblue1" style=" vertical-align:middle;padding-right:6px;"> <%# Eval("Dept.Name") %>发布于</span>
                    </ItemTemplate>
                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="right"/>
                    </asp:TemplateField>
                    <asp:BoundField DataField="PublishTime" HeaderText="发布日期"  HeaderStyle-HorizontalAlign="Left">
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="fontgray" Width="30%" />
                    </asp:BoundField>
                </Columns>
                    <PagerTemplate>
     <uc1:PageTemplate ID="PageTemplate1" runat="server" />                   
<%--		<div class="pages">
		    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton" CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    上一页</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton" CommandArgument="Next" CommandName="Page"  Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    下一页</asp:LinkButton>
		</div>         --%>                 
                    </PagerTemplate>
           
</asp:GridView>

   </div>
