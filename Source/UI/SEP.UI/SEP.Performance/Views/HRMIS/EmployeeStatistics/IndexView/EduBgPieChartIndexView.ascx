<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EduBgPieChartIndexView.ascx.cs" Inherits="SEP.Performance.Views.EmployeeStatistics.IndexView.EduBgPieChartIndexView" %>
<%@ Register Src="../EduBgPieChartView.ascx" TagName="EducationalBackgroundPieChartView"
    TagPrefix="uc1" %>
<%@ Register Src="../StatisticsConditionView.ascx" TagName="StatisticsConditionView"
    TagPrefix="uc2" %>
<%@ Register Src="../EduBgPieChartView.ascx" TagName="EduBgPieChartView" TagPrefix="uc3" %>
<link href="../../CSS/style.css" rel="stylesheet" type="text/css" />
<div style=" text-align:left">
<label id="showsettingEduBgPie" style="text-align:left; margin-left:2px; width:80px" class="showsetdiv" 
onclick="ShowOrHideForm('showsearchEduBgPie','showsettingEduBgPie','hiddensettingEduBgPie',1)">设置统计条件</label>
<label id="hiddensettingEduBgPie" style="text-align:left; margin-left:2px; width:80px" class="hiddensetdiv" 
onclick="ShowOrHideForm('showsearchEduBgPie','showsettingEduBgPie','hiddensettingEduBgPie',0)">隐藏统计条件</label>
</div>
<div id="showsearchEduBgPie" class="hiddenformdiv" style="position:absolute">
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
<uc3:EduBgPieChartView id="EduBgPieChartView1" runat="server"></uc3:EduBgPieChartView>
                    </td>
                </tr>
             </table>
