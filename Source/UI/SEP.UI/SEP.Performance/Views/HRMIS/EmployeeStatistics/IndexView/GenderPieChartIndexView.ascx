<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GenderPieChartIndexView.ascx.cs" Inherits="SEP.Performance.Views.EmployeeStatistics.IndexView.GenderPieChartIndexView" %>
<%@ Register Src="../GenderPieChartView.ascx" TagName="GenderPieChartView" TagPrefix="uc1" %>
<%@ Register Src="../StatisticsConditionView.ascx" TagName="StatisticsConditionView"
    TagPrefix="uc2" %>
<link href="../../CSS/style.css" rel="stylesheet" type="text/css" />
<div style=" text-align:left">
<label id="showsettingGenderPie" style="text-align:left; margin-left:2px; width:80px" class="showsetdiv" 
onclick="ShowOrHideForm('showsearchGenderPie','showsettingGenderPie','hiddensettingGenderPie',1)">设置统计条件</label>
<label id="hiddensettingGenderPie" style="text-align:left; margin-left:2px; width:80px" class="hiddensetdiv" 
onclick="ShowOrHideForm('showsearchGenderPie','showsettingGenderPie','hiddensettingGenderPie',0)">隐藏统计条件</label>
</div>
<div id="showsearchGenderPie" class="hiddenformdiv" style="position:absolute">
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
<uc1:GenderPieChartView ID="GenderPieChartView1" runat="server" />
                    </td>
                </tr>
             </table>
