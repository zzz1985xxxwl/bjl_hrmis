﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MainPages/HRMISMaster.Master" CodeBehind="UpdateOutApplication.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.OutApplicationPages.UpdateOutApplication" %>
<%@ Register Src="../../../Views/HRMIS/OutApplications/OutApplicationEditView.ascx"
    TagName="OutApplicationEditView" TagPrefix="uc1" %>
<asp:Content ID="cphCenter" ContentPlaceHolderID="cphCenter" runat="Server">
        <uc1:OutApplicationEditView id="OutApplicationEditView1" runat="server">
        </uc1:OutApplicationEditView>
</asp:Content>

