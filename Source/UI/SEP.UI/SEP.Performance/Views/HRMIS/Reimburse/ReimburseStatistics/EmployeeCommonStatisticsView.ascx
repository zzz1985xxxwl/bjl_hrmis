<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeCommonStatisticsView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.Reimburse.ReimburseStatistics.EmployeeCommonStatisticsView" %>
<%@ Register Src="EmployeeStatisticsBarChartView.ascx" TagName="EmployeeStatisticsBarChartView"
    TagPrefix="uc3" %>
<%@ Register Src="EmployeeStatisticsConditionView.ascx" TagName="EmployeeStatisticsConditionView"
    TagPrefix="uc1" %>
<%@ Register Src="EmployeeStatisticsTableView.ascx" TagName="EmployeeStatisticsTableView"
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
                        <uc1:EmployeeStatisticsConditionView ID="EmployeeStatisticsConditionView1" runat="server" />
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
                        <uc2:EmployeeStatisticsTableView ID="EmployeeStatisticsTableView1" runat="server" />
                    </td>
                </tr>

                <tr>
                    <td>
                        <uc3:EmployeeStatisticsBarChartView ID="EmployeeStatisticsBarChartView1" runat="server" />
                        </td>
                </tr>
                
            </table>
        </td>
    </tr>
</table>

</ContentTemplate>
</asp:UpdatePanel>
