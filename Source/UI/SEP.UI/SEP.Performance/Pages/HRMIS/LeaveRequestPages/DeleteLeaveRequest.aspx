﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteLeaveRequest.aspx.cs" MasterPageFile="~/Pages/HRMIS/MainPages/HRMISMaster.Master"
Inherits="SEP.Performance.Pages.HRMIS.LeaveRequestPages.DeleteLeaveRequest" %>

<%@ Register Src="../../../Views/HRMIS/LeaveRequests/LeaveRequestView.ascx" TagName="LeaveRequestView"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
        <uc1:LeaveRequestView ID="LeaveRequestView1" runat="server" />
</asp:Content>
