<%@ Page Language="C#" MasterPageFile="~/Pages/HRMIS/MainPages/HRMISMaster.Master" AutoEventWireup="true" CodeBehind="EmployeeContractDelete.aspx.cs" Inherits="SEP.Performance.Pages.EmployeeContractDelete" %>

<%@ Register Src="../../../Views/HRMIS/Employee/ContractWithConditionView.ascx" TagName="ContractWithConditionView"
    TagPrefix="uc2" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
        <uc2:ContractWithConditionView id="ContractWithConditionView1" runat="server"></uc2:ContractWithConditionView>

</asp:Content>           