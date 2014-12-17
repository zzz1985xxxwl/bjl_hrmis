<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MainPages/HRMISMaster.Master" CodeBehind="AdjustSalaryHistoryList.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.PayModulePages.AdjustSalaryHistoryList" %>
<%@ Register Src="../../../Views/HRMIS/PayModuleViews/EmployeeAccountSet/AdjustHistoryListView.ascx" TagName="AdjustHistoryListView" TagPrefix="uc2" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
<uc2:AdjustHistoryListView id="AdjustHistoryListView1" runat="server"></uc2:AdjustHistoryListView>
</asp:Content>

