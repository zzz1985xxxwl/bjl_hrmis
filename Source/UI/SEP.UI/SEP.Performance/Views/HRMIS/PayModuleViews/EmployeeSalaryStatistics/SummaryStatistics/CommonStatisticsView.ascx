<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommonStatisticsView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.PayModuleViews.EmployeeSalaryStatistics.SummaryStatistics.CommonStatisticsView" %>
<%@ Register Src="TimeSpanStatisticsGroupByParaTableView.ascx" TagName="TimeSpanStatisticsGroupByParaTableView"
    TagPrefix="uc4" %>
<%@ Register Src="TimeSpanStatisticsGroupByParaLineChartView.ascx" TagName="TimeSpanStatisticsGroupByParaLineChartView"
    TagPrefix="uc6" %>
<%@ Register Src="DepartmentStatisticsBarChartView.ascx" TagName="DepartmentStatisticsBarChartView"
    TagPrefix="uc5" %>
<%@ Register Src="PositionStatisticsBarChartView.ascx" TagName="PositionStatisticsBarChartView"
    TagPrefix="uc7" %>
<%@ Register Src="PositionStatisticsTableView.ascx" TagName="PositionStatisticsTableView"
    TagPrefix="uc3" %>
<%@ Register Src="StatisticsConditionView.ascx" TagName="StatisticsConditionView"
    TagPrefix="uc1" %>
<%@ Register Src="DepartmentStatisticsTableView.ascx" TagName="DepartmentStatisticsTableView"
    TagPrefix="uc2" %>
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
                        <uc2:DepartmentStatisticsTableView ID="DepartmentStatisticsTableView1" runat="server" />
                    </td>
                </tr>

                <tr>
                    <td>
                        <uc5:DepartmentStatisticsBarChartView ID="DepartmentStatisticsBarChartView1" runat="server" />
                        </td>
                </tr>

                <tr>
                    <td>
                        <uc3:PositionStatisticsTableView ID="PositionStatisticsTableView1" runat="server" />
                    </td>
                </tr>

                <tr>
                    <td>
                        <uc7:PositionStatisticsBarChartView ID="PositionStatisticsBarChartView1" runat="server" />

                        </td>
                </tr>
                <tr>
                    <td>
                        <uc4:TimeSpanStatisticsGroupByParaTableView id="TimeSpanStatisticsGroupByParaTableView1"
                            runat="server"/>
                    </td>
                </tr>

                <tr>
                    <td>
                        <uc6:TimeSpanStatisticsGroupByParaLineChartView id="TimeSpanStatisticsGroupByParaLineChartView1"
                            runat="server"/>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>

</ContentTemplate>
</asp:UpdatePanel>