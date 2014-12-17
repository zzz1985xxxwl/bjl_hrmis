<%@ Page Language="C#" MasterPageFile="../MainPages/HRMISMaster.Master" AutoEventWireup="true"
    Codebehind="HRManualAssess.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.AssessPages.HRManualAssess" %>

<%@ Register Src="../../../Views/HRMIS/AssessActivity/ManualAssessView.ascx" TagName="ManualAssessView"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCenter" runat="Server">
        <uc1:ManualAssessView id="ManualAssessView1" runat="server">
        </uc1:ManualAssessView>
</asp:Content>
