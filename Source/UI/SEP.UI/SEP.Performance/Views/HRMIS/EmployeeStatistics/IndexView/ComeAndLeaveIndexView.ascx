<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ComeAndLeaveIndexView.ascx.cs" Inherits="SEP.Performance.Views.EmployeeStatistics.IndexView.ComeAndLeaveIndexView" %>
<%@ Register Src="../StatisticsConditionView.ascx" TagName="StatisticsConditionView"
    TagPrefix="uc5" %>
<%@ Register Src="../ComeAndLeaveTableView.ascx" TagName="ComeAndLeaveTableView"
    TagPrefix="uc1" %>
<%@ Register Src="../ComeAndLeaveBarChartView.ascx" TagName="ComeAndLeaveBarChartView"
    TagPrefix="uc3" %>
<%@ Register Src="../LeaveRateLineChartView.ascx" TagName="LeaveRateLineChartView"
    TagPrefix="uc4" %>

<link href="../../CSS/style.css" rel="stylesheet" type="text/css" />
<div style=" text-align:left">
<label id="showsettingComeAndLeave" style="text-align:left; margin-left:2px; width:80px" class="showsetdiv" 
onclick="ShowOrHideForm('showsearchComeAndLeave','showsettingComeAndLeave','hiddensettingComeAndLeave',1)">设置统计条件</label>
<label id="hiddensettingComeAndLeave" style="text-align:left; margin-left:2px; width:80px" class="hiddensetdiv" 
onclick="ShowOrHideForm('showsearchComeAndLeave','showsettingComeAndLeave','hiddensettingComeAndLeave',0)">隐藏统计条件</label>
</div>
<div id="showsearchComeAndLeave" class="hiddenformdiv" style="position:absolute">
<table width="250px">
    <tr>
    <td>
        <uc5:StatisticsConditionView ID="StatisticsConditionView1" runat="server" />
    </td>
    </tr>
</table>
</div>        
             <table width="100%" style="text-align:left">
                <tr>
                    <td colspan="2">
                        <uc1:ComeAndLeaveTableView ID="ComeAndLeaveTableView1" runat="server" />
                        </td>
                </tr>

                <tr>
                    <td colspan="2">
                        <uc3:ComeAndLeaveBarChartView ID="ComeAndLeaveBarChartView1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <uc4:LeaveRateLineChartView ID="LeaveRateLineChartView1" runat="server" />
                        
                    </td>
                </tr>
            </table>
