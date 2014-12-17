<%@ Page Language="C#" MasterPageFile="~/Pages/HRMIS/MainPages/HRMISMaster.Master" AutoEventWireup="true" CodeBehind="EmployeeUpdate.aspx.cs" Inherits="SEP.Performance.Pages.EmployeeUpdate" %>

<%@ Register Src="../../../Views/HRMIS/EmployeeInformation/EmployeeView.ascx" TagName="EmployeeView"
    TagPrefix="uc3" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
            <uc3:EmployeeView id="EmployeeView1" runat="server">
            </uc3:EmployeeView>
</asp:Content>        