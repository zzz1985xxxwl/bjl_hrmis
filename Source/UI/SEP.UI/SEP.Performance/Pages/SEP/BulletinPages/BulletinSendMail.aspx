<%@ Page  Async="true" Language="C#" AutoEventWireup="true"  MasterPageFile="../MasterPage.Master"  CodeBehind="BulletinSendMail.aspx.cs" Inherits="SEP.Performance.Pages.SEP.BulletinPages.BulletinSendMail" %>
<%@ Register Src="../../../Views/SEP/Bulletins/BulletinSendMailView.ascx" TagName="BulletinSendMailView"
    TagPrefix="uc1" %>
<asp:Content ID="cphCenter" ContentPlaceHolderID="cphCenter" Runat="Server">
<uc1:BulletinSendMailView id="userControlBulletinSendMailView" runat="server"/>
</asp:Content>