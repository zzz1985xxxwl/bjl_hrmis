<%@ Control Language="C#" AutoEventWireup="true" Codebehind="DayAttendanceView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.AttendanceStatistics.AttendanceStatistcsView.DayAttendanceView" %>
<%@ Register Src="DayAttendanceWeekView.ascx" TagName="DayAttendanceWeekView" TagPrefix="uc1" %>
<link href="../CSS/style.css" rel="stylesheet" type="text/css" />
<div class="leftitbor">
    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="font14b"></asp:Label>
</div>
<div class="leftitbor2">
    日考勤明细</div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td align="left" style="width: 2%;">
                </td>
            <td align="left" style="width: 8%;">
                员工姓名</td>
            <td align="left" style="width: 25%">
                <asp:TextBox ID="txtName" runat="server" CssClass="input1" Width="40%"></asp:TextBox>
            </td>
            <td align="left" style="width: 8%;">
                部门</td>
            <td align="left" style="width: 25%">
                <asp:DropDownList ID="listDepartment" runat="server" Width="40%" Height="24px">
                </asp:DropDownList>
            </td>
             <td align="left" style="width: 8%;">
                职系</td>
            <td align="left" style="width: 25%">
                <asp:DropDownList ID="ddGrades" runat="server" Width="40%" Height="24px">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
</div>
<div class="tablebt">
    <table>
        <tr>
            <td align="left" style="width: 100px">
                <asp:Button ID="btnSearch" runat="server" Text="查　询" OnClick="btnSearch_Click" CssClass="inputbt" />
            </td>
            <td align="left" id="tdExport" runat="server">
                <input id="btnExportClient" type="button" value="导　出" onclick="document.getElementById('cphCenter_btnExportServer').click();"
                    class="inputbt" />
            </td>
        </tr>
    </table>
</div>
<div class="nolinetablediv">
    <table width="100%" height="38" cellpadding="4" cellspacing="0"
        class="linetable_3">
        <tr>
            <td style="WIDTH: 1139px" align="middle"  class="assessbasicinfobg">
                <div class="infotitlelist" style="text-align: left">
                    <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" StaticEnableDefaultPopOutImage="False"
                        OnMenuItemClick="Menu1_MenuItemClick" class="cphCenter_DayAttendanceView1_Menu1_2" >
                        <Items>
                            <asp:MenuItem Text="" Value="1" ToolTip="第一周"></asp:MenuItem>
                            <asp:MenuItem Text="" Value="2" ToolTip="第二周"></asp:MenuItem>
                            <asp:MenuItem Text="" Value="3" ToolTip="第三周"></asp:MenuItem>
                            <asp:MenuItem Text="" Value="4" ToolTip="第四周"></asp:MenuItem>
                            <asp:MenuItem Text="" Value="5" ToolTip="第五周"></asp:MenuItem>
                            <asp:MenuItem Text="" Value="6" ToolTip="第六周"></asp:MenuItem>
                        </Items>
                    </asp:Menu>
                </div>
            </td>
        </tr>
    </table>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="Tab1" runat="server">
            <uc1:DayAttendanceWeekView ID="DayAttendanceWeekView1" runat="server"></uc1:DayAttendanceWeekView>
        </asp:View>
        <asp:View ID="Tab2" runat="server">
            <uc1:DayAttendanceWeekView ID="DayAttendanceWeekView2" runat="server"></uc1:DayAttendanceWeekView>
        </asp:View>
        <asp:View ID="Tab3" runat="server">
            <uc1:DayAttendanceWeekView ID="DayAttendanceWeekView3" runat="server"></uc1:DayAttendanceWeekView>
        </asp:View>
        <asp:View ID="Tab4" runat="server">
            <uc1:DayAttendanceWeekView ID="DayAttendanceWeekView4" runat="server"></uc1:DayAttendanceWeekView>
        </asp:View>
        <asp:View ID="Tab5" runat="server">
            <uc1:DayAttendanceWeekView ID="DayAttendanceWeekView5" runat="server"></uc1:DayAttendanceWeekView>
        </asp:View>
        <asp:View ID="View6" runat="server">
            <uc1:DayAttendanceWeekView ID="DayAttendanceWeekView6" runat="server"></uc1:DayAttendanceWeekView>
        </asp:View>
    </asp:MultiView>
</div>
<asp:HiddenField ID="hfFromDate" runat="server" />
<asp:HiddenField ID="hfCurrentTab" runat="server" />
<asp:HiddenField ID="lblCurrent" runat="server" Value="0" />
<asp:HiddenField ID="hfToDate" runat="server" />
