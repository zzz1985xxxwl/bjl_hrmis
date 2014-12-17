<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MainPages/HRMISMaster.Master" CodeBehind="ReimburseDetailBack.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.ReimbursePages.ReimburseDetailBack" %>

<%@ Register Src="../../../Views/HRMIS/Reimburse/EmployeeReimburseView.ascx" TagName="EmployeeReimburseView"
    TagPrefix="uc1" %>

<asp:Content ID="cphPage" ContentPlaceHolderID="cphCenter" Runat="Server">
        <uc1:EmployeeReimburseView ID="EmployeeReimburseView1" runat="server" />
    
</asp:Content>
