<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MainPages/HRMISMaster.Master" CodeBehind="HrManagePositionApplication.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.PositionPages.HrManagePositionApplication" %>

<%@ Register Src="../../../Views/HRMIS/PositionApplications/HrPositionApplicationView.ascx"
    TagName="HrPositionApplicationView" TagPrefix="uc1" %>

<asp:Content ID="cphPage" ContentPlaceHolderID="cphCenter" Runat="Server">
        <uc1:HrPositionApplicationView id="HrPositionApplicationView1" runat="server">
        </uc1:HrPositionApplicationView>
</asp:Content>