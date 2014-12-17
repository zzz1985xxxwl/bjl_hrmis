<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchReimburse.aspx.cs"  MasterPageFile="../MainPages/HRMISMaster.Master"  Inherits="SEP.Performance.Pages.HRMIS.ReimbursePages.SearchReimburse" %>

<%@ Register Src="../../../Views/HRMIS/Reimburse/SearchReimburseInfoView.ascx" TagName="SearchReimburseInfoView"
    TagPrefix="uc1" %>

<asp:Content ID="cphPage" ContentPlaceHolderID="cphCenter" Runat="Server">
<uc1:SearchReimburseInfoView id="SearchReimburseInfoView1" runat="server">
</uc1:SearchReimburseInfoView>
</asp:Content>

