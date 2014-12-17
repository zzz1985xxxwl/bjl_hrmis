<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/HRMIS/MainPages/HRMISMaster.Master" CodeBehind="OutApplicationList.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.OutApplicationPages.OutApplicationList" %>

<%@ Register Src="../../../Views/HRMIS/OutApplications/OutApplicationListView.ascx"
    TagName="OutApplicationListView" TagPrefix="uc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
        <uc1:OutApplicationListView id="OutApplicationListView1" runat="server">
        </uc1:OutApplicationListView>
</asp:Content>
