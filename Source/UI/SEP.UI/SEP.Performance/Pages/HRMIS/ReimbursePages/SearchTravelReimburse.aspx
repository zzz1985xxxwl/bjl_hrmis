<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchTravelReimburse.aspx.cs"  MasterPageFile="../MainPages/HRMISMaster.Master" Inherits="SEP.Performance.Pages.HRMIS.ReimbursePages.SearchTravelReimburse" %>

<%@ Register Src="../../../Views/HRMIS/Reimburse/SearchTravelReimburseView.ascx"
    TagName="SearchTravelReimburseView" TagPrefix="uc1" %>

<asp:Content ID="cphPage" ContentPlaceHolderID="cphCenter" Runat="Server">
        <uc1:SearchTravelReimburseView id="SearchTravelReimburseView1" runat="server">
        </uc1:SearchTravelReimburseView>
</asp:Content>

