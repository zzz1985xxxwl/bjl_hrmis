<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MasterPage.Master"
    Codebehind="AssignAuth.aspx.cs" Inherits="SEP.Performance.Pages.AssignAuth"
    EnableEventValidation="false" EnableViewStateMac="false" ViewStateEncryptionMode="Never" %>

<%@ Register Src="../../../Views/SEP/Accounts/AssignSEPAuthInfoView.ascx" TagName="AssignSEPAuthInfoView"
    TagPrefix="uc1" %>

<asp:Content ID="SEPAssignAuth" ContentPlaceHolderID="cphCenter" runat="Server">
    <uc1:AssignSEPAuthInfoView id="AssignSEPAuthInfoView1" runat="server">
    </uc1:AssignSEPAuthInfoView>
</asp:Content>
