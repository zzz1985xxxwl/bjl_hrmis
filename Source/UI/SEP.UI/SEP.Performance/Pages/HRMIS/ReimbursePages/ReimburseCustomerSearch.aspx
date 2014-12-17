<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReimburseCustomerSearch.aspx.cs" MasterPageFile="../MainPages/HRMISMaster.Master" Inherits="SEP.Performance.Pages.HRMIS.ReimbursePages.ReimburseCustomerSearch" %>

<%@ Register Src="../../../Views/HRMIS/Reimburse/ReimburseCustomerSearchView.ascx"
    TagName="ReimburseCustomerSearchView" TagPrefix="uc1" %>
<asp:Content ID="cphPage" ContentPlaceHolderID="cphCenter" Runat="Server">
    <uc1:ReimburseCustomerSearchView id="ReimburseCustomerSearchView1" runat="server">
    </uc1:ReimburseCustomerSearchView>


    
</asp:Content>
