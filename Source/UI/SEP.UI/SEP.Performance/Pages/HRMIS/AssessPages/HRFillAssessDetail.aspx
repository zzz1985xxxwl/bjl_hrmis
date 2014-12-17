<%@ Page Language="C#" MasterPageFile="../MainPages/HRMISMaster.Master" AutoEventWireup="true"
    Codebehind="HRFillAssessDetail.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.AssessPages.HRFillAssessDetail" %>

<%@ Register Src="../../../Views/HRMIS/AssessActivity/AssessAnswerView.ascx" TagName="AssessAnswerView"
    TagPrefix="uc1" %>
<%@ Register Src="../../../Views/HRMIS/AssessActivity/AssessBasicInfoView.ascx" TagName="AssessBasicInfoView"
    TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCenter" runat="Server">
    
                <uc2:AssessBasicInfoView id="AssessBasicInfoView1" runat="server">
                </uc2:AssessBasicInfoView>
                <uc1:AssessAnswerView id="AssessAnswerView1" runat="server">
                </uc1:AssessAnswerView>
</asp:Content>
