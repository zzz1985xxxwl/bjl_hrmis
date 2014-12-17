<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssignAuth.aspx.cs" MasterPageFile="~/Pages/HRMIS/MainPages/HRMISMaster.Master"
Inherits="SEP.Performance.Pages.HRMIS.AuthPages.AssignAuth" %>

<%@ Register Src="../../../Views/HRMIS/Auths/AssignHrmisAuthInfoView.ascx" TagName="AssignHrmisAuthInfoView"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
        <uc1:AssignHrmisAuthInfoView id="AssignHrmisAuthInfoView1" runat="server">
        </uc1:AssignHrmisAuthInfoView>
</asp:Content>