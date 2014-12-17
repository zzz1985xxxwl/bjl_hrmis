<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MainPages/HRMISMaster.Master" CodeBehind="AdvancedEmployeeStatisticsFont.aspx.cs" Inherits="SEP.Performance.Pages.AdvancedEmployeeStatisticsFont" %>

<%@ Register Src="../../../Views/HRMIS/AdvancedEmployeeStatistics/AdvancedEmployeeStatisticsView.ascx" TagName="AdvancedEmployeeStatisticsView"
    TagPrefix="uc1" %>
<asp:Content ID="cphCenter" ContentPlaceHolderID="cphCenter" Runat="Server">
    <uc1:AdvancedEmployeeStatisticsView id="AdvancedEmployeeStatisticsView1" runat="server">
    </uc1:AdvancedEmployeeStatisticsView>
</asp:Content>