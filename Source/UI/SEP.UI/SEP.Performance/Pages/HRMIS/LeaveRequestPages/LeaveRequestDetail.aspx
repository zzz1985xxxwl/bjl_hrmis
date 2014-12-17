<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeaveRequestDetail.aspx.cs" MasterPageFile="~/Pages/HRMIS/MainPages/HRMISMaster.Master"
Inherits="SEP.Performance.Pages.HRMIS.LeaveRequestPages.LeaveRequestDetail" %>

<%@ Register Src="../../../Views/HRMIS/LeaveRequests/LeaveRequestItemHistoryView.ascx"
    TagName="LeaveRequestItemHistoryView" TagPrefix="uc2" %>

<%@ Register Src="../../../Views/HRMIS/LeaveRequests/LeaveRequestView.ascx" TagName="LeaveRequestView"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
        <uc1:LeaveRequestView ID="LeaveRequestView1" runat="server" />
    <uc2:LeaveRequestItemHistoryView ID="LeaveRequestItemHistoryView1" runat="server" />
</asp:Content>
