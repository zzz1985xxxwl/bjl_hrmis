<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MasterPage.Master" CodeBehind="PositionNatureManage.aspx.cs" Inherits="SEP.Performance.Pages.SEP.PositionPages.PositionNatureManage" %>

<%@ Register Src="../../../Views/SEP/Positions/PositionNatureListView.ascx" TagName="PositionNatureListView"
    TagPrefix="uc1" %>

<asp:Content ID="PositionManageContent" ContentPlaceHolderID="cphCenter" Runat="Server">
    <uc1:PositionNatureListView ID="PositionNatureListView1" runat="server" />
    <script language= "javascript" type="text/javascript" src="../../../Pages/Inc/BaseScript.js"></script>
</asp:Content>