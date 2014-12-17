<%@ Page Language="C#" MasterPageFile="../MainPages/HRMISMaster.Master" AutoEventWireup="true" CodeBehind="ManualAssessBackDetail.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.AssessPages.ManualAssessBackDetail" %>

<%@ Register Src="../../../Views/HRMIS/AssessActivity/ManualAssessView.ascx" TagName="ManualAssessView"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCenter" Runat="Server">
    <uc1:ManualAssessView id="ManualAssessView1" runat="server">
    </uc1:ManualAssessView>
</asp:Content>
