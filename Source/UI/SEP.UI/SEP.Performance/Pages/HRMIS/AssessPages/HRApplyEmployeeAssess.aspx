<%@ Page Language="C#" MasterPageFile="../MainPages/HRMISMaster.Master" AutoEventWireup="true" CodeBehind="HRApplyEmployeeAssess.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.AssessPages.HRApplyEmployeeAssess" %>

<%@ Register Src="../../../Views/HRMIS/AssessActivity/GetEmployeeForApplyView.ascx"
    TagName="GetEmployeeForApplyView" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphCenter" Runat="Server">
    <uc1:GetEmployeeForApplyView ID="GetEmployeeForApplyView1" runat="server" />

</asp:Content>
