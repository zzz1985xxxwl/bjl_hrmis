<%@ Page Language="C#" MasterPageFile="../MainPages/HRMISMaster.Master" AutoEventWireup="true" CodeBehind="ReimburseUpdate.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.ReimbursePages.ReimburseUpdate" %>

<%@ Register Src="../../../Views/HRMIS/Reimburse/EmployeeReimburseView.ascx" TagName="EmployeeReimburseView"
    TagPrefix="uc1" %>

<asp:Content ID="cphPage" ContentPlaceHolderID="cphCenter" Runat="Server">
    <uc1:EmployeeReimburseView id="EmployeeReimburseView1" runat="server">
    </uc1:EmployeeReimburseView>
</asp:Content>
