<%@ Control Language="C#" AutoEventWireup="true" Codebehind="ReplaceDutyClassView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.AttendanceStatistics.PlanDutyViews.ReplaceDutyClassView" %>
<div id="tbMessage" style="display: none" runat="server" class="leftitbor">
    <asp:Label ID="lblMessage" runat="server" CssClass="fontred"></asp:Label>
</div>
<div class="leftitbor2">
    替换班别
</div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td align="left" style="height: 30px;">
                替换时间范围&nbsp;<span class="redstar">*</span></td>
            <td align="left" style="height: 30px">
                <ajaxToolKit:CalendarExtender ID="CalendarExtender1" Format="yyyy-MM-dd" runat="server"
                    TargetControlID="dtpScopeFrom">
                </ajaxToolKit:CalendarExtender>
                <ajaxToolKit:CalendarExtender ID="CalendarExtender2" Format="yyyy-MM-dd" runat="server"
                    TargetControlID="dtpScopeTo">
                </ajaxToolKit:CalendarExtender>
                <asp:TextBox ID="dtpScopeFrom" runat="server" CssClass="input1"></asp:TextBox>--
                <asp:TextBox ID="dtpScopeTo" runat="server" CssClass="input1"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2" valign="top">
                <div id="divReplaceDutyClassList" runat="server" class="linetablediv">
                    <asp:GridView GridLines="None" Width="100%" ID="gvReplaceDutyClassList" runat="server" AllowPaging="True" PageSize="5"
                        AutoGenerateColumns="false"  OnPageIndexChanging="gvReplaceDutyClassList_PageIndexChanging" OnRowDataBound="gvReplaceDutyClassList_RowDataBound">
                        <HeaderStyle Height="28px" CssClass="headerstyleblue" />
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
                            <asp:TemplateField HeaderText="编号" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbl" runat="server">
<%# Eval("OldDutyClass.DutyClassID").ToString()%>
                                    </asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="0%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="原班别">
                                <ItemTemplate>
                                    <%# Eval("OldDutyClass.DutyClassName")%>
                                </ItemTemplate>
                                <ItemStyle Width="50%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="新班别">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlReplaceDutyClassList" runat="server" Width="100%" AutoPostBack="true"
                                        OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </ItemTemplate>
                                <ItemStyle Width="50%" />
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
            </td>
        </tr>
    </table>
</div>
<div class="tablebt">
    <asp:Button Text="确  定" ID="btnOK" OnClientClick="AbortxmlHttp();" runat="server"
        class="inputbt" OnClick="btnOK_Click" />
    <asp:Button Text="取　消" ID="btnCancel" runat="server" class="inputbt" />
</div>
