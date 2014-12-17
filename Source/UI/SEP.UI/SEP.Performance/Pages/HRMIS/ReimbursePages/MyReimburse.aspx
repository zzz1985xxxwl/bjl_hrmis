<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyReimburse.aspx.cs" MasterPageFile="../MainPages/HRMISMaster.Master" Inherits="SEP.Performance.Pages.HRMIS.ReimbursePages.MyReimburse" %>

<%--<%@ Register Src="../../../Views/HRMIS/Reimburse/ReimburseConfirmHistoryListView.ascx"
    TagName="ReimburseConfirmHistoryListView" TagPrefix="uc4" %>--%>

<%@ Register Src="../../../Views/HRMIS/Reimburse/ReimbursingListView.ascx" TagName="ReimbursingListView"
    TagPrefix="uc1" %>
<%--<%@ Register Src="../../../Views/HRMIS/Reimburse/ReimburseConfirmListView.ascx" TagName="ReimburseConfirmListView"
    TagPrefix="uc3" %>--%>

<asp:Content ID="cphPage" ContentPlaceHolderID="cphCenter" Runat="Server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
      <div class="leftitbor" >
		<span class="font14b">你共有 </span>
		<span class="fontred"><asp:Label ID="lblReimbursingCount" runat="server"></asp:Label></span>
        <span class="font14b"> 个报销单；&nbsp;&nbsp;&nbsp;</span>
<%--		<span class="fontred"><asp:Label ID="lblReimbursingConfirmCount" runat="server"></asp:Label></span>
        <span class="font14b"> 个待审核的报销单；&nbsp;&nbsp;&nbsp;</span>
        <span class="fontred"><asp:Label ID="lblReimbursingConfirmListCount" runat="server"></asp:Label></span>
        <span class="font14b"> 个已审核的报销单；&nbsp;&nbsp;&nbsp;</span>--%>
    </div>

    <uc1:ReimbursingListView ID="ReimbursingListView1" runat="server" />
<%--        <uc3:ReimburseConfirmListView id="ReimburseConfirmListView1" runat="server">
        </uc3:ReimburseConfirmListView>
                <uc4:ReimburseConfirmHistoryListView id="ReimburseConfirmHistoryListView1" runat="server">
        </uc4:ReimburseConfirmHistoryListView>--%>
            </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
