<%@ Control Language="C#" AutoEventWireup="true" Codebehind="SmsCenter.ascx.cs" Inherits="SEP.Performance.Views.SEP.Services.SmsCenter" %>
<div class="leftitbor2">
    <asp:Label ID="lblTitle" runat="server" Text="短信服务"></asp:Label></div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td align="left" style="width: 2%">
            </td>
            <td align="left" style="width: 15%;">
                短信服务状态</td>
            <td align="left" colspan="2">
                <asp:Label ID="lblSmsStatus" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left">
            </td>
            <td align="left">
                该状态详情</td>
            <td align="left" colspan="2">
                <asp:Label ID="lblSmsDetails" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</div>
<div class="tablebt">
    <asp:Button Text="重新激活服务" ID="btnReActiveSms" OnClick="btnReActiveSms_Click" runat="server" class="inputbtlong" />
</div>
