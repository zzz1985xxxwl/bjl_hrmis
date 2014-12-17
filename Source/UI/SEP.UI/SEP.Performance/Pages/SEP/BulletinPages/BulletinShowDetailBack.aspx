<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MasterPage.Master"  CodeBehind="BulletinShowDetailBack.aspx.cs" Inherits="SEP.Performance.Pages.SEP.BulletinPages.BulletinShowDetailBack" %>

<%@ Register Src="../../../Views/SEP/Bulletins/BulletinShowDetailView.ascx" TagName="BulletinShowDetailView"
    TagPrefix="uc1" %>
<asp:Content ID="cphCenter" ContentPlaceHolderID="cphCenter" Runat="Server">
    <uc1:BulletinShowDetailView id="userControlBulletinShowDetailView" runat="server"/>
</asp:Content>

