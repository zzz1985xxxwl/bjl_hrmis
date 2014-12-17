<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PersonalInAndOutView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.AttendanceStatistics.AttendanceInAndOutStatistics.PersonalInAndOutView" %>
<div id="tbMessage" runat="server" class="leftitbor">
    <asp:Label ID="lblMessage" runat="server" CssClass="fontred"></asp:Label>
</div>
<div class="leftitbor2">
    <asp:Label ID="lblOperation" runat="server">  
    </asp:Label>
    &nbsp;
    <asp:HiddenField ID="Operation" runat="server" />
    <asp:HiddenField ID="HfemployeeId" runat="server" />
</div>
                
<div  class="edittable">
  <table width="100%" border="0">
                    <tr>
                        <td align="right" style="width: 2%;">
                        </td>
                        <td align="left" style="width: 10%;" valign="bottom">
                            员工姓名</td>
                        <td align="left" style="width: 5%;">
                            <asp:TextBox runat="server" ID="txtEmoloyeeName" class="input1" Enabled="false"></asp:TextBox>
                            <asp:HiddenField ID="HfrecordId" runat="server" />
                        </td>
                        <td align="left" colspan="2" valign="middle">
                            门禁卡号 &nbsp;
                            <asp:TextBox ID="txtCardNo" runat="server" Enabled="false" class="input1"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 2%;">
                        </td>
                        <td align="left" style="width: 10%;" valign="bottom">
                            状&nbsp;&nbsp;&nbsp;&nbsp;态</td>
                        <td align="left" style="width: 5%;">
                            <asp:DropDownList ID="listStatus" runat="server" Width="160px">
                            </asp:DropDownList></td>
                        <td align="left" colspan="2" valign="middle">
                            原&nbsp;&nbsp;&nbsp;因&nbsp;<span class="redstar">*</span>
                            <asp:TextBox ID="txtReason" runat="server" class="input1"></asp:TextBox>
                            <asp:Label ID="lblReasonMsg" runat="server" Text="" CssClass="psword_f"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 2%;">
                        </td>
                        <td align="left" style="width: 10%;" valign="bottom">
                            时&nbsp;&nbsp;&nbsp;&nbsp;间</td>
                        <td align="left" style="width: 5%;">
                            <asp:TextBox ID="txtIoTime" runat="server" class="input1"></asp:TextBox>
                            <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtIoTime"
                                Format="yyyy-MM-dd">
                            </ajaxToolKit:CalendarExtender>
                        </td>
                        <td align="left" colspan="2" valign="middle">
                            <asp:DropDownList ID="listHour1" runat="server" Width="60px">
                            </asp:DropDownList>&nbsp; &nbsp;时&nbsp;<asp:DropDownList ID="listMinutes1" runat="server"
                                Width="60px">
                            </asp:DropDownList>
                            &nbsp;&nbsp;分&nbsp;
                            <asp:Label ID="lblTimeMessage" runat="server" Text="" CssClass="psword_f"></asp:Label></td>
                    </tr>
                <%--</table>
            </td>
        </tr>--%>
    </table>
</div>
<div class="tablebt">
    <asp:Button Text="确  定" ID="btnOK" OnClick="btnOK_Click" runat="server" class="inputbt" />
    <asp:Button Text="取　消" ID="btnCancel" OnClick="btnCancel_Click" runat="server" class="inputbt" />
</div>
