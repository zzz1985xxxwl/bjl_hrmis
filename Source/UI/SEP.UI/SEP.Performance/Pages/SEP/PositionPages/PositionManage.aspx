<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MasterPage.Master" CodeBehind="PositionManage.aspx.cs" Inherits="SEP.Performance.Pages.SEP.PositionPages.PositionManage" %>


<%@ Register Src="../../../Views/Sep/Positions/PositionListView.ascx" TagName="PositionListView"
    TagPrefix="uc1" %>

<asp:Content ID="cphCenter" ContentPlaceHolderID="cphCenter" Runat="Server">
    <uc1:PositionListView ID="PositionListView1" runat="server" />

</asp:Content>
