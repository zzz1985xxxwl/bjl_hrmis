<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="../MasterPage.Master"  EnableEventValidation="false" CodeBehind="GoalCompanyList.aspx.cs" Inherits="SEP.Performance.Pages.GoalCompanyList" %>
<%@ Register Src="../../../Views/SEP/Goals/GoalListView.ascx" TagName="GoalListView"
    TagPrefix="uc1" %>
<asp:Content ID="cphCenter" ContentPlaceHolderID="cphCenter" Runat="Server">
        <uc1:GoalListView id="GoalListView1" runat="server">
        </uc1:GoalListView>
</asp:Content>