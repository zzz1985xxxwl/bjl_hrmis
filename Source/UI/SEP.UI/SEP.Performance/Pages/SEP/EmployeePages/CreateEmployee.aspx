<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MasterPage.Master" CodeBehind="CreateEmployee.aspx.cs" Inherits="SEP.Performance.Pages.SEP.EmployeePages.CreateEmployee" %>

<%@ Register Src="../../../Views/SEP/Employees/EmployeeDetailView.ascx" TagName="EmployeeDetailView"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
        <uc1:EmployeeDetailView id="EmployeeDetailView1" runat="server">
        </uc1:EmployeeDetailView>
</asp:Content>
