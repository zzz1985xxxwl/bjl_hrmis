<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TimeSpanStatisticsGroupByDeptIndexView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.PayModuleViews.EmployeeSalaryStatistics.AverageStatistics.IndexView.TimeSpanStatisticsGroupByDeptIndexView" %>
<%@ Register Src="../TimeSpanStatisticsGroupByDeptTableView.ascx" TagName="TimeSpanStatisticsGroupByDeptTableView"
    TagPrefix="uc2" %>
<%@ Register Src="../TimeSpanStatisticsGroupByDeptLineChartView.ascx" TagName="TimeSpanStatisticsGroupByDeptLineChartView"
    TagPrefix="uc3" %>
<%@ Register Src="../StatisticsConditionView.ascx" TagName="StatisticsConditionView"
    TagPrefix="uc1" %>
<div style=" text-align:left">
<label id="showsettingTimeSpanStatisticsGroupByDept" style="text-align:left; margin-left:2px; width:80px" class="showsetdiv" 
onclick="ShowOrHideForm('showsearchTimeSpanStatisticsGroupByDept','showsettingTimeSpanStatisticsGroupByDept','hiddensettingTimeSpanStatisticsGroupByDept',1)">设置统计条件</label>
<label id="hiddensettingTimeSpanStatisticsGroupByDept" style="text-align:left; margin-left:2px; width:80px" class="hiddensetdiv" 
onclick="ShowOrHideForm('showsearchTimeSpanStatisticsGroupByDept','showsettingTimeSpanStatisticsGroupByDept','hiddensettingTimeSpanStatisticsGroupByDept',0)">隐藏统计条件</label>
</div>
<div id="showsearchTimeSpanStatisticsGroupByDept" class="hiddenformdiv" style="z-index:10; position: absolute; text-align:left; width:250px">
<table >
    <tr>
    <td >
        <uc1:StatisticsConditionView ID="StatisticsConditionView1" runat="server" />
    </td>
    </tr>
</table>
</div>   
             <table width="100%" style="text-align:left">
                <tr>
                    <td>
                        <uc2:TimeSpanStatisticsGroupByDeptTableView id="TimeSpanStatisticsGroupByDeptTableView1"
                            runat="server"/>
                    </td>
                </tr>

                <tr>
                    <td>
                        <uc3:TimeSpanStatisticsGroupByDeptLineChartView ID="TimeSpanStatisticsGroupByDeptLineChartView1"
                            runat="server" />
                    </td>
                </tr>
             </table>
