<%@ Page Language="C#" MasterPageFile="../MainPages/HRMISMaster.Master" AutoEventWireup="true" CodeBehind="GetConfirmAssesses.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.AssessPages.GetConfirmAssesses" %>

<%@ Register Src="../../../Views/HRMIS/AssessActivity/GetConfirmAssessesView.ascx"
    TagName="GetConfirmAssessesView" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphCenter" Runat="Server">
    <uc1:GetConfirmAssessesView id="GetConfirmAssessesView1" runat="server">
    </uc1:GetConfirmAssessesView>
</asp:Content>
