<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MainPages/HRMISMaster.Master"  CodeBehind="FillFeedBackFront.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.TrainingPages.FillFeedBackFront" %>

<%@ Register Src="../../../Views/HRMIS/Train/FeedBackDetailView.ascx" TagName="FeedBackDetailView"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
        <uc1:FeedBackDetailView ID="FeedBackDetailView1" runat="server" />
</asp:Content>
