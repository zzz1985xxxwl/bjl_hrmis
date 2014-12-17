<%@ Page Language="C#" MasterPageFile="../MasterPage.Master" AutoEventWireup="true" CodeBehind="SmsCenter.aspx.cs" Inherits="SEP.Performance.Pages.SEP.ServicesPages.SmsCenter" %>

<%@ Register Src="../../../Views/SEP/Services/SmsCenter.ascx" TagName="SmsCenter"
    TagPrefix="uc1" %>
<asp:Content ID="SmsCenterContent" ContentPlaceHolderID="cphCenter" Runat="Server">
    <uc1:SmsCenter ID="SmsCenter1" runat="server" />
</asp:Content>


