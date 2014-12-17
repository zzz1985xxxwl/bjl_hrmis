<%@ Page Language="C#" MasterPageFile="../MainPages/HRMISMaster.Master" AutoEventWireup="true" CodeBehind="ManagerApplyEmployeeAssess.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.AssessPages.ManagerApplyEmployeeAssess" %>

<%@ Register Src="../../../Views/HRMIS/AssessActivity/GetEmployeeForApplyView.ascx"
    TagName="GetEmployeeForApplyView" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCenter" Runat="Server">
    <uc1:GetEmployeeForApplyView id="GetEmployeeForApplyView1" runat="server">
    </uc1:GetEmployeeForApplyView>
</asp:Content>
