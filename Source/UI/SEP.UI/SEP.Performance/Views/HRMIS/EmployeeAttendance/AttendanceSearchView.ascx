<%@ Control Language="C#" AutoEventWireup="true" Codebehind="AttendanceSearchView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.EmployeeAttendance.AttendanceSearchView" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<div id="tbNoDataMessage" runat="server" class="leftitbor">
    <asp:Label ID="lblResult" runat="server" Text="" CssClass="font14b"></asp:Label>
</div>
<div id="tbEmployeeName" runat="server" class="leftitbor2">
    出勤管理
</div>    
<div  class="edittable">
  <table width="100%" border="0">
        <tr>
            <td width="2%" align="right">
            </td>
            <td width="8%" align="left">
                员工姓名</td>
            <td width="26%" align="left">
                <asp:TextBox ID="txtName" runat="server" CssClass="input1"></asp:TextBox></td>
            <td width="8%" align="left">
                缺勤日期</td>
            <td width="56%" align="left">
                <asp:TextBox ID="txtStartFrom" runat="server" CssClass="input1"></asp:TextBox>
                &nbsp;&nbsp;--&nbsp;&nbsp;<asp:TextBox ID="txtStartTo" runat="server" CssClass="input1"></asp:TextBox>&nbsp;
                 <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtStartFrom"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
                <ajaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtStartTo"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender></td>
        </tr>
        <tr>
            <td width="2%" align="right">
            </td>
            <td width="8%" align="left">
                缺勤类型</td>
            <td align="left" width="26%">
                <asp:DropDownList ID="listType" runat="server" Width="162px">
                </asp:DropDownList></td>
            <td width="8%" align="left">
             职系
            </td>
            <td align="left" style="width: 56%;">
                 <asp:DropDownList ID="ddGrades" runat="server" >
                </asp:DropDownList>
            </td>
        </tr>
    </table>
</div>
<div class="tablebt">
    <asp:Button ID="btnSearch" runat="server" Text="查 询" CssClass="inputbt" OnClick="btnSearch_Click" />
    <asp:Button ID="btnAdd" runat="server" Text="新 增" CssClass="inputbt" OnClick="btnAdd_Click" />
</div>
<div id="tbListView" runat="server" class="linetablediv">
    <asp:GridView GridLines="None" Width="100%" ID="grvAttendanceList" runat="server"
        AutoGenerateColumns="False" AllowPaging="True" PageSize="10" OnPageIndexChanging="grvAttendanceList_PageIndexChanging"
        OnRowDataBound="grvAttendanceList_RowDataBound">
        <RowStyle Height="28px" CssClass="GridViewRowLink" />
        <AlternatingRowStyle CssClass="table_g" />
        <HeaderStyle Height="28px" CssClass="headerstyleblue" />
        <Columns>
            <asp:TemplateField HeaderStyle-Width="2%">
                <ItemTemplate>
                    <asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("AttendanceId") %>'
                        CommandName="HiddenPostButtonCommand" runat="server" Text="" Style="display: none;" />
                </ItemTemplate>
                <ItemStyle Width="2%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="员工姓名" HeaderStyle-Width="22%">
                <ItemTemplate>
                    <%# Eval("EmployeeName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="缺勤类型" HeaderStyle-Width="22%">
                <ItemTemplate>
                    <%# Eval("Name")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="缺勤日期" HeaderStyle-Width="22%">
                <ItemTemplate>
                    <%#Eval("TheDay", "{0:yyyy-MM-dd}")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="时间" HeaderStyle-Width="22%">
                <ItemTemplate>
                    <%#Eval("AffectTime")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="10%" ItemStyle-VerticalAlign="Middle">
                <ItemTemplate>
                    <asp:LinkButton ID="btnDelete" runat="server" Text="删除" CausesValidation="false"
                        CommandArgument='<%# Eval("AttendanceId") %>' OnClientClick="Confirmed = confirm('确定要删除吗？'); return Confirmed;"
                        OnCommand="Delete_Command" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <RowStyle Height="28px" CssClass="GridViewRowLink" />
        <SelectedRowStyle BackColor="#F7F3FF" />
        <PagerTemplate>
<%--            <div class="pages">
                <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton"
                    CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    上一页</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton"
                    CommandArgument="Next" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    下一页</asp:LinkButton>
            </div>--%>
   <uc1:PageTemplate ID="PageTemplate1" runat="server" />            
        </PagerTemplate>
    </asp:GridView>
 
</div>
