<%@ Page Language="C#" MasterPageFile="../MainPages/HRMISMaster.Master" AutoEventWireup="true" CodeBehind="TemplatePaperAdd.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.AssessPages.TemplatePaperAdd" %>

<%@ Register Src="../../../Views/HRMIS/AssessManagement/TemplatePaperView.ascx" TagName="TemplatePaperView"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
    <uc1:TemplatePaperView ID="TemplatePaperView1" runat="server" />
</asp:Content>
