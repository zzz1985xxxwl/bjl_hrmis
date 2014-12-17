<%@ Control Language="C#" AutoEventWireup="true" Codebehind="SetPlanDutyView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.AttendanceStatistics.PlanDutyViews.SetPlanDutyView" %>
<%@ Register Assembly="PlanDutyCalendar.Web.UI" Namespace="PlanDutyCalendar.Web.UI"
    TagPrefix="cc1" %>

<script type="text/javascript">
function SelectedIndexChange(ddName)
{
var selectValue=document.getElementById(ddName).value;
if(selectValue=="-1")
{
document.getElementById(ddName).style.backgroundColor="#ffeded";
document.getElementById(ddName).style.font.fontColor="Black";
}
else
{
document.getElementById(ddName).style.backgroundColor="White";
document.getElementById(ddName).style.font.fontColor="Green";
}
var p=document.getElementById('cphCenter_SetPlanDutyInfoView1_SetPlanDutyView1_txtPeriod').value;
if(p!="" && !isNaN(p) && p>0)
{
var selectDate= ddName.split('-');
while(parseInt(selectDate[2])<31)
{
selectDate[2]=(parseInt(selectDate[2]))+parseInt(p);
var nextDD=document.getElementById(selectDate[0]+"-"+selectDate[1]+"-"+selectDate[2]);
if(nextDD==null)
{
break;
}
else
{
document.getElementById(selectDate[0]+"-"+selectDate[1]+"-"+selectDate[2]).value=selectValue;
if(selectValue=="-1")
{
document.getElementById(selectDate[0]+"-"+selectDate[1]+"-"+selectDate[2]).style.backgroundColor="#ffeded";
document.getElementById(selectDate[0]+"-"+selectDate[1]+"-"+selectDate[2]).style.font.fontColor="Black";
}
else
{
document.getElementById(selectDate[0]+"-"+selectDate[1]+"-"+selectDate[2]).style.backgroundColor="White";
document.getElementById(selectDate[0]+"-"+selectDate[1]+"-"+selectDate[2]).style.font.fontColor="Green";
}

}
}
}
}
</script>

<div id="tbMessage" style="display: none" runat="server" class="leftitbor">
    <asp:Label ID="lblMessage" runat="server" CssClass="fontred"></asp:Label>
</div>
<div class="leftitbor2">
    <asp:Label ID="lblOperationTitle" runat="server">
    </asp:Label>
