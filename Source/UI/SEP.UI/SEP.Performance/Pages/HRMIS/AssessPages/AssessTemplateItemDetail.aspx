<%@ Page Language="C#" MasterPageFile="../MainPages/HRMISMaster.Master" AutoEventWireup="true" CodeBehind="AssessTemplateItemDetail.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.AssessPages.AssessTemplateItemDetail" %>

<%@ Register Src="../../../Views/HRMIS/AssessManagement/AddTemplateItemView.ascx"
    TagName="AddTemplateItemView" TagPrefix="uc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
    <uc1:AddTemplateItemView ID="AddTemplateItemView1" runat="server" />
</asp:Content>


