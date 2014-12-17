<%@ Page Language="C#" MasterPageFile="~/Pages/HRMIS/MainPages/HRMISMaster.Master" AutoEventWireup="true" CodeBehind="EmployeeContractSearch.aspx.cs" Inherits="SEP.Performance.Pages.EmployeeContractSearch" %>

<%@ Register Src="../../../Views/HRMIS/Employee/ContractSearchView.ascx" TagName="ContractSearchView"
    TagPrefix="uc1" %>
    
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">

    <div>
    <uc1:ContractSearchView id="ContractSearchView1" runat="server">
    </uc1:ContractSearchView>
     </div>
     <asp:Button ID="btnExportServer" runat="server" Text="Button" OnClick="btnExportServer_Click" style="display:none;"/>
</asp:Content>             