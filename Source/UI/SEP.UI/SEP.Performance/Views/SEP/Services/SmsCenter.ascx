<%@ Control Language="C#" AutoEventWireup="true" Codebehind="SmsCenter.ascx.cs" Inherits="SEP.Performance.Views.SEP.Services.SmsCenter" %>
<div class="leftitbor2">
    <asp:Label ID="lblTitle" runat="server" Text="���ŷ���"></asp:Label></div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td align="left" style="width: 2%">
            </td>
            <td align="left" style="width: 15%;">
                ���ŷ���״̬</td>
            <td align="left" colspan="2">
                <asp:Label ID="lblSmsStatus" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left">
            </td>
            <td align="left">
                ��״̬����</td>
            <td align="left" colspan="2">
                <asp:Label ID="lblSmsDetails" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</div>
<div class="tablebt">
    <asp:Button Text="���¼������" ID="btnReActiveSms" OnClick="btnReActiveSms_Click" runat="server" class="inputbtlong" />
</div>
