<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MainPages/HRMISMaster.Master" CodeBehind="FeedBackSearch.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.TrainingPages.FeedBackSearch" %>

<%@ Register Src="../../../Views/HRMIS/Train/FeedBackBackSearchView.ascx" TagName="FeedBackBackSearchView"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
        <uc1:FeedBackBackSearchView ID="FeedBackBackSearchView1" runat="server" />
</asp:Content>

