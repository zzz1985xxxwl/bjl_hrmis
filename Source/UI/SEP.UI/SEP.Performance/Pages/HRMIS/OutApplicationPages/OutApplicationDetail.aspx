<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MainPages/HRMISMaster.Master" CodeBehind="OutApplicationDetail.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.OutApplicationPages.OutApplicationDetail" %>

<%@ Register Src="../../../Views/HRMIS/OutApplications/OutApplicationEditView.ascx"
    TagName="OutApplicationEditView" TagPrefix="uc1" %>
    <%@ Register Src="../../../Views/HRMIS/OutApplications/OutApplicationFlowListView.ascx"
    TagName="OutApplicationFlowListView" TagPrefix="uc2" %>
<asp:Content ID="cphCenter" ContentPlaceHolderID="cphCenter" runat="Server">
        <uc1:OutApplicationEditView id="OutApplicationEditView1" runat="server">
        </uc1:OutApplicationEditView>
        <div class="marginepx">
        <uc2:OutApplicationFlowListView id="OutApplicationFlowListView1" runat="server">
        </uc2:OutApplicationFlowListView>
        </div>
</asp:Content>
