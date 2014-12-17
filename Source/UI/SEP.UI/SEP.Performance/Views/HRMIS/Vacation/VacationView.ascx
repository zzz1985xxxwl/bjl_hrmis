<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VacationView.ascx.cs" Inherits="SEP.Performance.VacationView" %>
<%@ Register Src="VacationUsedDetailsView.ascx" TagName="VacationUsedDetailsView"
    TagPrefix="uc2" %>
<%--<%@ Register Src="VacationShowView.ascx" TagName="VacationShowView" TagPrefix="uc3" %>--%>
<%@ Register Src="VacationInfoListView.ascx" TagName="VacationInfoListView" TagPrefix="uc1" %>
<div style=" padding-top:8px;">
<div id="ShowSocietyWorkAge" runat="server" class="linetable_in"  style="margin-top:0px;">
社会工龄：<span class="fontred1"><asp:Label ID="lblSocietyWorkAge" runat="server" Text="Label"></asp:Label></span>天
</div>
<%--<div id="ShowDetail" runat="server">
    <uc3:VacationShowView ID="VacationShowView1" runat="server" />
</div>--%>
<uc1:VacationInfoListView id="VacationInfoListView1" runat="server" />
  
<uc2:VacationUsedDetailsView id="VacationUsedDetailsView1" runat="server">
</uc2:VacationUsedDetailsView>

</div>

