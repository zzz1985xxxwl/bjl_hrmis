<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MainPages/HRMISMaster.Master" CodeBehind="EmployeeSalaryHistoryList.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.PayModulePages.EmployeeSalaryHistoryList" %>

<%@ Register Src="../../../Views/HRMIS/PayModuleViews/EmployeeAccountSet/EmployeeSalaryHistoryListView.ascx"
    TagName="EmployeeSalaryHistoryListView" TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
    <uc1:EmployeeSalaryHistoryListView id="EmployeeSalaryHistoryListView1" runat="server">
    </uc1:EmployeeSalaryHistoryListView>
</asp:Content>