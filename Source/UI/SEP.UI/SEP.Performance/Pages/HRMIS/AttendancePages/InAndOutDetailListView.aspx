<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InAndOutDetailListView.aspx.cs" MasterPageFile="../MainPages/HRMISMaster.Master" Inherits="SEP.Performance.Pages.HRMIS.AttendancePages.InAndOutDetailListView" %>

<%@ Register Src="../../../Views/HRMIS/AttendanceStatistics/AttendanceInAndOutStatistics/PersonalInAndOutInfoView.ascx"
    TagName="PersonalInAndOutInfoView" TagPrefix="uc1" %>

<asp:Content ID="cphCenter" ContentPlaceHolderID="cphCenter" runat="Server">
    <uc1:PersonalInAndOutInfoView ID="PersonalInAndOutInfoView1" runat="server" />
</asp:Content>
