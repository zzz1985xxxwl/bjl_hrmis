<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MainPages/HRMISMaster.Master" CodeBehind="FeedBackPaperList.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.TrainingPages.FeedBackPaperList" %>

<%@ Register Src="../../../Views/HRMIS/Train/FeedBackPaperListView.ascx" TagName="FeedBackPaperListView"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
    <uc1:FeedBackPaperListView ID="FeedBackPaperListView1" runat="server" />

</asp:Content>