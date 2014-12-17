<%@ Control Language="C#" AutoEventWireup="true" Codebehind="FeedBackBackSearchView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.Train.FeedBackBackSearchView" %>
<%@ Register Src="FeedBackListView.ascx" TagName="FeedBackListView" TagPrefix="uc1" %>
<div class="leftitbor">
    <span class="font14b">共查到 </span>
    <asp:Label ID="LblMessage" runat="server" CssClass="fontred"></asp:Label>
    <span class="font14b">条记录</span>
</div>
<div class="leftitbor2">
    <asp:Label ID="lbOperationType" runat="server"></asp:Label></div>
<div class="edittable" id="tbLeaveRequest" runat="server">
    <table width="100%" border="0">
        <tr>
            <td align="left" style="width: 2%;">
            </td>
            <td align="left" style="width: 8%;">
                培训课程</td>
            <td align="left" style="width: 41%">
                <asp:TextBox ID="txtCourse" runat="server" Width="65%" CssClass="input1"></asp:TextBox>
            </td>
            <td align="left" style="width: 8%;">
                反馈人</td>
            <td align="left" style="width: 41%">
                <asp:TextBox ID="tbName" runat="server" Width="40%" CssClass="input1"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 2%;">
            </td>
            <td align="left" style="width: 8%;">
                反馈时间
            </td>
            <td align="left" style="width: 41%">
                <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="tbStartFrom"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
                <ajaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="tbStartTo"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
                <asp:TextBox ID="tbStartFrom" runat="server" CssClass="input1" Width="29%"></asp:TextBox>&nbsp;
                <asp:Label ID="Label2" runat="server" Text="--"></asp:Label>&nbsp;
                <asp:TextBox ID="tbStartTo" runat="server" CssClass="input1" Width="30%"></asp:TextBox>
            </td>
            <td align="left" style="width: 8%;">
                反馈状态
            </td>
            <td align="left" style="width: 41%">
                <asp:DropDownList ID="txtFeedBackStatus" runat="server" Width="40%">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem Value="0">未反馈</asp:ListItem>
                    <asp:ListItem Value="1">已反馈</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
    </table>
</div>
<div class="tablebt">
    <asp:Button ID="BtnSearch" runat="server" Text="查  询" OnClick="BtnSearch_Click" class="inputbt" />
</div>
<div class="nolinetablediv">
    <uc1:FeedBackListView ID="FeedBackListView1" runat="server"></uc1:FeedBackListView>
</div>
