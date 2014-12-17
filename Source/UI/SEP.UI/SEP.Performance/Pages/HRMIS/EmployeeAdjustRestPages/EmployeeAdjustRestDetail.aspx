<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MainPages/HRMISMaster.Master" CodeBehind="EmployeeAdjustRestDetail.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.EmployeeAdjustRestPages.EmployeeAdjustRestDetail" %>

<%@ Register Src="../../../Views/HRMIS/EmployeeAdjustRest/EmployeeAdjustRestView.ascx"
    TagName="EmployeeAdjustRestView" TagPrefix="uc1" %>

<asp:Content ID="cphCenter" ContentPlaceHolderID="cphCenter" runat="Server">
    <uc1:EmployeeAdjustRestView id="EmployeeAdjustRestView1" runat="server">
    </uc1:EmployeeAdjustRestView>
</asp:Content>