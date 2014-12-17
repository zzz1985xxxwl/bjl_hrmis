<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MainPages/HRMISMaster.Master" CodeBehind="OverWorkDetail.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.OverWorkPages.OverWorkDetail" %>

<%@ Register Src="../../../Views/HRMIS/OverWorks/OverWorkEditView.ascx"
    TagName="OverWorkEditView" TagPrefix="uc1" %>
    <%@ Register Src="../../../Views/HRMIS/OverWorks/OverWorkFlowListView.ascx"
    TagName="OverWorkFlowListView" TagPrefix="uc2" %>
<asp:Content ID="cphCenter" ContentPlaceHolderID="cphCenter" runat="Server">
        <uc1:OverWorkEditView id="OverWorkEditView1" runat="server">
        </uc1:OverWorkEditView>
        <div class="marginepx">
        <uc2:OverWorkFlowListView id="OverWorkFlowListView1" runat="server">
        </uc2:OverWorkFlowListView>
        </div>
</asp:Content>
