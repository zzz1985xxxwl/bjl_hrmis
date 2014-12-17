<%@ Page Language="C#" MasterPageFile="../MainPages/HRMISMaster.Master" AutoEventWireup="true" CodeBehind="DECEmployeeSalary.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.PayModulePages.DECEmployeeSalary" %>

<%@ Register Src="../../../Views/HRMIS/PayModuleViews/EmployeeSalarySet/DECEmployeeSalaryView.ascx"
    TagName="DECEmployeeSalaryView" TagPrefix="uc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
    <uc1:DECEmployeeSalaryView ID="DECEmployeeSalaryView1" runat="server" />

</asp:Content>

