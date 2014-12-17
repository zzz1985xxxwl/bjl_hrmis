<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="../MainPages/HRMISMaster.Master" CodeBehind="ConfirmOutApplicationItem.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.OutApplicationPages.ConfirmOutApplicationItem" %>


<%@ Register Src="../../../Views/HRMIS/OutApplications/CancelOutApplicationItemView.ascx"
    TagName="CancelOutApplicationItemView" TagPrefix="uc1" %>
<asp:Content ID="cphCenter" ContentPlaceHolderID="cphCenter" runat="Server">
        <uc1:CancelOutApplicationItemView id="CancelOutApplicationItemView1" runat="server">
        </uc1:CancelOutApplicationItemView>
</asp:Content>
