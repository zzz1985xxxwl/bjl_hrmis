<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MainPages/HRMISMaster.Master"  CodeBehind="CustomerInfo.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.CustomerInfoPages.CustomerInfo" %>

<%@ Register Src="../../../Views/HRMIS/CustomerInfos/CustomerInfoAllView.ascx" TagName="CustomerInfoAllView"
    TagPrefix="uc1" %>


<asp:Content ID="cphCenter" ContentPlaceHolderID="cphCenter" runat="Server">
    <uc1:CustomerInfoAllView ID="CustomerInfoAllView1" runat="server" />

</asp:Content>
