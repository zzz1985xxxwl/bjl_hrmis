<%@ Page Language="C#" MasterPageFile="~/Pages/HRMIS/MainPages/HRMISMaster.Master" AutoEventWireup="true" CodeBehind="VacationList.aspx.cs" Inherits="SEP.Performance.Pages.VacationList" %>

<%@ Register Src="../../../Views/HRMIS/Vacation/VacationListView.ascx" TagName="VacationListView"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
    <uc1:VacationListView id="VacationListView" runat="server"/>
</asp:Content>        