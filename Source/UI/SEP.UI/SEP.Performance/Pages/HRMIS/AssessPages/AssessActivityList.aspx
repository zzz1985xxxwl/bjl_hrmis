﻿<%@ Page Language="C#" MasterPageFile="../MainPages/HRMISMaster.Master" AutoEventWireup="true" CodeBehind="AssessActivityList.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.AssessPages.AssessActivityList" %>

<%@ Register Src="../../../Views/HRMIS/AssessActivity/AssessActivityListView.ascx"
    TagName="AssessActivityListView" TagPrefix="uc1" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="cphCenter" Runat="Server">
    <uc1:AssessActivityListView id="AssessActivityListView1" runat="server">
    </uc1:AssessActivityListView>
</asp:Content>