<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TimeSpanStatisticsGroupByParaIndexView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.PayModuleViews.EmployeeSalaryStatistics.SummaryStatistics.IndexView.TimeSpanStatisticsGroupByParaIndexView" %>
<%@ Register Src="../TimeSpanStatisticsGroupByParaTableView.ascx" TagName="TimeSpanStatisticsGroupByParaTableView"
    TagPrefix="uc2" %>
<%@ Register Src="../TimeSpanStatisticsGroupByParaLineChartView.ascx" TagName="TimeSpanStatisticsGroupByParaLineChartView"
    TagPrefix="uc3" %>
<%@ Register Src="../StatisticsConditionView.ascx" TagName="StatisticsConditionView"
    TagPrefix="uc1" %>
<link href="../CSS/style.css" rel="stylesheet" type="text/css" />
<link href="../CSS/style.css" rel="stylesheet" type="text/css" />
<div style=" text-align:left">
<label id="showsettingTimeSpanStatisticsGroupByPara" style="text-align:left; margin-left:2px; width:80px" class="showsetdiv" 
onclick="ShowOrHideForm('showsearchTimeSpanStatisticsGroupByPara','showsettingTimeSpanStatisticsGroupByPara','hiddensettingTimeSpanStatisticsGroupByPara',1)">设置统计条件</label>
<label id="hiddensettingTimeSpanStatisticsGroupByPara" style="text-align:left; margin-left:2px; width:80px" class="hiddensetdiv" 
onclick="ShowOrHideForm('showsearchTimeSpanStatisticsGroupByPara','showsettingTimeSpanStatisticsGroupByPara','hiddensettingTimeSpanStatisticsGroupByPara',0)">隐藏统计条件</label>
</div>
<div id="showsearchTimeSpanStatisticsGroupByPara" class="hiddenformdiv" style="z-index:10; position: absolute; text-align:left; width:250px">
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
                        <uc2:TimeSpanStatisticsGroupByParaTableView ID="TimeSpanStatisticsGroupByParaTableView1"
                            runat="server" />
                    </td>
                </tr>

                <tr>
                    <td>
                        <uc3:TimeSpanStatisticsGroupByParaLineChartView ID="TimeSpanStatisticsGroupByParaLineChartView1"
                            runat="server" />
                    </td>
                </tr>
             </table>
