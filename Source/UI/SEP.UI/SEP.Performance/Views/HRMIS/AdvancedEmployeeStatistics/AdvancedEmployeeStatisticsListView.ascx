<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdvancedEmployeeStatisticsListView.ascx.cs" Inherits="SEP.Performance.Views.AdvancedEmployeeStatistics.AdvancedEmployeeStatisticsListView" %>
<asp:GridView GridLines="None" Width="100%" ID="gvStatisticsList" runat="server" 
AutoGenerateColumns="false" AllowPaging="true" >
<HeaderStyle Height="28px" CssClass="headerstyleblue"/>
<RowStyle Height = "28px" CssClass="GridViewRowLink"/>
<AlternatingRowStyle CssClass="table_g" />
    <Columns>
    </Columns>                
</asp:GridView>
