<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApproveLeaveRequestItem.aspx.cs" MasterPageFile="../MainPages/HRMISMaster.Master"
Inherits="SEP.Performance.Pages.HRMIS.LeaveRequestPages.ApproveLeaveRequestItem" %>

<%@ Register Src="../../../Views/HRMIS/LeaveRequests/CancelLeaveRequestItemView.ascx"
    TagName="CancelLeaveRequestItemView" TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
        <uc1:CancelLeaveRequestItemView ID="CancelLeaveRequestItemView1" runat="server" />
</asp:Content>