<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AgePieChartIndexView.ascx.cs" Inherits="SEP.Performance.Views.EmployeeStatistics.IndexView.AgePieChartIndexView" %>
<%@ Register Src="../AgePieChartView.ascx" TagName="AgePieChartView" TagPrefix="uc1" %>
<%@ Register Src="../StatisticsConditionView.ascx" TagName="StatisticsConditionView"
    TagPrefix="uc2" %>
<link href="../../CSS/style.css" rel="stylesheet" type="text/css" />
<div style=" text-align:left">
<label id="showsettingAgePie" style="text-align:left; margin-left:2px; width:80px" class="showsetdiv" 
onclick="ShowOrHideForm('showsearchAgePie','showsettingAgePie','hiddensettingAgePie',1)">设置统计条件</label>
<label id="hiddensettingAgePie" style="text-align:left; margin-left:2px; width:80px" class="hiddensetdiv" 
onclick="ShowOrHideForm('showsearchAgePie','showsettingAgePie','hiddensettingAgePie',0)">隐藏统计条件</label>
</div>
<div id="showsearchAgePie" class="hiddenformdiv" style="position:absolute">
<table width="250px">
    <tr>
    <td>
    <uc2:StatisticsConditionView ID="StatisticsConditionView1" runat="server" />
    </td>
    </tr>
</table>
</div>        
             <table width="100%" style="text-align:center">
                <tr>
                    <td>
    <uc1:AgePieChartView ID="AgePieChartView1" runat="server" />
                    </td>
                </tr>
             </table>
