<%@ Control Language="C#" AutoEventWireup="true" Codebehind="DutyClassView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.AttendanceStatistics.PlanDutyViews.DutyClassView" %>
<link href="../../CSS/style.css" rel="stylesheet" type="text/css" />
<div id="tbMessage" runat="server" class="leftitbor">
    <asp:Label ID="lblMessage" runat="server" CssClass="fontred"></asp:Label>
</div>
<div class="leftitbor2">
    <asp:Label ID="lblOperation" runat="server">  
    </asp:Label>
    &nbsp;
    <asp:HiddenField ID="Operation" runat="server" />
                <asp:TextBox ID="txtAllLimit" runat="server" CssClass="input1" Width="50px" Visible="False"></asp:TextBox>
</div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td align="right" style="height: 36px; width: 2%;">
            </td>
            <td align="left" style="height: 36px;" width="200">
                班别名称&nbsp;<span class="redstar">*</span></td>
            <td align="left" colspan="4" style="height: 36px">
                <asp:TextBox runat="server" ID="txtDutyClassName" class="input1" Width="169px"></asp:TextBox>
                <asp:HiddenField ID="dutyClassId" runat="server" />
            </td>
            <td align="left" colspan="6" style="height: 36px">
                <asp:Label ID="lblDutyClassMessage" runat="server" CssClass="psword_f"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="height: 36px; width: 2%;">
            </td>
            <td align="left" style="height: 36px; width: 199px;">
                上午上班范围时间<span class="redstar">*</span>&nbsp;</td>
            <td align="left" style="height: 36px; width: 60px;">
                <asp:DropDownList ID="listHour1" runat="server" Width="60px">
                </asp:DropDownList></td>
            <td align="left" style="height: 36px; width: 1%;">
                时
            </td>
            <td align="left" style="height: 36px; width: 60px;">
                <asp:DropDownList ID="listMinutes1" runat="server" Width="60px">
                </asp:DropDownList></td>
            <td align="left" style="height: 36px; width: 1%;">
                分——
            </td>
            <td align="left" style="height: 36px; width: 60px;"><asp:DropDownList ID="listHour2" runat="server" Width="60px">
            </asp:DropDownList>
            </td><td style="height: 36px">时</td>
            <td align="left" style="height: 36px; width: 4%;"><asp:DropDownList ID="listMinutes2" runat="server" Width="60px">
            </asp:DropDownList></td>
            <td align="left" style="height: 36px; width: 1%;">
                分</td>
            <td align="left" style="height: 36px; width: 4%;">
                </td>
            <td align="left" style="height: 36px; width: 2%;">
                &nbsp;</td>

        </tr>
        <tr>
            <td align="right" style="height: 36px; width: 2%;">
            </td>
            <td align="left" style="height: 36px; width: 199px;">
                上午下班时间&nbsp;<span class="redstar">*</span>&nbsp;</td>
            <td align="left" style="height: 36px;">
                <asp:DropDownList ID="listHour3" runat="server" Width="60px">
                </asp:DropDownList></td>
            <td align="left" style="height: 36px; width: 1%;">
                时
            </td>
            <td align="left" style="height: 36px; width: 60px;">
                <asp:DropDownList ID="listMinutes3" runat="server" Width="61px">
                </asp:DropDownList></td>
            <td align="left" style="height: 36px; width: 1%;">
                分
            </td>
            <td align="left" style="height: 36px; width: 68px;">
                </td>
            <td align="left" style="height: 36px;">
                </td>
            <td align="left" style="height: 36px; width: 1%;">
                &nbsp;</td>
            <td align="left" style="height: 36px; width: 4%;">
                </td>
            <td align="left" style="height: 36px; width: 2%;">
                &nbsp;</td>
            <td align="left" style="height: 36px; width: 3%;">
            </td>
        </tr>
          <tr>
            <td align="right" style="height: 36px; width: 2%;">
            </td>
            <td align="left" style="height: 36px; width: 199px;">
                下午上班时间&nbsp;<span class="redstar">*</span>&nbsp;</td>
            <td align="left" style="height: 36px;">
                <asp:DropDownList ID="listHour4" runat="server" Width="60px">
                </asp:DropDownList></td>
            <td align="left" style="height: 36px; width: 1%;">
                时
            </td>
            <td align="left" style="height: 36px; width: 60px;">
                <asp:DropDownList ID="listMinutes4" runat="server" Width="61px">
                </asp:DropDownList></td>
            <td align="left" style="height: 36px; width: 1%;">
                分
            </td>
            <td align="left" style="height: 36px; width: 8%;" colspan="2">
                下午下班时间 <span class="redstar">*</span>&nbsp;</td>
            <td align="left" style="height: 36px; width: 4%;"><asp:DropDownList ID="listHour5" runat="server" Width="60px">
            </asp:DropDownList></td>
            <td align="left" style="height: 36px; width: 1%;">
                &nbsp;时</td>
            <td align="left" style="height: 36px; width: 4%;"><asp:DropDownList ID="listMinutes5" runat="server" Width="61px">
            </asp:DropDownList></td>
            <td align="left" style="height: 36px; width: 2%;">
                &nbsp;分</td>

        </tr>
        <tr>
            <td align="right" style="height: 36px; width: 2%;">
            </td>
            <td align="left" style="height: 36px; width: 199px;">
                迟到界定</td>
            <td align="right" colspan="2" style="height: 36px">
                上&nbsp;&nbsp;班&nbsp;&nbsp;晚&nbsp;&nbsp;于&nbsp;<span class="redstar">*</span>&nbsp;</td>
            <td align="left" style="height: 36px; width: 60px;">
                <asp:TextBox ID="txtLateLimit" runat="server" Width="50px" CssClass="input1"></asp:TextBox></td>
            <td align="left" style="height: 36px; width: 1%;">
                分
            </td>
            <td align="left" style="height: 36px; width: 8%;" colspan="2">
                记迟到
            </td>
            <td align="left" colspan="5" style="height: 36px">
                <asp:Label ID="lblLateLimitMessage" runat="server" Text="" CssClass="psword_f"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="height: 36px; width: 2%;">
            </td>
            <td align="left" style="height: 36px; width: 199px;">
                早退界定</td>
            <td align="right" colspan="2" style="height: 36px">
                下&nbsp;&nbsp;班&nbsp;&nbsp;早&nbsp;&nbsp;于&nbsp;<span class="redstar">*</span>&nbsp;</td>
            <td align="left" style="height: 36px; width: 60px;">
                <asp:TextBox ID="txtEarlyLeaveLimit" runat="server" Width="50px" CssClass="input1"></asp:TextBox></td>
            <td align="left" style="height: 36px; width: 1%;">
                分
            </td>
            <td align="left" style="height: 36px; width: 8%;" colspan="2">
                记早退
            </td>
            <td align="left" colspan="5" style="height: 36px">
                <asp:Label ID="lblEarlyLeaveLimitMessage" runat="server" CssClass="psword_f"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="height: 36px; width: 2%;">
            </td>
            <td align="left" style="height: 36px; width: 199px;">
                旷工界定</td>
            <td align="right" colspan="2" style="height: 36px">
                上&nbsp;&nbsp;班&nbsp;&nbsp;晚&nbsp;&nbsp;于&nbsp;<span class="redstar">*</span>&nbsp;</td>
            <td align="left" style="height: 36px; width: 60px;">
                <asp:TextBox ID="txtLate" runat="server" Width="50px" CssClass="input1"></asp:TextBox></td>
            <td align="left" style="height: 36px; width: 1%;">
                分
            </td>
            <td align="left" style="height: 36px; width: 8%;" colspan="2">
                记旷工0.5天
            </td>
            <td align="left" colspan="5" style="height: 36px">
                <asp:Label ID="lblLateMessage" runat="server" Text="" CssClass="psword_f"></asp:Label><asp:Label
                    ID="lblWorkTimeMessage" runat="server" CssClass="psword_f"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="height: 36px; width: 2%;">
            </td>
            <td align="right" style="height: 36px; width: 199px;">
            </td>
            <td align="right" colspan="2" style="height: 36px">
                下&nbsp;&nbsp;班&nbsp;&nbsp;早&nbsp;&nbsp;于&nbsp;<span class="redstar">*</span>&nbsp;</td>
            <td align="left" style="height: 36px; width: 60px;">
                <asp:TextBox ID="txtEarly" runat="server" Width="50px" CssClass="input1"></asp:TextBox></td>
            <td align="left" style="height: 36px; width: 1%;">
                分
            </td>
            <td align="left" style="height: 36px; width: 8%;" colspan="2">
                记旷工0.5天
            </td>
            <td align="left" colspan="5" style="height: 36px">
                <asp:Label ID="lblEarlyLeaveMessage" runat="server" CssClass="psword_f"></asp:Label></td>
        </tr>
        <%--</table>
            </td>
        </tr>--%>
    </table>
</div>
<div class="tablebt">
    <asp:Button Text="确  定" ID="btnOK" OnClick="btnOK_Click" runat="server" class="inputbt" />
    <asp:Button Text="取　消" ID="btnCancel" runat="server" class="inputbt" />
</div>
