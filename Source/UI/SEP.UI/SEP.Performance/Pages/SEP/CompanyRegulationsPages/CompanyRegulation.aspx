<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MasterPage.Master" CodeBehind="CompanyRegulation.aspx.cs" Inherits="SEP.Performance.Pages.SEP.CompanyRegulationsPages.CompanyRegulation" %>

<%@ Register Src="../../../Views/SEP/CompanyRegulations/LinkView.ascx" TagName="LinkView"
    TagPrefix="uc2" %>

<%@ Register Src="../../../Views/SEP/CompanyRegulations/CompanyRegulationView.ascx"
    TagName="CompanyRegulationView" TagPrefix="uc1" %>
<asp:Content ID="CompanyRegulationContent" runat="server" ContentPlaceHolderID="cphCenter">
<div class="rule">
    <uc2:LinkView ID="LinkView1" runat="server" />
			<div class="ruleright">
				<div class="ruletitle">title</div>
				<div class="rulecon">
				  <p>Content</p>
				</div>
			</div>
</div>
</asp:Content>
