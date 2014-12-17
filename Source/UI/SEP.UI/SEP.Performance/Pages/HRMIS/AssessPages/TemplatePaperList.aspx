<%@ Page Language="C#" MasterPageFile="../MainPages/HRMISMaster.Master" AutoEventWireup="true" CodeBehind="TemplatePaperList.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.AssessPages.TemplatePaperList" %>

<%@ Register Src="../../../Views/HRMIS/AssessManagement/TemplatePaperListView.ascx"
    TagName="TemplatePaperListView" TagPrefix="uc2" %>

<%@ Register Src="../../../Views/HRMIS/AssessManagement/TemplatePaperInfoView.ascx"
    TagName="TemplatePaperInfoView" TagPrefix="uc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
    <uc2:TemplatePaperListView ID="TemplatePaperListView1" runat="server" />
</asp:Content>


