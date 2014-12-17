<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeAccountSetDetailBack.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.PayModuleViews.EmployeeAccountSetDetailBack" %>
<%@ Register Src="SetEmployeeAccountDetailView.ascx" TagName="SetEmployeeAccountDetailView"
    TagPrefix="uc1" %>
<%@ Register Src="AdjustHistoryListView.ascx" TagName="AdjustHistoryListView" TagPrefix="uc2" %>
<uc1:SetEmployeeAccountDetailView ID="SetEmployeeAccountDetailView1" runat="server" />
<uc2:AdjustHistoryListView id="AdjustHistoryListView1" runat="server"></uc2:AdjustHistoryListView>
