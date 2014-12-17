<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MainPages/HRMISMaster.Master" CodeBehind="CourseFeedBackList.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.TrainingPages.CourseFeedBackList" %>

<%@ Register Src="../../../Views/HRMIS/Train/FeedBackBackSearchView.ascx" TagName="FeedBackBackSearchView"
    TagPrefix="uc1" %>
    <asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>  
<uc1:FeedBackBackSearchView ID="FeedBackBackSearchView1" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>  



