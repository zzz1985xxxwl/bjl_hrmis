<%@ Page Language="C#" MasterPageFile="../MainPages/HRMISMaster.Master" AutoEventWireup="true" CodeBehind="TemplateItemList.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.AssessPages.TemplateItemList" %>

<%@ Register Src="../../../Views/HRMIS/AssessManagement/TemplateItemListView.ascx"
    TagName="TemplateItemListView" TagPrefix="uc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
    <uc1:TemplateItemListView id="TemplateItemListView1" runat="server">
    </uc1:TemplateItemListView>
</asp:Content>


