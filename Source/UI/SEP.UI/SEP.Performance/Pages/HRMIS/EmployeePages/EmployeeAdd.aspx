<%@ Page Language="C#" MasterPageFile="~/Pages/HRMIS/MainPages/HRMISMaster.Master" AutoEventWireup="true" CodeBehind="EmployeeAdd.aspx.cs" Inherits="SEP.Performance.Pages.EmployeeAdd" %>
<%@ Register Src="../../../Views/HRMIS/EmployeeInformation/EmployeeView.ascx" TagName="EmployeeView"
    TagPrefix="uc3" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
            <uc3:EmployeeView ID="EmployeeView1" runat="server" />
</asp:Content>        