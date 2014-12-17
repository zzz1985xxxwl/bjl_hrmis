<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountSetList.aspx.cs" MasterPageFile="../MainPages/HRMISMaster.Master" Inherits="SEP.Performance.Pages.HRMIS.PayModulePages.AccountSetList" %>

<%@ Register Src="../../../Views/HRMIS/PayModuleViews/AccountSet/AccountSetListView.ascx" TagName="AccountSetListView"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
    <uc1:AccountSetListView ID="AccountSetListView1" runat="server" />

</asp:Content>
