<%@ Page Language="C#" MasterPageFile="~/Pages/HRMIS/MainPages/HRMISMaster.Master" AutoEventWireup="true" CodeBehind="ContractTypeList.aspx.cs" Inherits="SEP.Performance.Pages.ContractTypeList" %>

<%@ Register Src="../../../Views/HRMIS/ContractType/ContractTypeInfoView.ascx" TagName="ContractTypeInfoView"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
        <uc1:ContractTypeInfoView ID="ContractTypeInfoView1" runat="server" />
</asp:Content>