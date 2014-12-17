<%@ Control Language="C#" AutoEventWireup="true" Codebehind="SetReadDataRuleView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.AttendanceStatistics.ReadDataInfo.SetReadDataRuleView" %>
<div id="tbMessage" runat="server" class="leftitbor">
    <asp:Label ID="lblMessage" runat="server" CssClass="fontred14"></asp:Label>
</div>
<div class="leftitbor2">
    设置每日读取考勤时间
</div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td align="center">
                <table width="100%" height="56" border="0" cellpadding="0" style="border-collapse:separate;" cellspacing="10">
                    <tr>
                        <td align="right" style="width: 2%;">
                        </td>
                        <td align="left" style="width: 30%;">
                            自动读取时间</td>
                        <td align="left" style="width: 5%;">
                            <asp:DropDownList ID="listHour1" runat="server" Width="60px">
                            </asp:DropDownList></td>
                        <td align="left" style="width: 4%;">
                            时
                        </td>
                        <td align="left" style="width: 6%;">
                            <asp:DropDownList ID="listMinutes1" runat="server" Width="60px">
                            </asp:DropDownList></td>
                        <td align="left" style="width: 4%;">
                            分
                        </td>
                        <td align="left" colspan="6">
                            <asp:CheckBox ID="checkMail" runat="server" Text="是否发Email" /></td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 2%;">
                        </td>
                        <td align="left" style="width: 30%;">
                            发Email条件</td>
                        <td align="left" colspan="10">
                            <asp:DropDownList ID="listSendMailRule" runat="server" Width="295px">
                            </asp:DropDownList>
                            <asp:HiddenField ID="SetId" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</div>
<div class="tablebt">
    <asp:Button Text="确  定" ID="btnOK" OnClick="btnOK_Click" runat="server" class="inputbt" />
    <asp:Button Text="取  消" ID="btnCancel" OnClick="btnCancel_Click" runat="server" class="inputbt" />
</div>
