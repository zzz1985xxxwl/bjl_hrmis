<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyLeaveRequest.aspx.cs" MasterPageFile="~/Pages/HRMIS/MainPages/HRMISMaster.Master"
 Inherits="SEP.Performance.Pages.HRMIS.LeaveRequestPages.MyLeaveRequest" %>
<%@ Register Src="../../../Views/HRMIS/LeaveRequests/MyLeaveRequestInfoView.ascx"
    TagName="MyLeaveRequestInfoView" TagPrefix="uc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
    <uc1:MyLeaveRequestInfoView id="MyLeaveRequestInfoView1" runat="server">
    </uc1:MyLeaveRequestInfoView>
</asp:Content>