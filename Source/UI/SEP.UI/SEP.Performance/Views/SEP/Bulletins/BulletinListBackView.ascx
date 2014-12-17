<%@ Import Namespace="ShiXin.Security" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="BulletinListBackView.ascx.cs"
    Inherits="SEP.Performance.Views.SEP.Bulletins.BulletinListBackView" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<div id="count" runat="server" class="leftitbor">
    <span class="font14b">共有 </span>     
    <span class="fontred"><%Response.Write(BulletinList.Count.ToString());%></span>
     <span class="font14b"> 条记录</span>  
</div>           
  
<div id="ErrorMsg" runat="server" class="leftitbor">         
    <asp:Label ID="lblMessage" runat="server"  CssClass="fontred"></asp:Label>
</div>
<div class="leftitbor2" >查询公告</div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td width="14px" height="36" align="left">
            </td>
            <td width="28" height="36" align="left">
                标&nbsp;题</td>
            <td align="left" style="width: 170px">
                <asp:TextBox ID="txtTitle" CssClass="input1" runat="server"></asp:TextBox></td>
           <td width="60"   align="left">所属部门</td>
            <td align="left" >
                  <asp:DropDownList ID="listDepartment" runat="server">
              </asp:DropDownList>
              </td>
            <td width="75px" align="left">
                公告发布日期</td>
            <td align="left" style="width: 312">
                <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtPublishStartTime"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
                <ajaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtPublishEndTime"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
                <asp:TextBox ID="txtPublishStartTime" size="17" runat="server" CssClass="input1"></asp:TextBox>
                ---<asp:TextBox ID="txtPublishEndTime" runat="server" CssClass="input1" size="17"></asp:TextBox>
            </td>
              
        </tr>
    </table>
</div>
<div class="tablebt">
     <asp:Button ID="btnSearch" runat="server" CssClass="inputbt" Text="查 询" OnClick="btnSearch_Click" /></div>
<div class="linetablediv" id="Result" runat="server">
    <asp:GridView ID="gvBulletinList" Width="100%" runat="server" AutoGenerateColumns="False"
                        AllowPaging="True" OnPageIndexChanging="BulletinList_PageIndexChanging" BorderStyle="None"
                        GridLines="None" OnRowCommand="gvBulletinList_RowCommand" OnRowDataBound="gvBulletinList_RowDataBound">
                        <HeaderStyle Height="28px" CssClass="headerstyleblue" />
                        <RowStyle Height = "28px" CssClass="GridViewRowLink"/>
                        <AlternatingRowStyle CssClass="table_g" />
                        <Columns>
                            <asp:TemplateField >
                                <ItemTemplate>
                                    <asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("BulletinID") %>'
                                        CommandName="HiddenPostButtonCommand" runat="server" Text="" Style="display: none;" /></ItemTemplate>
                                <ItemStyle Width="2%" />
                            </asp:TemplateField>
                            <asp:HyperLinkField HeaderText="标题" DataTextField="Title">
                                <ItemStyle HorizontalAlign="Left" Width="40%" Wrap="True" />
                            </asp:HyperLinkField>
                              <asp:TemplateField HeaderText="所属部门">
                                <ItemTemplate>
                                    <%# Eval("Dept.Name") %>
                                </ItemTemplate>
                                <ItemStyle Width="17%" />
                            </asp:TemplateField>
                            
                            <asp:BoundField DataField="PublishTime" HeaderText="发布日期">
                                <ControlStyle Width="5%" />
                                <ItemStyle Width="15%" />
                            </asp:BoundField>
                            <asp:TemplateField >
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnSendMail" runat="server" Text="发送邮件" href='<%# string.Format("BulletinSendMail.aspx?BulletinID={0}", SecurityUtil.DECEncrypt(Eval("BulletinID").ToString())) %>' />
                                </ItemTemplate>
                                <ItemStyle Width="10%" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnUpdate" runat="server" Text="修改" href='<%# string.Format("BulletinUpdate.aspx?BulletinID={0}", SecurityUtil.DECEncrypt(Eval("BulletinID").ToString())) %>' />
                                </ItemTemplate>
                                <ItemStyle Width="8%" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnDelete" runat="server" Text="删除" CausesValidation="false"
                                        CommandArgument='<%# Eval("BulletinID") %>' OnClientClick="Confirmed = confirm('确定要删除吗？'); return Confirmed;"
                                        OnCommand="Delete_Command" ToolTip="Delete" />
                                </ItemTemplate>
                                <ItemStyle Width="8%" />
                            </asp:TemplateField>
                        </Columns>
                <PagerTemplate>
<%--	<div class="pages">
	    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton" CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
	    上一页</asp:LinkButton>
	    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton" CommandArgument="Next" CommandName="Page"  Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
	    下一页</asp:LinkButton>
	</div>     --%>   
<uc1:PageTemplate ID="PageTemplate1" runat="server" />	                  
                </PagerTemplate>
                    </asp:GridView>
                </div>
<br />

