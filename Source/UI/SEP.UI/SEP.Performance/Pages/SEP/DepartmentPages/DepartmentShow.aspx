<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MasterPage.Master" CodeBehind="DepartmentShow.aspx.cs" Inherits="SEP.Performance.Pages.DepartmentShow" %>

<%@ Register Src="../../../Views/SEP/Departments/DepartmentShowListView.ascx" TagName="DepartmentInfoView"
    TagPrefix="uc1" %>
<asp:Content ID="cphCenter" ContentPlaceHolderID="cphCenter" Runat="Server">
 <uc1:DepartmentInfoView id="DepartmentShowListView1" runat="server">
</uc1:DepartmentInfoView>   
<script language= "javascript" type="text/javascript" src="../../../Pages/Inc/BaseScript.js"></script>
</asp:Content>
