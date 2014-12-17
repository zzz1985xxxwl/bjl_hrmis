<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MasterPage.Master"  CodeBehind="BulletinListBack.aspx.cs" Inherits="SEP.Performance.Pages.SEP.BulletinPages.BulletinListBack" %>

<%@ Register Src="../../../Views/SEP/Bulletins/BulletinListBackView.ascx" TagName="BulletinListBackView"
    TagPrefix="uc1" %>

<asp:Content ID="cphCenter" ContentPlaceHolderID="cphCenter" Runat="Server">
<uc1:BulletinListBackView id="userControlBulletinListBackView" runat="server"/>
</asp:Content>




