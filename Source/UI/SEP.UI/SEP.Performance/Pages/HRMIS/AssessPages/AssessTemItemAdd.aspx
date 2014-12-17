<%@ Page Language="C#" MasterPageFile="../MainPages/HRMISMaster.Master" AutoEventWireup="true"  CodeBehind="AssessTemItemAdd.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.AssessPages.AssessTemItemAdd" %>

<%@ Register Src="../../../Views/HRMIS/AssessManagement/AddTemplateItemView.ascx" TagName="AddTemplateItemView"
    TagPrefix="uc3" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
    <uc3:AddTemplateItemView ID="AddTemplateItemView1" runat="server" />
</asp:Content>

