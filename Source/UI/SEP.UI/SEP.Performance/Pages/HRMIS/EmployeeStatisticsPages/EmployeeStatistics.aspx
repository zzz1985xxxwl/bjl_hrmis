<%@ Page Language="C#" MasterPageFile="~/Pages/HRMIS/MainPages/HRMISMaster.Master" AutoEventWireup="true" CodeBehind="EmployeeStatistics.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.EmployeeStatisticsPages.EmployeeStatistics" %>

<%@ Register Src="../../../Views/HRMIS/EmployeeStatistics/CommonStatisticsView.ascx" TagName="CommonStatisticsView"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
        <uc1:CommonStatisticsView ID="CommonStatisticsView1" runat="server" />
</asp:Content>   