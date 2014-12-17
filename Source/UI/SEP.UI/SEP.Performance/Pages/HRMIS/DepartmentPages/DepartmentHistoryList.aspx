<%@ Page Language="C#" MasterPageFile="~/Pages/HRMIS/MainPages/HRMISMaster.Master" AutoEventWireup="true" CodeBehind="DepartmentHistoryList.aspx.cs" Inherits="SEP.Performance.Pages.DepartmentHistoryList" %>

<%@ Register Src="../../../Views/HRMIS/DepartmentHistory/DepartmentHistoryListView.ascx"
    TagName="DepartmentHistoryListView" TagPrefix="uc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
        <uc1:DepartmentHistoryListView ID="DepartmentHistoryListView1" runat="server" />
</asp:Content>        