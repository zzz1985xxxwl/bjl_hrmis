<%@ Control Language="C#" AutoEventWireup="true" Codebehind="MyLeaveRequestConfirmHistoryListView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.LeaveRequests.MyLeaveRequestConfirmHistoryListView" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<asp:HiddenField ID="hfCount" runat="server" Value="0" />
<div runat="server" id="divDisplaySearchCondition">
<div class="leftitbor2nopadding">
    <table width="100%" border="0">
        <tr>
            <td width="30%" align="left" style="padding-left:45px;line-height:35px;">
                <asp:Label ID="lbOperationType" runat="server">审核请假单历史</asp:Label>
            </td>            
            <td width="8%" align="right">
                员工姓名
            </td>
            <td width="16%" align="right">
                <asp:TextBox ID="txtEmployeeName" runat="server" CssClass="input1" Width="80%"></asp:TextBox></td>
           
            <td width="8%" align="right">
                时间范围
            </td>
            <td width="32%" align="right">
                <asp:TextBox ID="txtDateFrom" runat="server" CssClass="input1" Width="40%"></asp:TextBox>
                <ajaxToolKit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtDateFrom"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
                --
                <asp:TextBox ID="txtDateTo" runat="server" CssClass="input1" Width="40%"></asp:TextBox><asp:Label
                    ID="lblDateMsg" runat="server" CssClass="psword_f"></asp:Label></td>
            <ajaxToolKit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtDateTo"
                Format="yyyy-MM-dd">
            </ajaxToolKit:CalendarExtender>
            <td width="6%">     
                <asp:Button ID="Button1" runat="server" Text="" CssClass="inputbtSearch" OnClick="btnSearch_Click" />
            </td>
        </tr>      
    </table>
</div>
<div id="divLeaveRequest" runat="server">  
  <div  class="linetablediv" >    
                            <asp:GridView ID="grd" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                GridLines="None" OnPageIndexChanging="grd_PageIndexChanging" Width="100%" OnRowCommand="grd_RowCommand"
                                OnRowDataBound="grd_RowDataBound">
                                <HeaderStyle CssClass="headerstyleblue" Height="28px" HorizontalAlign="Center" />
                                <RowStyle Height = "28px" CssClass="GridViewRowLink"/>
                                <AlternatingRowStyle CssClass="table_g" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("PKID") %>' CommandName="HiddenPostButtonCommand"
                                                runat="server" Text="" Style="display: none;" /></ItemTemplate>
                                        <ItemStyle Width="2%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="员工姓名">
                                        <ItemTemplate>
                                            <%# Eval("Account.Name") %>
                                        </ItemTemplate>
                                        <ItemStyle Width="8%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="类  型">
                                        <ItemTemplate>
                                            <asp:Label ID="lblType" runat="server" Text='<%# Eval("LeaveRequestType.Name") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="6%" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="FromDate" HeaderText="开始时间" ItemStyle-Width="14%" />
                                    <asp:BoundField DataField="ToDate" HeaderText="结束时间" ItemStyle-Width="15%" />
                                    <asp:BoundField DataField="CostTime" HeaderText="请假小时" ItemStyle-Width="7%" />
                                    <asp:TemplateField HeaderText="详细项">
                                        <ItemTemplate>
                                            <table width="100%" border="0" cellspacing="5" cellpadding="0">
                                                <%#Eval("LeaveRequestItemsShow")%>
                                            </table>
                                        </ItemTemplate>
                                        <ItemStyle Width="48%" />
                                    </asp:TemplateField>
                                </Columns>
                    <PagerTemplate>
<%--		<div class="pages">
		    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton" CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    上一页</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton" CommandArgument="Next" CommandName="Page"  Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    下一页</asp:LinkButton>
		</div>   --%> 
      <uc1:PageTemplate ID="PageTemplate1" runat="server" />		                      
                    </PagerTemplate>
                            </asp:GridView>

</div > 
</div > 
</div> 