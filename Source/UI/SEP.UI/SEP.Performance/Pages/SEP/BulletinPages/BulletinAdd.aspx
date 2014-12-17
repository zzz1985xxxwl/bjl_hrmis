<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MasterPage.Master"  CodeBehind="BulletinAdd.aspx.cs" Inherits="SEP.Performance.Pages.SEP.BulletinPages.BulletinAdd" %>
<%@ Register Src="../../../Views/SEP/Bulletins/EditBulletinView.ascx" TagName="EditBulletinView"
    TagPrefix="uc1" %>
<asp:Content ID="cphCenter" ContentPlaceHolderID="cphCenter" Runat="Server">
  <uc1:EditBulletinView id="userControlEditBulletinView" runat="server"/>
</asp:Content>