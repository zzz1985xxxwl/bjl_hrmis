<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../MasterPage.Master" CodeBehind="GoalCompanyAdd.aspx.cs" Inherits="SEP.Performance.Pages.CompanyGoalAdd" %>
<%@ Register Src="../../../Views/SEP/Goals/ManageGoalView.ascx" TagName="ManageGoalView"
    TagPrefix="uc1" %>
<asp:Content ID="cphCenter" ContentPlaceHolderID="cphCenter" Runat="Server">
    <uc1:ManageGoalView id="ManageGoalView" runat="server">
        </uc1:ManageGoalView>
</asp:Content>