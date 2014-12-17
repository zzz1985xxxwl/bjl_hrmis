<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DepartmentStatisticsIndexView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.PayModuleViews.EmployeeSalaryStatistics.SummaryStatistics.IndexView.DepartmentStatisticsIndexView" %>
<%@ Register Src="../DepartmentStatisticsTableView.ascx" TagName="DepartmentStatisticsTableView"
    TagPrefix="uc2" %>
<%@ Register Src="../DepartmentStatisticsBarChartView.ascx" TagName="DepartmentStatisticsBarChartView"
    TagPrefix="uc3" %>
<%@ Register Src="../StatisticsConditionView.ascx" TagName="StatisticsConditionView"
    TagPrefix="uc1" %>

<link href="../CSS/style.css" rel="stylesheet" type="text/css" />
<link href="../CSS/style.css" rel="stylesheet" type="text/css" />
<div style=" text-align:left">
<label id="showsettingDepartmentStatistics" style="text-align:left; margin-left:2px; width:80px" class="showsetdiv" 
onclick="ShowOrHideForm('showsearchDepartmentStatistics','showsettingDepartmentStatistics','hiddensettingDepartmentStatistics',1)">设置统计条件</label>
<label id="hiddensettingDepartmentStatistics" style="text-align:left; margin-left:2px; width:80px" class="hiddensetdiv" 
onclick="ShowOrHideForm('showsearchDepartmentStatistics','showsettingDepartmentStatistics','hiddensettingDepartmentStatistics',0)">隐藏统计条件</label>
</div>
<div id="showsearchDepartmentStatistics" class="hiddenformdiv" style="z-index:10; position: absolute; text-align:left; width:250px">
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
                        <uc2:DepartmentStatisticsTableView ID="DepartmentStatisticsTableView1" runat="server" />
                    </td>
                </tr>

                <tr>
                    <td>
                        <uc3:DepartmentStatisticsBarChartView ID="DepartmentStatisticsBarChartView1" runat="server" />
                    </td>
                </tr>
             </table>
