<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MasterPage.Master" CodeBehind="FAQS.aspx.cs" Inherits="SEP.Performance.Pages.SEP.CompanyRegulationsPages.FAQS" %>
<%@ Register Src="../../../Views/SEP/CompanyRegulations/LinkView.ascx" TagName="LinkView"
    TagPrefix="uc2" %>

<%@ Register Src="../../../Views/SEP/CompanyRegulations/CompanyRegulationView.ascx"
    TagName="CompanyRegulationView" TagPrefix="uc1" %>
<asp:Content ID="FAQSContent" runat="server" ContentPlaceHolderID="cphCenter">
<div class="rule">
    <uc2:LinkView ID="LinkView1" runat="server" />
    <uc1:CompanyRegulationView ID="CompanyRegulationView1" runat="server" />
</div>
</asp:Content>
