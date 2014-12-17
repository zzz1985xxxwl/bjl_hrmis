<%@ Page Language="C#" MasterPageFile="../MainPages/HRMISMaster.Master" AutoEventWireup="true"
    Codebehind="GetAssessActivityHistory.aspx.cs" Inherits="SEP.Performance.Pages.HRMIS.AssessPages.GetAssessActivityHistory" %>

<%@ Register Src="../../../Views/HRMIS/AssessActivity/GetMyAssessHistoryView.ascx"
    TagName="GetMyAssessHistoryView" TagPrefix="uc1" %>
<%@ Register Src="../../../Views/HRMIS/AssessActivity/GetUnderlingAssessHistoryView.ascx"
    TagName="GetUnderlingAssessHistoryView" TagPrefix="uc2" %>
<asp:Content ID="cphPage" ContentPlaceHolderID="cphCenter" runat="Server">
    <div class="leftitbor">
        <span class="font14b">你一共参加了 </span><span class="fontred">
            <%Response.Write(_StrCount); %>
        </span><span class="font14b">个绩效考核</span>
    </div>
    <uc1:GetMyAssessHistoryView ID="GetMyAssessHistoryView1" runat="server"></uc1:GetMyAssessHistoryView>
    <uc2:GetUnderlingAssessHistoryView ID="GetUnderlingAssessHistoryView1" runat="server">
    </uc2:GetUnderlingAssessHistoryView>
</asp:Content>
