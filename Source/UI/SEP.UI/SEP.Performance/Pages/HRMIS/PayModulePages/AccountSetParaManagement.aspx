<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountSetParaManagement.aspx.cs" MasterPageFile="../MainPages/HRMISMaster.Master" Inherits="SEP.Performance.Pages.HRMIS.PayModulePages.AccountSetParaManagement" %>

<%@ Register Src="../../../Views/HRMIS/PayModuleViews/AccountSet/ManageAccountSetParaView.ascx"
    TagName="ManageAccountSetParaView" TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
    <uc1:ManageAccountSetParaView ID="ManageAccountSetParaView1" runat="server" />

</asp:Content>
