<%@ Page Language="C#" MasterPageFile="../MainPages/HRMISMaster.Master" AutoEventWireup="true" CodeBehind="AssessBasicInfoBack.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.AssessPages.AssessBasicInfoBack" %>

<%@ Register Src="../../../Views/HRMIS/AssessActivity/AssessBasicInfoView.ascx" TagName="AssessBasicInfoView"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphCenter" Runat="Server">
    <uc1:AssessBasicInfoView id="AssessBasicInfoView1" runat="server">
    </uc1:AssessBasicInfoView>
</asp:Content>