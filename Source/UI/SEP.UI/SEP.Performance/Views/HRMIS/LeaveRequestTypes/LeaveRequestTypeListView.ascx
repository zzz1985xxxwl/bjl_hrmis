<%@ Control Language="C#" AutoEventWireup="true" Codebehind="LeaveRequestTypeListView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.LeaveRequestTypes.LeaveRequestTypeListView" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<div class="leftitbor">
    <span class="font14b">共查到 </span>
    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="fontred"></asp:Label>
    <span class="font14b">条记录</span>
</div>
<div class="leftitbor2">
    设置请假类型</div>
<div class="edittable">
    <table width="100%" border="0">
        <td align="left" style="width: 2%;">
        </td>
        <td align="left" style="width: 8%;">
            名称
        </td>
        <td align="left" style="width: 41%">
            <asp:TextBox ID="txtName" runat="server" Width="40%" class="input1"></asp:TextBox>
        </td>
        <td align="left" style="width: 8%;">
        </td>
        <td align="left" style="width: 41%">
        </td>
    </table>
</div>
<div class="tablebt">
    <asp:Button ID="btnSearch" runat="server" Text="查　询" OnClick="btnSearch_Click" CssClass="inputbt" />
    <asp:Button ID="btnAdd" runat="server" Text="新  增" OnClick="btnAdd_Click" CssClass="inputbt" />
</div>
<div class="marginepx">
    <asp:GridView GridLines="None" Width="100%" ID="gvLeaveRequestType" runat="server"
        AutoGenerateColumns="False" CssClass="linetable" AllowPaging="True" OnPageIndexChanging="gvLeaveRequestType_PageIndexChanging"
        OnRowCommand="gvLeaveRequestType_RowCommand" OnRowDataBound="gvLeaveRequestType_RowDataBound">
        <HeaderStyle Height="28px" CssClass="headerstyleblue" />
        <RowStyle Height="28px" CssClass="GridViewRowLink" />
        <AlternatingRowStyle CssClass="table_g" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnHiddenPostButton" CommandArgument='<%# Eval("LeaveRequestTypeID") %>'
                        CommandName="HiddenPostButtonCommand" runat="server" Text="" Style="display: none;" /></ItemTemplate>
                <ItemStyle Width="2%" />
            </asp:TemplateField>
            <%--<asp:TemplateField HeaderText="编号">
                        <ItemTemplate> 
                            <%#Eval("LeaveRequestTypeID")%>
                        </ItemTemplate>
                            <ItemStyle Width="15%" />
                    </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="请假类型">
                <ItemTemplate>
                    <%#Eval("Name")%>
                </ItemTemplate>
                <ItemStyle Width="16%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="最小单位">
                <ItemTemplate>
                    <%#Eval("LeastHour")%>
                </ItemTemplate>
                <ItemStyle Width="16%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="是否包含休息日">
                <ItemTemplate>
                    <%# (int)Eval("IncludeRestDay") == 1 ? "是" : "否"%>
                </ItemTemplate>
                <ItemStyle Width="16%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="是否包法定假日">
                <ItemTemplate>
                    <%# (int)Eval("IncludeLegalHoliday") == 1 ? "是" : "否"%>
                </ItemTemplate>
                <ItemStyle Width="16%" />
            </asp:TemplateField>
            
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnModify" Text="修改" OnCommand="btnModify_Click" runat="server"
                        CommandArgument='<%# Eval("LeaveRequestTypeID")%>' />
                </ItemTemplate>
                <ItemStyle Width="13%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnDelete" Text="删除" OnCommand="btnDelete_Click" runat="server"
                        CommandArgument='<%# Eval("LeaveRequestTypeID")%>' />
                </ItemTemplate>
                <ItemStyle Width="13%" />
            </asp:TemplateField>
        </Columns>
        <PagerTemplate>
            <uc1:PageTemplate id="PageTemplate1" runat="server" />    
        </PagerTemplate>
    </asp:GridView>
</div>
