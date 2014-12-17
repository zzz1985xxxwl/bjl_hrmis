<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InAndOutLogList.aspx.cs" MasterPageFile="../MainPages/HRMISMaster.Master" Inherits="SEP.Performance.Pages.HRMIS.AttendancePages.InAndOutLogList" %>

<%@ Register Src="../../../Views/HRMIS/AttendanceStatistics/AttendanceInAndOutStatistics/InAndOutLogListView.ascx"
    TagName="InAndOutLogListView" TagPrefix="uc1" %>

<asp:Content ID="cphCenter" ContentPlaceHolderID="cphCenter" runat="Server">
    <uc1:InAndOutLogListView ID="InAndOutLogListView1" runat="server" />
</asp:Content>