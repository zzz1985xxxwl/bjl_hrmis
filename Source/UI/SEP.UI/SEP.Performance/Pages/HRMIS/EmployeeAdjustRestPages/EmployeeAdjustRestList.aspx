<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MainPages/HRMISMaster.Master" CodeBehind="EmployeeAdjustRestList.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.EmployeeAdjustRestPages.EmployeeAdjustRestList" %>

<%@ Register Src="../../../Views/HRMIS/EmployeeAdjustRest/EmployeeAdjustRestListView.ascx"
    TagName="EmployeeAdjustRestListView" TagPrefix="uc1" %>

<asp:Content ID="cphCenter" ContentPlaceHolderID="cphCenter" runat="Server">
        <uc1:EmployeeAdjustRestListView id="EmployeeAdjustRestListView1" runat="server">
        </uc1:EmployeeAdjustRestListView>
</asp:Content>