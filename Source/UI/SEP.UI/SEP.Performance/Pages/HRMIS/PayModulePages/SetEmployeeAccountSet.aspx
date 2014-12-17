<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetEmployeeAccountSet.aspx.cs" MasterPageFile="../MainPages/HRMISMaster.Master" Inherits="SEP.Performance.Pages.HRMIS.PayModulePages.SetEmployeeAccountSet" %>

<%@ Register Src="../../../Views/HRMIS/PayModuleViews/EmployeeAccountSet/SetEmployeeAccountSet.ascx"
    TagName="SetEmployeeAccountSet" TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
    <uc1:SetEmployeeAccountSet ID="SetEmployeeAccountSet1" runat="server" />

</asp:Content>
