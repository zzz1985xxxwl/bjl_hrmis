<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/HRMIS/MainPages/HRMISMaster.Master"  CodeBehind="OverWorkList.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.OverWorkPages.OverWorkList" %>

<%@ Register Src="../../../Views/HRMIS/OverWorks/OverWorkListView.ascx"
    TagName="OverWorkListView" TagPrefix="uc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
        <uc1:OverWorkListView id="OverWorkListView1" runat="server">
        </uc1:OverWorkListView>
</asp:Content>
