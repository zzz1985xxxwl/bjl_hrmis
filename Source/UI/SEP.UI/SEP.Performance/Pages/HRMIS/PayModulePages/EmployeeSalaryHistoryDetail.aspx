<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MainPages/HRMISMaster.Master" CodeBehind="EmployeeSalaryHistoryDetail.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.PayModulePages.EmployeeSalaryHistoryDetail" %>

<%@ Register Src="../../../Views/HRMIS/PayModuleViews/EmployeeAccountSet/EmployeeSalaryHistoryDetailView.ascx"
    TagName="EmployeeSalaryHistoryDetailView" TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
    <uc1:EmployeeSalaryHistoryDetailView ID="EmployeeSalaryHistoryDetailView1" runat="server" />


</asp:Content>