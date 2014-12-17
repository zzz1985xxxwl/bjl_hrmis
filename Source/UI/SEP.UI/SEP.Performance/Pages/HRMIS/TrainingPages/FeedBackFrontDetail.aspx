<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MainPages/HRMISMaster.Master" CodeBehind="FeedBackFrontDetail.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.TrainingPages.FeedBackFrontDetail" %>

<%@ Register Src="../../../Views/HRMIS/Train/FeedBackDetailView.ascx" TagName="FeedBackDetailView"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>  
        <uc1:FeedBackDetailView ID="FeedBackDetailView1" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
