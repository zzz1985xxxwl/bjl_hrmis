<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommonStatisticsView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.Reimburse.ReimburseStatistics.CommonStatisticsView" %>

<%@ Register Src="DepartmentStatisticsBarChartView.ascx" TagName="DepartmentStatisticsBarChartView"
    TagPrefix="uc5" %>
<%@ Register Src="StatisticsConditionView.ascx" TagName="StatisticsConditionView"
    TagPrefix="uc1" %>
<%@ Register Src="DepartmentStatisticsTableView.ascx" TagName="DepartmentStatisticsTableView"
    TagPrefix="uc2" %>
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
                
            </table>
        </td>
    </tr>
</table>

</ContentTemplate>
</asp:UpdatePanel>