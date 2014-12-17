<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MainPages/HRMISMaster.Master"  CodeBehind="ConfirmOverWorkItem.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.OverWorkPages.ConfirmOverWorkItem" %>

<%@ Register Src="../../../Views/HRMIS/OverWorks/CancelOverWorkItemView.ascx"
    TagName="CancelOverWorkItemView" TagPrefix="uc1" %>
<asp:Content ID="cphCenter" ContentPlaceHolderID="cphCenter" runat="Server">
        <uc1:CancelOverWorkItemView id="CancelOverWorkItemView1" runat="server">
        </uc1:CancelOverWorkItemView>
</asp:Content>
