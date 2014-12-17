<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddLeaveRequest.aspx.cs" MasterPageFile="../MainPages/HRMISMaster.Master"
Inherits="SEP.Performance.Pages.HRMIS.LeaveRequestPages.AddLeaveRequest" %>

<%@ Register Src="../../../Views/HRMIS/LeaveRequests/LeaveRequestView.ascx" TagName="LeaveRequestView"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
        <uc1:LeaveRequestView id="LeaveRequestView1" runat="server">
        </uc1:LeaveRequestView>
</asp:Content>
