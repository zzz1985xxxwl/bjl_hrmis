<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MainPages/HRMISMaster.Master" CodeBehind="UpdateOverWork.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.OverWorkPages.UpdateOverWork" %>

<%@ Register Src="../../../Views/HRMIS/OverWorks/OverWorkEditView.ascx"
    TagName="OverWorkEditView" TagPrefix="uc1" %>
<asp:Content ID="cphCenter" ContentPlaceHolderID="cphCenter" runat="Server">
        <uc1:OverWorkEditView id="OverWorkEditView1" runat="server">
        </uc1:OverWorkEditView>
</asp:Content>

