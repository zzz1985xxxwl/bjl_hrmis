<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MainPages/HRMISMaster.Master" CodeBehind="MyFeedBack.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.TrainingPages.MyFeedBack" %>

<%@ Register Src="../../../Views/HRMIS/Train/MyFeedBackView.ascx" TagName="MyFeedBackView"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
        <uc1:MyFeedBackView ID="MyFeedBackView1" runat="server" />
</asp:Content>