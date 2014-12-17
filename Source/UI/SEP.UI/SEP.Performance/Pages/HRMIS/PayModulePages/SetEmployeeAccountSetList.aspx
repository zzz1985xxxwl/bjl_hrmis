<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetEmployeeAccountSetList.aspx.cs" MasterPageFile="../MainPages/HRMISMaster.Master" Inherits="SEP.Performance.Pages.HRMIS.PayModulePages.SetEmployeeAccountSetList" %>

<%@ Register Src="../../../Views/HRMIS/PayModuleViews/EmployeeAccountSet/SetEmployeeAccountSetList.ascx"
    TagName="SetEmployeeAccountSetList" TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
    <uc1:SetEmployeeAccountSetList id="SetEmployeeAccountSetList1" runat="server">
    </uc1:SetEmployeeAccountSetList>
</asp:Content>
