<%@ Page Language="C#"  MasterPageFile="../MainPages/HRMISMaster.Master" AutoEventWireup="true" CodeBehind="ApplicationSearch.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.AttendancePages.ApplicationSearch" %>

<%@ Register Src="../../../Views/HRMIS/AttendanceStatistics/ApplicationSearchView.ascx"
    TagName="ApplicationSearchView" TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
        <uc1:ApplicationSearchView ID="ApplicationSearchView1" runat="server" />
    </asp:Content> 
