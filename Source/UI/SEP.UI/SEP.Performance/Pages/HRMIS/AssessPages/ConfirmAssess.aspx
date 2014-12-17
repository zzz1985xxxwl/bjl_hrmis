<%@ Page Language="C#" MasterPageFile="../MainPages/HRMISMaster.Master" AutoEventWireup="true"
    Codebehind="ConfirmAssess.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.AssessPages.ConfirmAssess" %>

<%@ Register Src="../../../Views/HRMIS/AssessActivity/AssessBasicInfoView.ascx" TagName="AssessBasicInfoView"
    TagPrefix="uc1" %>
<%@ Register Src="../../../Views/HRMIS/AssessActivity/ConfirmAssessView.ascx" TagName="ConfirmAssessView"
    TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCenter" runat="Server">
   
                <uc1:AssessBasicInfoView id="AssessBasicInfoView1" runat="server">
                </uc1:AssessBasicInfoView>
                <%--<uc1:confirmassessview id="confirmAssessView" runat="server" />--%>
                <uc2:ConfirmAssessView id="ConfirmAssessView1" runat="server">
                </uc2:ConfirmAssessView>
</asp:Content>
