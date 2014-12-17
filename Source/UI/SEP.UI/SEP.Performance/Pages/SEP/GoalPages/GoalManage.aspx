<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="../MasterPage.Master" CodeBehind="GoalManage.aspx.cs" Inherits="SEP.Performance.Pages.GoalManage" %>

<%@ Register Src="../../../Views/SEP/Goals/GoalLastCompany.ascx" TagName="GoalLastCompany" TagPrefix="uc3" %>

<%@ Register Src="../../../Views/SEP/Goals/GoalListView.ascx" TagName="GoalListView" TagPrefix="uc2" %>
<%@ Register Src="../../../Views/SEP/Goals/GoalAllLastView.ascx" TagName="GoalAllLastView"  TagPrefix="uc1" %>
<asp:Content ID="cphCenter" ContentPlaceHolderID="cphCenter" Runat="Server">


    <uc3:GoalLastCompany id="GoalLastCompany1" runat="server">
    </uc3:GoalLastCompany>

    <uc2:GoalListView ID="GoalListTeam" runat="server" />

    <uc2:GoalListView ID="GoalListPerson" runat="server" />

</asp:Content>