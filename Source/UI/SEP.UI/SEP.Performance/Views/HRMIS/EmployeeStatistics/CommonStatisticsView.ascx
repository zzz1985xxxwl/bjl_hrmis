<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommonStatisticsView.ascx.cs" Inherits="SEP.Performance.Views.EmployeeStatistics.CommonStatisticsView" %>
<%@ Register Src="PositionGradeTowerTableView.ascx" TagName="PositionGradeTowerTableView"
    TagPrefix="uc11" %>
<%@ Register Src="ComeAndLeaveTableView.ascx" TagName="ComeAndLeaveTableView" TagPrefix="uc10" %>
<%@ Register Src="AgePieChartView.ascx" TagName="AgePieChartView" TagPrefix="uc8" %>
<%@ Register Src="WorkAgePieChartView.ascx" TagName="WorkAgePieChartView" TagPrefix="uc9" %>
<%@ Register Src="WorkTypePieChartView.ascx" TagName="WorkTypePieChartView" TagPrefix="uc7" %>
<%@ Register Src="EduBgPieChartView.ascx" TagName="EduBgPieChartView"
    TagPrefix="uc6" %>
<%@ Register Src="LeaveRateLineChartView.ascx" TagName="LeaveRateLineChartView" TagPrefix="uc5" %>
<%@ Register Src="ComeAndLeaveBarChartView.ascx" TagName="ComeAndLeaveBarChartView"
    TagPrefix="uc4" %>
<%@ Register Src="OtherStatisticsDataView.ascx" TagName="OtherStatisticsDataView"
    TagPrefix="uc3" %>
<%@ Register Src="GenderPieChartView.ascx" TagName="GenderPieChartView"
    TagPrefix="uc2" %>
<%@ Register Src="StatisticsConditionView.ascx" TagName="StatisticsConditionView"
    TagPrefix="uc1" %>
    <%@ Register Src="../../Progressing.ascx" TagName="Progressing" TagPrefix="uc111" %>

<link href="../../CSS/style.css" rel="stylesheet" type="text/css" />
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
                            <uc3:OtherStatisticsDataView id="OtherStatisticsDataView1" runat="server">
                        </uc3:OtherStatisticsDataView>
                    </td>
                </tr>
            </table>
            </td>
        <td width="75%" valign="top" style="height: 512px;">
            <table width="100%" style="text-align:left">
                <tr>
                    <td colspan="2">
                        <uc10:ComeAndLeaveTableView ID="ComeAndLeaveTableView1" runat="server" />
                        </td>
                </tr>

                <tr>
                    <td colspan="2">
                        <uc4:ComeAndLeaveBarChartView id="ComeAndLeaveBarChartView1" runat="server">
                        </uc4:ComeAndLeaveBarChartView></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <uc5:LeaveRateLineChartView ID="LeaveRateLineChartView1" runat="server" />
                        
                    </td>
                </tr>
                <tr>
                    <td>
                        <uc2:GenderPieChartView ID="GenderPieChartView1" runat="server" />
                        
                    </td>
                    <td>
                        <uc6:EduBgPieChartView id="EduBgPieChartView1" runat="server">
                        </uc6:EduBgPieChartView>
                        
                    </td>
                </tr>
                <tr>
                    <td>
                        <uc9:WorkAgePieChartView ID="WorkAgePieChartView1" runat="server" />
                        
                    </td>
                    <td>
                        <uc8:AgePieChartView ID="AgePieChartView1" runat="server" />
                        </td>
                </tr>
                <tr>
                    <td>
                        <uc7:WorkTypePieChartView ID="WorkTypePieChartView1" runat="server" />
                        
                    </td>
                    <td>
                        <uc11:PositionGradeTowerTableView ID="PositionGradeTowerTableView1" runat="server" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
   
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <uc111:Progressing id="Progressing1" runat="server">
                </uc111:Progressing>
            </ProgressTemplate>
        </asp:UpdateProgress>
</ContentTemplate>
</asp:UpdatePanel>
