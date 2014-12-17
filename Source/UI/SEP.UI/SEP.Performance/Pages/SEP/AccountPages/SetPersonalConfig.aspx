<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MasterPage.Master" CodeBehind="SetPersonalConfig.aspx.cs" Inherits="SEP.Performance.Pages.SEP.AccountPages.SetPersonalConfig" %>

<%@ Register Src="../../../Views/SEP/Accounts/PersonalConfigView.ascx" TagName="PersonalConfigView"
    TagPrefix="uc1" %>
<asp:Content ID="SEPSetPersonalConfig" ContentPlaceHolderID="cphCenter" runat="Server">

    <uc1:PersonalConfigView id="PersonalConfigView1" runat="server">
    </uc1:PersonalConfigView>
</asp:Content>