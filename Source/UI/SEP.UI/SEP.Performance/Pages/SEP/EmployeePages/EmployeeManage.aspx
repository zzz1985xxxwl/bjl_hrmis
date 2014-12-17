<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MasterPage.Master" CodeBehind="EmployeeManage.aspx.cs" Inherits="SEP.Performance.Pages.SEP.EmployeePages.EmployeeManage" %>

<%@ Register Src="../../../Views/SEP/Employees/EmployeeDatagridListView.ascx" TagName="EmployeeDatagridListView"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
        <uc1:EmployeeDatagridListView id="EmployeeDatagridListView1" runat="server">
        </uc1:EmployeeDatagridListView>
</asp:Content>
