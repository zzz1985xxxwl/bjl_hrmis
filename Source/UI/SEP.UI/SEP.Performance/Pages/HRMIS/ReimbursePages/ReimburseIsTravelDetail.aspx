<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReimburseIsTravelDetail.aspx.cs" MasterPageFile="../MainPages/HRMISMaster.Master"  Inherits="SEP.Performance.Pages.HRMIS.ReimbursePages.ReimburseIsTravelDetail" %>

<%@ Register Src="../../../Views/HRMIS/Reimburse/EmployeeReimburseView.ascx" TagName="EmployeeReimburseView"
    TagPrefix="uc1" %>

<asp:Content ID="cphPage" ContentPlaceHolderID="cphCenter" Runat="Server">
    <uc1:EmployeeReimburseView id="EmployeeReimburseView1" runat="server">
    </uc1:EmployeeReimburseView>
</asp:Content>
