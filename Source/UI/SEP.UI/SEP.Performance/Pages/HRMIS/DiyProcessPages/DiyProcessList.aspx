<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DiyProcessList.aspx.cs" MasterPageFile="../MainPages/HRMISMaster.Master"
Inherits="SEP.Performance.Pages.HRMIS.DiyProcessPages.DiyProcessList" %>

<%@ Register Src="../../../Views/HRMIS/DiyProcesses/DiyProcessListView.ascx" TagName="DiyProcessListView"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
        <uc1:DiyProcessListView id="DiyProcessListView1" runat="server">
        </uc1:DiyProcessListView>
</asp:Content>