</div>
<div id="table1" runat="server" class="linetablediv"  style="padding:8px;">
    <table width="100%"  cellspacing="0"   >
        <tr>
            <td colspan="7" align="left">
                <asp:ImageButton ID="IbtnLast" runat="server" ImageUrl="../../../../pages/image/prev.gif"
                    OnClick="IbtnLast_Click" />
                <asp:Label ID="lblYearMonth" runat="server" Text="Label" Width="60px"></asp:Label>
                <asp:ImageButton ID="IBtnNext" runat="server" ImageUrl="../../../../pages/image/next.gif"
                    OnClick="IBtnNext_Click" />
                <asp:HiddenField ID="lblCurrentDay" runat="server" />
                <asp:HiddenField ID="lblPlanDutyID" runat="server" />
                &nbsp;&nbsp;
            </td>
            <td rowspan="3">
                <table width="100%" border="0" cellpadding="0" style="border-collapse:separate;" cellspacing="10">
                    <tr>
                        <td align="left" width="80px">
                            排班表名称&nbsp;<span class="redstar">*</span></td>
                        <td align="left" style="height: 30px">
                            <asp:TextBox runat="server" ID="txtPlanDutyName" class="input1" Width="90px"></asp:TextBox>
                            <asp:Label ID="lblPlanDutyNameMessage" runat="server" CssClass="psword_f"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="left" style="height: 30px;">
                            时间范围&nbsp;<span class="redstar">*</span></td>
                        <td align="left" style="height: 30px">
                            <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="dtpScopeFrom"
                                Format="yyyy-MM-dd">
                            </ajaxToolKit:CalendarExtender>
                            <ajaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="dtpScopeTo"
                                Format="yyyy-MM-dd">
                            </ajaxToolKit:CalendarExtender>
                            <asp:TextBox ID="dtpScopeFrom" runat="server" CssClass="input1" Width="90px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="height: 30px;">
                            -- &nbsp;&nbsp;</td>
                        <td align="left" style="height: 30px">
                            <asp:TextBox ID="dtpScopeTo" runat="server" CssClass="input1" Width="90px"></asp:TextBox>
                            <asp:Label ID="lblTimeMessage" runat="server" CssClass="psword_f"></asp:Label></td>
                        <td align="left" style="height: 30px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:TextBox runat="server" ID="txtPeriod" class="input1" Width="54px"></asp:TextBox>天为一周期（不填则没有周期）
                            <asp:Label ID="lblPeriodMessage" runat="server" CssClass="psword_f"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="height: 30px;" colspan="2">
                            应用该排班的员工
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="height: 30px;" colspan="2">
                            <asp:TextBox ID="txtEmployeeList" runat="server" CssClass="grayborder" Height="40px" TextMode="MultiLine"
                                Width="100%" onfocus="btnChooseMailCCClick();"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 30px" align="left">
                            <asp:Button ID="btnDutyClassDisplace" runat="server" CssClass="inputbt" Text=" 班别替换 "
                                OnClick="btnDutyClassDisplace_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 30px">
                            <asp:Button ID="btnCopyPlanDuty" runat="server" CssClass="inputbt" Text="复制排班表" OnClick="btnCopyPlanDuty_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnPlasterPlanDuty" runat="server" CssClass="inputbt" Text="粘贴排班表"
                                OnClick="btnPlasterPlanDuty_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 30px">
                            <asp:Button ID="btnCreatePlanDuty" runat="server" CssClass="inputbt" Text=" 生成排班 "
                                OnClick="btnCreatePlanDuty_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnCancel" runat="server" CssClass="inputbt" Text=" 取    消 " OnClick="btnCancel_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr class="weektype">
            <td width="15%" align="center" style="font-family: 宋体; height: 25px;">
               星期一</td>
            <td width="14%" align="center" style="font-family: 宋体; height: 25px;">
                星期二</td>
            <td width="14%" align="center" style="font-family: 宋体; height: 25px;">
               星期三</td>
            <td width="14%" align="center" style="font-family: 宋体; height: 25px;">
              星期四</td>
            <td width="14%" align="center" style="font-family: 宋体; height: 25px;">
                星期五</td>
            <td width="14%" align="center" style="font-family: 宋体; height: 25px;">
                星期六</td>
            <td width="15%" align="center" style="font-family: 宋体; height: 25px;">
                星期日</td>
        </tr>
        <tr>
            <td colspan="7" align="center">
                <cc1:PlanDutyCalendar ID="Calendar1" runat="server"  CssClass="lineBorder" BackColor="Transparent"  DayNameFormat="Full" EnableTheming="True"
                    eventdescriptioncolumnname="" eventheadercolumnname="" FirstDayOfWeek="Monday" 
                    Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" NextMonthText="Next >"
                    PrevMonthText="< Prev" showdescriptionastooltip="True" ShowGridLines="True" Width="100%"
                    Height="100%" CellPadding="0" ShowDayHeader="False" ShowTitle="False">
                    <SelectedDayStyle BackColor="Azure" ForeColor="Navy" />
                    <SelectorStyle BorderColor="#404040" BorderStyle="Solid" />
                    <TodayDayStyle BackColor="LightYellow" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <DayStyle   Font-Names="黑体" Font-Size="10pt"
                        ForeColor="#294EA3" Font-Underline="False" Wrap="True" VerticalAlign="Top" HorizontalAlign="Right"
                        Font-Bold="True" CssClass="calanderBack dayStyle lineBorder" BorderStyle="Solid"  />
                    <NextPrevStyle Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" Font-Bold="True"
                        HorizontalAlign="Left" />
                    <DayHeaderStyle  CssClass="lineBorder"  Font-Names="宋体" Font-Size="9pt"
                        ForeColor="White" HorizontalAlign="Center" Font-Bold="False"  />
                    <TitleStyle BackColor="Transparent" BorderColor="Transparent" Font-Names="微软雅黑" Font-Size="Small"
                        ForeColor="Black" BorderStyle="None" VerticalAlign="Middle" HorizontalAlign="Left"
                        Font-Bold="False" Height="40px" />
                    <WeekendDayStyle  CssClass="dayStyle lineBorder" />
                </cc1:PlanDutyCalendar>
            </td>
        </tr>
    </table>
</div>
