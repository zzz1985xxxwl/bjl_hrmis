<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommonStatisticsView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.PayModuleViews.EmployeeSalaryStatistics.AverageStatistics.CommonStatisticsView" %>
<%@ Register Src="TimeSpanStatisticsGroupByDeptTableView.ascx" TagName="TimeSpanStatisticsGroupByDeptTableView"
    TagPrefix="uc4" %>
<%@ Register Src="TimeSpanStatisticsGroupByDeptLineChartView.ascx" TagName="TimeSpanStatisticsGroupByDeptLineChartView"
    TagPrefix="uc5" %>
<%@ Register Src="AverageStatisticsBarChartView.ascx" TagName="AverageStatisticsBarChartView"
    TagPrefix="uc3" %>
<%@ Register Src="AverageStatisticsTableView.ascx" TagName="AverageStatisticsTableView"
    TagPrefix="uc2" %>
<%@ Register Src="StatisticsConditionView.ascx" TagName="StatisticsConditionView"
    TagPrefix="uc1" %>
<link href="../CSS/style.css" rel="stylesheet" type="text/css" />
<link href="../CSS/style.css" rel="stylesheet" type="text/css" />
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">

            <ContentTemplate>
<table width="100%" border="0" cellpadding="0" cellspacing="5">
    <tr>
        <td width="25%" valign="top" style="height: 512px">
            <table width="100%">
                <tr>
                    <td>
                        <uc1:StatisticsConditionView ID="StatisticsConditionView1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
            </table>
            </td>
        <td width="75%" valign="top">
            <table width="100%" style="text-align:left">
                <tr>
                    <td>
                        <uc2:AverageStatisticsTableView id="AverageStatisticsTableView1" runat="server">
                        </uc2:AverageStatisticsTableView>
                    </td>
                </tr>

                <tr>
                    <td>
                        <uc3:AverageStatisticsBarChartView ID="AverageStatisticsBarChartView1" runat="server" />
                        </td>
                </tr>
                <tr>
                    <td>
                        <uc4:TimeSpanStatisticsGroupByDeptTableView ID="TimeSpanStatisticsGroupByDeptTableView1"
                            runat="server" />
                    </td>
                </tr>

                <tr>
                    <td>
                        <uc5:TimeSpanStatisticsGroupByDeptLineChartView ID="TimeSpanStatisticsGroupByDeptLineChartView1"
                            runat="server" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>

</ContentTemplate>
</asp:UpdatePanel>