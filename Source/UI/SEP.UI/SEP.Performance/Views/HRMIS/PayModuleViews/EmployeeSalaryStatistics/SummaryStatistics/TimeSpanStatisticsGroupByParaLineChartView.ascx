<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TimeSpanStatisticsGroupByParaLineChartView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.PayModuleViews.EmployeeSalaryStatistics.SummaryStatistics.TimeSpanStatisticsGroupByParaLineChartView" %>
<%@ Register Assembly="ZedGraph.Web" Namespace="ZedGraph.Web" TagPrefix="cc1" %>
<div id="divChart" runat="server">
<cc1:ZedGraphWeb ID="ZedGraphWeb1" runat="server" Height="200" RenderedImagePath="~/pages/image/imageZedGraph/" Width="750">
</cc1:ZedGraphWeb>
</div>