<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetEmployeeSalary.aspx.cs" MasterPageFile="../MainPages/HRMISMaster.Master"   Inherits="SEP.Performance.Pages.HRMIS.PayModulePages.SetEmployeeSalary" %>

<%@ Register Src="../../../Views/HRMIS/PayModuleViews/EmployeeSalarySet/SetEmployeeSalary.ascx" TagName="SetEmployeeSalary"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
    <uc1:SetEmployeeSalary id="SetEmployeeSalary1" runat="server">
    </uc1:SetEmployeeSalary>
   
</asp:Content>
