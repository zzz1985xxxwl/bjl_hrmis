<%@ Page Language="C#" MasterPageFile="../MainPages/HRMISMaster.Master" AutoEventWireup="true" CodeBehind="PersonalFillAssess.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.AssessPages.PersonalFillAssess" %>
<%@ Register Src="../../../Views/HRMIS/AssessActivity/AssessBasicInfoView.ascx" TagName="AssessBasicInfoView"
    TagPrefix="uc1" %>
<%@ Register Src="../../../Views/HRMIS/AssessActivity/AssessAnswerView.ascx" TagName="AssessAnswerView"
    TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCenter" runat="Server">
   
                <uc1:AssessBasicInfoView id="AssessBasicInfoView1" runat="server">
                </uc1:AssessBasicInfoView>
                <uc2:AssessAnswerView id="AssessAnswerView1" runat="server">
                </uc2:AssessAnswerView>
</asp:Content>