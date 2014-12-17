<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InAndOutLogListView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.AttendanceStatistics.AttendanceInAndOutStatistics.InAndOutLogListView" %>
<%@ Register Src="../../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<div class="leftitbor">
    <span class="font14b">共查到 </span>
    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="fontred"></asp:Label>
    <span class="font14b">条记录</span>
    <asp:Label ID="lblErrorMessage" runat="server" CssClass="fontred"></asp:Label>
</div>
<div class="leftitbor2">
    打卡信息修改日志
</div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td align="left" width="170px" style="height: 24px">
                员工姓名
            </td>
            <td align="left" width="170px" style="height: 24px">
                <asp:TextBox ID="txtEmployeeName" runat="server" CssClass="input1"></asp:TextBox>
            </td>
            <td align="left" width="150px" style="height: 24px">
                部门
            </td>
            <td align="left" width="170px" style="height: 24px">
                <asp:DropDownList ID="listDepartment" runat="server" Width="160px">
                </asp:DropDownList>
            </td>
            <td align="left" width="170px" style="height: 24px">
                操作人
            </td>
            <td align="left" width="170px" style="height: 24px">
                <asp:TextBox ID="txtOperator" runat="server" CssClass="input1"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="left">
                进出时间范围
            </td>
            <td>
                <asp:TextBox ID="dtpScopeFrom" runat="server" CssClass="input1"></asp:TextBox>
            </td>
            <td>
                &nbsp;&nbsp;---&nbsp;&nbsp;
            </td>
            <td>
                <asp:TextBox ID="dtpScopeTo" runat="server" CssClass="input1"></asp:TextBox>&nbsp;
                <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="dtpScopeFrom"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
                <ajaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="dtpScopeTo"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
                &nbsp;
            </td>
            <td align="left">
                操作时间查询
            </td>
            <td>
                <asp:TextBox ID="txtOperatimeFrom" runat="server" CssClass="input1"></asp:TextBox>
            </td>
            <td width="70px">
                &nbsp;&nbsp;---&nbsp;&nbsp;
            </td>
            <td>
                <asp:TextBox ID="txtOperatimeTo" runat="server" CssClass="input1"></asp:TextBox>
                <asp:Label ID="lblTimeError" runat="server" CssClass="psword_f"></asp:Label>
                <ajaxToolKit:CalendarExtender ID="CalendarExtender3" runat="server" Format="yyyy-MM-dd"
                    TargetControlID="txtOperatimeFrom">
                </ajaxToolKit:CalendarExtender>
                <ajaxToolKit:CalendarExtender ID="CalendarExtender4" runat="server" Format="yyyy-MM-dd"
                    TargetControlID="txtOperatimeTo">
                </ajaxToolKit:CalendarExtender>
            </td>
        </tr>
        <%--</table>
            </td>
        </tr>--%>
    </table>
</div>
<div class="tablebt">
    <asp:Button ID="btnSearch" runat="server" CssClass="inputbt" OnClick="btnSearch_Click"
        Text="查　询" />
</div>
<div id="tbInAndOutLog" runat="server" class="linetable">
    <asp:GridView ID="gvInAndOutLog" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        GridLines="None" Width="100%" OnPageIndexChanging="gvInAndOutLog_PageIndexChanging"
        OnRowDataBound="gvInAndOutLog_RowDataBound">
        <HeaderStyle CssClass="headerstyleblue" Height="28px" HorizontalAlign="Center" />
        <RowStyle Height="28px" CssClass="GridViewRowLink" />
        <AlternatingRowStyle CssClass="table_g" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnHiddenPostButton" CommandArgument='1' CommandName="HiddenPostButtonCommand"
                        runat="server" Text="" Style="display: none;" />
                </ItemTemplate>
                <ItemStyle Width="2%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="员工">
                <ItemTemplate>
                    <%#Eval("EmployeeName")%>
                </ItemTemplate>
                <ItemStyle Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="原状态">
                <ItemTemplate>
                    <asp:Label ID="lblIoStatus" runat="server" Text='<%# Eval("OldIOStatus") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="原时间">
                <ItemTemplate>
                    <%#Eval("OldIOTime", "{0:yyyy-MM-dd H:mm:ss}").Equals("2000-12-31 0:00:00") ? "" : Eval("OldIOTime")%>
                </ItemTemplate>
                <ItemStyle Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="新状态">
                <ItemTemplate>
                    <asp:Label ID="lblNewIoStatus" runat="server" Text='<%# Eval("NewIOStatus") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="5%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="新时间">
                <ItemTemplate>
                    <%#Eval("NewIOTime")%>
                </ItemTemplate>
                <ItemStyle Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="数据来源">
                <ItemTemplate>
                    <asp:Label ID="lblOperateStatus" runat="server" Text='<%# Eval("OperateStatus") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="5%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作人">
                <ItemTemplate>
                    <%#Eval("Operator")%>
                </ItemTemplate>
                <ItemStyle Width="5%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作时间">
                <ItemTemplate>
                    <%#Eval("OperateTime")%>
                </ItemTemplate>
                <ItemStyle Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作原因">
                <ItemTemplate>
                    <%#Eval("OperateReason")%>
                </ItemTemplate>
                <ItemStyle Width="15%" />
            </asp:TemplateField>
        </Columns>
        <PagerTemplate>
            <%--                        <div class="pages">
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
