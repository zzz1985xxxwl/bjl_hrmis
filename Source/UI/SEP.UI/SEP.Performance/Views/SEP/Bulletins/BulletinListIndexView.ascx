<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BulletinListIndexView.ascx.cs" Inherits="SEP.Performance.Views.SEP.Bulletins.BulletinListIndexView" %>
<div class="linetablediv">
<asp:GridView ID="gvBulletinList" runat="server" Width="100%" AutoGenerateColumns="False"  AllowPaging="True" OnPageIndexChanging="BulletinList_PageIndexChanging" BorderColor="Transparent" BorderStyle="None" GridLines="None" ShowHeader="False" OnRowCommand="gvBulletinList_RowCommand" OnRowDataBound="gvBulletinList_RowDataBound">
 <FooterStyle Height="30px"></FooterStyle>
			<HeaderStyle  Font-Size="12pt" Font-Bold="True" HorizontalAlign="Center" Height="26px" 
			ForeColor="Black" ></HeaderStyle>
			<RowStyle CssClass="style23"  HorizontalAlign="Center" Height="33px"/>
			<SelectedRowStyle BackColor ="#F7F3FF" />
                <Columns>  
                    <asp:TemplateField><ItemTemplate ><asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("BulletinID") %>' CommandName="HiddenPostButtonCommand" runat="server" Text="" style=" display:none;"/></ItemTemplate>
                        <ItemStyle Width="2%" VerticalAlign="Middle" />
                    </asp:TemplateField>                                  
                    <asp:TemplateField>
                    <ItemTemplate ><img src="../../../Pages/Image/icon06.gif" alt="" id="t" runat="server"/></ItemTemplate>
                        <ItemStyle Width="3%" VerticalAlign="Middle" />
                    </asp:TemplateField>   
                    <asp:TemplateField><ItemTemplate ></ItemTemplate>
                        <ItemStyle Width="4%" VerticalAlign="Middle" />
                    </asp:TemplateField>                        
                    <asp:HyperLinkField  HeaderText="标题" DataTextField="Title" >                         
                      <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                     </asp:HyperLinkField>  
                      <asp:TemplateField HeaderText="所属部门">
                                <ItemTemplate>
                                    <%# Eval("Dept.Name") %>
                                </ItemTemplate>
                                <ItemStyle Width="10%" />
                            </asp:TemplateField>                 
                    <asp:TemplateField>
                    <ItemTemplate><span class="fontblue1" style=" vertical-align:middle">发布于</span>
                    </ItemTemplate>
                        <ItemStyle VerticalAlign="Middle"  />
                    </asp:TemplateField>
                    <asp:BoundField DataField="PublishTime" HeaderText="发布日期" >
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="fontgray" Width="38%" />
                    </asp:BoundField>
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
<div class="nolinetablediv">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="66%" style="height: 19px">&nbsp;</td>
        <td width="34%" align="center" style="height: 19px">　　 
        <a href="../BulletinPages/BulletinListForward.aspx" class="pagenextbutton">更多</a></td>
      </tr>
    </table>
</div>