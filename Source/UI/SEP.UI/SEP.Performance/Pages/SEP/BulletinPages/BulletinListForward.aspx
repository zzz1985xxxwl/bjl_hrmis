<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MasterPage.Master"  CodeBehind="BulletinListForward.aspx.cs" Inherits="SEP.Performance.Pages.SEP.BulletinPages.BulletinListForward" %>

<%@ Register Src="../../../Views/SEP/Bulletins/BulletinListForwardView.ascx" TagName="BulletinListForwardView"
    TagPrefix="uc1" %>
<asp:Content ID="cphCenter" ContentPlaceHolderID="cphCenter" Runat="Server">
<uc1:BulletinListForwardView id="userControlBulletinListForwardView" runat="server"/>
</asp:Content>

