<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MainPages/HRMISMaster.Master" CodeBehind="UpdateReimburseCustomer.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.ReimbursePages.UpdateReimburseCustomer" %>

<%@ Register Src="../../../Views/HRMIS/Reimburse/ReimburseCustomerView.ascx" TagName="ReimburseCustomerView"
    TagPrefix="uc1" %>

<asp:Content ID="cphPage" ContentPlaceHolderID="cphCenter" Runat="Server">
    <uc1:ReimburseCustomerView ID="ReimburseCustomerView1" runat="server" />

    
</asp:Content>
