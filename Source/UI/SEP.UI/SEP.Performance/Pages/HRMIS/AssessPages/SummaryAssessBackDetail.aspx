<%@ Page Language="C#" MasterPageFile="../MainPages/HRMISMaster.Master" AutoEventWireup="true"
    Codebehind="SummaryAssessBackDetail.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.AssessPages.SummaryAssessBackDetail" %>

<%@ Register Src="../../../Views/HRMIS/AssessActivity/AssessBasicInfoView.ascx" TagName="AssessBasicInfoView"
    TagPrefix="uc1" %>
<%@ Register Src="../../../Views/HRMIS/AssessActivity/AssessAnswerView.ascx" TagName="AssessAnswerView"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphCenter" runat="Server">
    <uc1:AssessBasicInfoView ID="AssessBasicInfoView1" runat="server"></uc1:AssessBasicInfoView>
    <uc2:AssessAnswerView ID="AssessAnswerView1" runat="server"></uc2:AssessAnswerView>
</asp:Content>
