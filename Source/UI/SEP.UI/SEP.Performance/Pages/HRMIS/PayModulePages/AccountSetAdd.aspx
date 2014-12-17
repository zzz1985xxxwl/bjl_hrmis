<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountSetAdd.aspx.cs" MasterPageFile="../MainPages/HRMISMaster.Master" Inherits="SEP.Performance.Pages.HRMIS.PayModulePages.AccountSetAdd" %>

<%@ Register Src="../../../Views/HRMIS/PayModuleViews/AccountSet/AccountSetView.ascx" TagName="AccountSetView"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
    <uc1:AccountSetView ID="AccountSetView1" runat="server" />

</asp:Content>

