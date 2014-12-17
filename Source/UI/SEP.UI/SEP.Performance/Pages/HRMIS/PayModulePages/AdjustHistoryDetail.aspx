<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdjustHistoryDetail.aspx.cs" MasterPageFile="../MainPages/HRMISMaster.Master" Inherits="SEP.Performance.Pages.HRMIS.PayModulePages.AdjustHistoryDetail" %>

<%@ Register Src="../../../Views/HRMIS/PayModuleViews/EmployeeAccountSet/AdjustHistoryDetailView.ascx"
    TagName="AdjustHistoryDetailView" TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
    <uc1:AdjustHistoryDetailView ID="AdjustHistoryDetailView1" runat="server" />

</asp:Content>

