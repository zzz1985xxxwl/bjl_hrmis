<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WorkTypePieChartIndexView.ascx.cs" Inherits="SEP.Performance.Views.EmployeeStatistics.IndexView.WorkTypePieChartIndexView" %>
<%@ Register Src="../WorkTypePieChartView.ascx" TagName="WorkTypePieChartView" TagPrefix="uc1" %>
<%@ Register Src="../OtherStatisticsDataView.ascx" TagName="OtherStatisticsDataView"
    TagPrefix="uc2" %>
<%@ Register Src="../StatisticsConditionView.ascx" TagName="StatisticsConditionView"
    TagPrefix="uc3" %>
<link href="../../CSS/style.css" rel="stylesheet" type="text/css" />
<div style=" text-align:left">
<label id="showsettingWorkTypePie" style="text-align:left; margin-left:2px; width:80px" class="showsetdiv" 
onclick="ShowOrHideForm('showsearchWorkTypePie','showsettingWorkTypePie','hiddensettingWorkTypePie',1)">设置统计条件</label>
<label id="hiddensettingWorkTypePie" style="text-align:left; margin-left:2px; width:80px" class="hiddensetdiv" 
onclick="ShowOrHideForm('showsearchWorkTypePie','showsettingWorkTypePie','hiddensettingWorkTypePie',0)">隐藏统计条件</label>
</div>
<div id="showsearchWorkTypePie" class="hiddenformdiv" style="position:absolute">
<table width="250px">
    <tr>
    <td>
        <uc3:StatisticsConditionView ID="StatisticsConditionView1" runat="server" />
    </td>
    </tr>
</table>
</div>        
             <table width="100%" style="text-align:center">
                <tr>
                    <td>
<uc1:WorkTypePieChartView ID="WorkTypePieChartView1" runat="server" />
                    </td>
                </tr>
             </table>
