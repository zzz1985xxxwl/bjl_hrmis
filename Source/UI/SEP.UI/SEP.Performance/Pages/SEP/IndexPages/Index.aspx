<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MasterPage.Master"
    Codebehind="Index.aspx.cs" Inherits="SEP.Performance.Pages.SEP.IndexPages.Index" EnableEventValidation="false"
    EnableViewStateMac="false" ViewStateEncryptionMode="Never" %>

<%@ Register Src="../../../Views/SEP/Index/IndexJqWebPartView.ascx" TagName="IndexJqWebPartView"
    TagPrefix="uc1" %>
<asp:Content ID="SEPIndex" ContentPlaceHolderID="cphCenter" runat="Server">
    <uc1:IndexJqWebPartView id="IndexJqWebPartView1" runat="server">
    </uc1:IndexJqWebPartView>
</asp:Content>
