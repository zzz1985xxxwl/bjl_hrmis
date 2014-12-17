<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AverageStatisticsIndexView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.PayModuleViews.EmployeeSalaryStatistics.AverageStatistics.IndexView.AverageStatisticsIndexView" %>
<%@ Register Src="../StatisticsConditionView.ascx" TagName="StatisticsConditionView"
    TagPrefix="uc1" %>
<%@ Register Src="../AverageStatisticsTableView.ascx" TagName="AverageStatisticsTableView"
    TagPrefix="uc2" %>
<%@ Register Src="../AverageStatisticsBarChartView.ascx" TagName="AverageStatisticsBarChartView"
    TagPrefix="uc3" %>
<div style=" text-align:left">
<label id="showsettingAverageStatistics" style="text-align:left; margin-left:2px; width:80px" class="showsetdiv" 
onclick="ShowOrHideForm('showsearchAverageStatistics','showsettingAverageStatistics','hiddensettingAverageStatistics',1)">设置统计条件</label>
<label id="hiddensettingAverageStatistics" style="text-align:left; margin-left:2px; width:80px" class="hiddensetdiv" 
onclick="ShowOrHideForm('showsearchAverageStatistics','showsettingAverageStatistics','hiddensettingAverageStatistics',0)">隐藏统计条件</label>
</div>
<div id="showsearchAverageStatistics" class="hiddenformdiv" style="z-index:10; position: absolute; text-align:left; width:250px">
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
                        <uc2:AverageStatisticsTableView ID="AverageStatisticsTableView1" runat="server" />
                    </td>
                </tr>

                <tr>
                    <td>
                        <uc3:AverageStatisticsBarChartView ID="AverageStatisticsBarChartView1" runat="server" />
                    </td>
                </tr>
             </table>
