<%@ Page Language="C#" MasterPageFile="~/Pages/HRMIS/MainPages/HRMISMaster.Master" AutoEventWireup="true" CodeBehind="EmplyeeHistoryDetail.aspx.cs" Inherits="SEP.Performance.Pages.EmplyeeHistoryDetail" %>

<%@ Register Src="../../../Views/HRMIS/EmployeeHistory/EmployeeHistoryView.ascx"
    TagName="EmployeeHistoryView" TagPrefix="uc1" %>



<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
    <uc1:EmployeeHistoryView id="EmployeeHistoryView1" runat="server">
    </uc1:EmployeeHistoryView>

</asp:Content>        