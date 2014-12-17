<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MainPages/HRMISMaster.Master" CodeBehind="DepartmentDistribution.aspx.cs" Inherits="SEP.Performance.Pages.DepartmentDistribution" %>

<%@ Register Src="../../../Views/HRMIS/EmployeeStatistics/DepartmentDistributionView.ascx" TagName="DepartmentDistributionView"
    TagPrefix="uc1" %>
<asp:Content ID="cphCenter" ContentPlaceHolderID="cphCenter" Runat="Server">
    <uc1:DepartmentDistributionView id="DepartmentDistributionView1" runat="server">
    </uc1:DepartmentDistributionView>
</asp:Content>