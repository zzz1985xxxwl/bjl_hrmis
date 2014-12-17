<%@ Page Language="C#" MasterPageFile="~/Pages/HRMIS/MainPages/HRMISMaster.Master" AutoEventWireup="true" CodeBehind="EmplyeeHistoryList.aspx.cs" Inherits="SEP.Performance.Pages.EmplyeeHistoryList" %>

<%@ Register Src="../../../Views/HRMIS/EmployeeHistory/EmployeeHistoryListView.ascx" TagName="EmployeeHistoryListView"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
        <uc1:EmployeeHistoryListView ID="EmployeeHistoryListView1" runat="server" />
</asp:Content>        