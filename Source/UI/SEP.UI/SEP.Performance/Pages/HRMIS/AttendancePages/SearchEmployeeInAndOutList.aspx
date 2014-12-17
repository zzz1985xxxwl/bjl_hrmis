<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchEmployeeInAndOutList.aspx.cs" MasterPageFile="../MainPages/HRMISMaster.Master" Inherits="SEP.Performance.Pages.HRMIS.AttendancePages.SearchEmployeeInAndOutList" %>

<%@ Register Src="../../../Views/HRMIS/AttendanceStatistics/AttendanceInAndOutStatistics/PersonalInAndOutInfoView.ascx"
    TagName="PersonalInAndOutInfoView" TagPrefix="uc1" %>
<asp:Content ID="cphCenter" ContentPlaceHolderID="cphCenter" runat="Server">
    <uc1:PersonalInAndOutInfoView id="PersonalInAndOutInfoView1" runat="server">
    </uc1:PersonalInAndOutInfoView>
</asp:Content>
