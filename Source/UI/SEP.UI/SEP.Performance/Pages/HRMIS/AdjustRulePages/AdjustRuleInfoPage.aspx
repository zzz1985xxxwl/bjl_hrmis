<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="../MainPages/HRMISMaster.Master" CodeBehind="AdjustRuleInfoPage.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.AdjustRulePages.AdjustRuleInfoPage" %>

<%@ Register Src="../../../Views/HRMIS/AdjustRules/AdjustRuleInfoView.ascx"
    TagName="AdjustRuleInfoView" TagPrefix="uc1" %>
<asp:Content ID="cphCenter" ContentPlaceHolderID="cphCenter" runat="Server">
        <uc1:AdjustRuleInfoView id="AdjustRuleInfoView1" runat="server">
        </uc1:AdjustRuleInfoView>
</asp:Content>
