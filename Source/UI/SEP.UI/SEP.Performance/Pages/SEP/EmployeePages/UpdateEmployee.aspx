<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MasterPage.Master" CodeBehind="UpdateEmployee.aspx.cs" Inherits="SEP.Performance.Pages.SEP.EmployeePages.UpdateEmployee" %>

<%@ Register Src="../../../Views/SEP/Employees/EmployeeDetailView.ascx" TagName="EmployeeDetailView"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
     <uc1:EmployeeDetailView ID="EmployeeDetailView1" runat="server" />
</asp:Content>