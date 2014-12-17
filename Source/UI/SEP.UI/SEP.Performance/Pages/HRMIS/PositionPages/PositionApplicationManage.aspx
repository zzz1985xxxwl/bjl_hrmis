<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MainPages/HRMISMaster.Master" CodeBehind="PositionApplicationManage.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.PositionPages.PositionApplicationManage" %>

<%@ Register Src="../../../Views/HRMIS/PositionApplications/PositionApplicationView.ascx"
    TagName="PositionApplicationView" TagPrefix="uc1" %>

<asp:Content ID="cphPage" ContentPlaceHolderID="cphCenter" Runat="Server">
        <uc1:PositionApplicationView id="PositionApplicationView1" runat="server">
        </uc1:PositionApplicationView>
</asp:Content>