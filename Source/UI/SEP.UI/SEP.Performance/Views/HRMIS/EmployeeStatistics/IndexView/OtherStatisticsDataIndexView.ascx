<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OtherStatisticsDataIndexView.ascx.cs" Inherits="SEP.Performance.Views.EmployeeStatistics.IndexView.OtherStatisticsDataIndexView" %>
<%@ Register Src="../OtherStatisticsDataView.ascx" TagName="OtherStatisticsDataView"
    TagPrefix="uc1" %>
<%@ Register Src="../StatisticsConditionView.ascx" TagName="StatisticsConditionView"
    TagPrefix="uc2" %>
<link href="../../CSS/style.css" rel="stylesheet" type="text/css" />
<div style=" text-align:left">
<label id="showsettingOtherStatisticsData" style="text-align:left; margin-left:2px; width:80px" class="showsetdiv" 
onclick="ShowOrHideForm('showsearchOtherStatisticsData','showsettingOtherStatisticsData','hiddensettingOtherStatisticsData',1)">设置统计条件</label>
<label id="hiddensettingOtherStatisticsData" style="text-align:left; margin-left:2px; width:80px" class="hiddensetdiv" 
onclick="ShowOrHideForm('showsearchOtherStatisticsData','showsettingOtherStatisticsData','hiddensettingOtherStatisticsData',0)">隐藏统计条件</label>
</div>
<div id="showsearchOtherStatisticsData" class="hiddenformdiv" style="position:absolute">
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
<uc1:OtherStatisticsDataView ID="OtherStatisticsDataView1" runat="server" />
                    </td>
                </tr>
             </table>
