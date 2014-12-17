<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" MasterPageFile="../MasterPage.Master"
Inherits="SEP.Performance.Pages.SEP.AccountPages.ChangePassword" %>

<%@ Register Src="../../../Views/SEP/Accounts/ChangePasswordView.ascx" TagName="ChangePasswordView"
    TagPrefix="uc1" %>

<asp:Content ID="SEPAssignAuth" ContentPlaceHolderID="cphCenter" runat="Server">
        <uc1:ChangePasswordView id="ChangePasswordView1" runat="server">
        </uc1:ChangePasswordView>
</asp:Content>
