﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MainPages/HRMISMaster.Master" CodeBehind="FeedBackPaperAdd.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.TrainingPages.FeedBackPaperAdd" %>

<%@ Register Src="../../../Views/HRMIS/Train/FeedBackPaperView.ascx" TagName="FeedBackPaperView"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
    <uc1:FeedBackPaperView id="FeedBackPaperView1" runat="server">
    </uc1:FeedBackPaperView>

</asp:Content>
