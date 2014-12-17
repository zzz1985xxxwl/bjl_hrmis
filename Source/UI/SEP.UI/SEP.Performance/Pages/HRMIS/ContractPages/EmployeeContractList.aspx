<%@ Page Language="C#" MasterPageFile="~/Pages/HRMIS/MainPages/HRMISMaster.Master" AutoEventWireup="true" CodeBehind="EmployeeContractList.aspx.cs" Inherits="SEP.Performance.Pages.EmployeeContractList" %>

<%@ Register Src="../../../Views/HRMIS/Employee/EmployeeContractListView.ascx" TagName="EmployeeContractListView"
    TagPrefix="uc1" %>
    
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
    <uc1:EmployeeContractListView id="EmployeeContractListView1" runat="server">
    </uc1:EmployeeContractListView>
</asp:Content>            