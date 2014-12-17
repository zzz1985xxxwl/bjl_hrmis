<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HRMISMain.aspx.cs" MasterPageFile="HRMISMaster.Master" Inherits="SEP.Performance.Pages.HRMIS.MainPages.HRMISMain" %>


<%@ Register Src="../../../Views/HRMIS/MainPage/MainPageView.ascx"
    TagName="MainPageView" TagPrefix="uc1" %>

<asp:Content ID="cphCenter" ContentPlaceHolderID="cphCenter" runat="Server">
    <uc1:MainPageView id="MainPageView1" runat="server">
    </uc1:MainPageView>

</asp:Content>