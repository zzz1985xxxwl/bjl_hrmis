﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MasterPage.Master" CodeBehind="RegulationProcess.aspx.cs" Inherits="SEP.Performance.Pages.SEP.CompanyRegulationsPages.RegulationProcess" %>
<%@ Register Src="../../../Views/SEP/CompanyRegulations/LinkView.ascx" TagName="LinkView"
    TagPrefix="uc2" %>

<%@ Register Src="../../../Views/SEP/CompanyRegulations/CompanyRegulationView.ascx"
    TagName="CompanyRegulationView" TagPrefix="uc1" %>
<asp:Content ID="RegulationProcessContent" runat="server" ContentPlaceHolderID="cphCenter">
<div class="rule">
    <uc2:LinkView ID="LinkView1" runat="server" />
    <uc1:CompanyRegulationView ID="CompanyRegulationView1" runat="server" />
</div>
</asp:Content>
