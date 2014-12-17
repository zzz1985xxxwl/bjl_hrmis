<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MasterPage.Master" CodeBehind="EditCompanyRegulation.aspx.cs" Inherits="SEP.Performance.Pages.SEP.CompanyRegulationsPages.EditCompanyRegulation" %>

<%@ Register Src="../../../Views/SEP/CompanyRegulations/EditCompanyRegulationsView.ascx"
    TagName="EditCompanyRegulationsView" TagPrefix="uc1" %>
<asp:Content ID="EditCompanyRegulationContent" runat="server" ContentPlaceHolderID="cphCenter">
    <uc1:EditCompanyRegulationsView ID="EditCompanyRegulationsView1" runat="server" />
</asp:Content>

