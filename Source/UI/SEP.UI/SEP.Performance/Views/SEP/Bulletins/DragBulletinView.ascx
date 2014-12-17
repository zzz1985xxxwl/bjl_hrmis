<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DragBulletinView.ascx.cs" Inherits="SEP.Performance.Views.SEP.Bulletins.DragBulletinView" %>
<div class="nolinetablediv">
<asp:GridView ID="gvBulletinList" runat="server" Width="100%" AutoGenerateColumns="False"  AllowPaging="False" 
OnPageIndexChanging="BulletinList_PageIndexChanging"   ShowHeader="false" GridLines="None"  OnRowCommand="gvBulletinList_RowCommand"
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
                  <%--   <asp:TemplateField HeaderText="所属部门">
                                <ItemTemplate>
                                    <%# Eval("Dept.Name") %>
                                </ItemTemplate>
                                <ItemStyle Width="18%" HorizontalAlign="Left" />
                            </asp:TemplateField> --%>                        
                    <asp:TemplateField>
                    <ItemTemplate><span class="fontblue1" style=" vertical-align:middle;padding-right:6px;"><%# Eval("Dept.Name") %>发布于</span>
                    </ItemTemplate>
                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="right" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="PublishTime" HeaderText="发布日期"  HeaderStyle-HorizontalAlign="Left">
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="fontgray" Width="30%" />
                    </asp:BoundField>
                </Columns>
           
</asp:GridView>
</div>
<div style="text-align:right;padding:8px 40px;">
<a href="#" onclick='window.open("../BulletinPages/BulletinListForward.aspx")' class="pagenextbutton" >
更多</a>
</div>
