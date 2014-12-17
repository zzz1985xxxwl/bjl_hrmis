<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeAttendanceSearch.aspx.cs" MasterPageFile="../MainPages/HRMISMaster.Master" Inherits="SEP.Performance.Pages.HRMIS.AttendancePages.EmployeeAttendanceSearch" %>

<%@ Register Src="../../../Views/HRMIS/EmployeeAttendance/AttendanceInfoView.ascx" TagName="AttendanceInfoView"
    TagPrefix="uc1" %>
    
<asp:Content ID="cphCenter" ContentPlaceHolderID="cphCenter" runat="Server">
        <uc1:AttendanceInfoView ID="AttendanceInfoView1" runat="server" />
</asp:Content>