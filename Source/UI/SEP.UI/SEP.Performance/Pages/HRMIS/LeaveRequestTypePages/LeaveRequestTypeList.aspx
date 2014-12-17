<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MainPages/HRMISMaster.Master" CodeBehind="LeaveRequestTypeList.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.LeaveRequestTypePages.LeaveRequestTypeList" %>

<%@ Register Src="../../../Views/HRMIS/LeaveRequestTypes/LeaveRequestTypeInfoView.ascx"
    TagName="LeaveRequestTypeInfoView" TagPrefix="uc1" %>

<asp:Content ID="cphCenter" ContentPlaceHolderID="cphCenter" runat="Server">
    <uc1:LeaveRequestTypeInfoView id="LeaveRequestTypeInfoView1" runat="server">
    </uc1:LeaveRequestTypeInfoView>

</asp:Content>
