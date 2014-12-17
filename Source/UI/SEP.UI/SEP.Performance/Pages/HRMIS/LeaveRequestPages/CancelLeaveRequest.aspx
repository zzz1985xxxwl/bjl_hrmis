<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CancelLeaveRequest.aspx.cs" MasterPageFile="../MainPages/HRMISMaster.Master"
Inherits="SEP.Performance.Pages.HRMIS.LeaveRequestPages.CancelLeaveRequest" %>

<%@ Register Src="../../../Views/HRMIS/LeaveRequests/CancelLeaveRequestItemView.ascx"
    TagName="CancelLeaveRequestItemView" TagPrefix="uc2" %>

<%@ Register Src="../../../Views/HRMIS/LeaveRequests/LeaveRequestView.ascx" TagName="LeaveRequestView"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
    <uc2:CancelLeaveRequestItemView id="CancelLeaveRequestItemView1" runat="server">
    </uc2:CancelLeaveRequestItemView>
</asp:Content>
