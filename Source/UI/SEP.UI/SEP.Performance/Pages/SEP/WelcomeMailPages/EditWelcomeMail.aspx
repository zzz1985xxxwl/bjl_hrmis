<%@ Page Language="C#" AutoEventWireup="true" Codebehind="EditWelcomeMail.aspx.cs"
    MasterPageFile="../MasterPage.Master" Inherits="SEP.Performance.Pages.SEP.WelcomeMailPages.EditWelcomeMail" %>

<%@ Register Src="../../../Views/SEP/WelcomeMails/EditWelcomeMailView.ascx" TagName="EditWelcomeMailView"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
    <uc1:EditWelcomeMailView ID="EditWelcomeMailView1" runat="server"></uc1:EditWelcomeMailView>
</asp:Content>
