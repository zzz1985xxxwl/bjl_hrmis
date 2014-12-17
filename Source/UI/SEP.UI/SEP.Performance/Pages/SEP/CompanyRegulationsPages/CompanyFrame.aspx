<%@ Page Language="C#" MasterPageFile="../MasterPage.Master" AutoEventWireup="true" CodeBehind="CompanyFrame.aspx.cs" Inherits="SEP.Performance.Pages.SEP.CompanyRegulationsPages.CompanyFrame" %>

<%@ Register Src="../../../Views/SEP/CompanyRegulations/LinkView.ascx" TagName="LinkView"
    TagPrefix="uc2" %>
<%@ Register Src="../../../Views/HRMIS/DepartmentHistory/DepartmentHistoryListView.ascx"
    TagName="DepartmentHistoryListView" TagPrefix="uc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphCenter">
<div class="rule">
    <uc2:LinkView ID="LinkView1" runat="server" />
			<div class="ruleright">
				<div class="rulecon">
                        <uc1:DepartmentHistoryListView ID="DepartmentHistoryListView1" runat="server" />
        		</div>
			</div>
</div>
</asp:Content>   