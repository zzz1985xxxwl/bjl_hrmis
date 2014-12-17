<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PositionStatisticsIndexView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.PayModuleViews.EmployeeSalaryStatistics.SummaryStatistics.IndexView.PositionStatisticsIndexView" %>
<%@ Register Src="../StatisticsConditionView.ascx" TagName="StatisticsConditionView"
    TagPrefix="uc1" %>
<%@ Register Src="../PositionStatisticsTableView.ascx" TagName="PositionStatisticsTableView"
    TagPrefix="uc2" %>
<%@ Register Src="../PositionStatisticsBarChartView.ascx" TagName="PositionStatisticsBarChartView"
    TagPrefix="uc3" %>
<link href="../CSS/style.css" rel="stylesheet" type="text/css" />
<div style=" text-align:left">
<label id="showsettingPositionStatistics" style="text-align:left; margin-left:2px; width:80px" class="showsetdiv" 
onclick="ShowOrHideForm('showsearchPositionStatistics','showsettingPositionStatistics','hiddensettingPositionStatistics',1)">设置统计条件</label>
<label id="hiddensettingPositionStatistics" style="text-align:left; margin-left:2px; width:80px" class="hiddensetdiv" 
onclick="ShowOrHideForm('showsearchPositionStatistics','showsettingPositionStatistics','hiddensettingPositionStatistics',0)">隐藏统计条件</label>
</div>
<div id="showsearchPositionStatistics" class="hiddenformdiv" style="z-index:10; position: absolute; text-align:left; width:250px">
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
                        <uc2:PositionStatisticsTableView ID="PositionStatisticsTableView1" runat="server" />
                    </td>
                </tr>

                <tr>
                    <td>
                        <uc3:PositionStatisticsBarChartView ID="PositionStatisticsBarChartView1" runat="server" />
                    </td>
                </tr>
             </table>
