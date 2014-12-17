<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GoalListView.ascx.cs" Inherits="SEP.Performance.Views.GoalListView" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>

<div class="leftitbor2">  
    <asp:Label ID="lbl_Title" runat="server"></asp:Label>&nbsp;
            <asp:LinkButton ID="btnAdd" runat="server" OnClick="btnAdd_Click">新增目标</asp:LinkButton>
        <asp:Label ID="lblMessage" style="color:Red;" runat="server"></asp:Label>
        <asp:Label ID="lblHostID" runat="server" Visible="False"></asp:Label></div>
  <div class="nolinetablediv">
    <table width="100%" id="tbGoalList" class="linetable" runat="server" cellpadding="0" cellspacing="0">

      <tr>
      <td  >
      <asp:GridView ID="dvGoalList" runat="server" AutoGenerateColumns="False" Width="100%" AllowPaging="True" PageSize="5" OnRowDeleting="dvGoalList_RowDeleting" OnPageIndexChanging="dvGoalList_PageIndexChanging" BorderStyle="None" GridLines="None"  OnRowCommand="dvGoalList_RowCommand" OnRowDataBound="dvGoalList_RowDataBound" >
        <HeaderStyle Height="28px" CssClass="headerstyleblue"/>
       <RowStyle Height = "28px" CssClass="GridViewRowLink"/>
       <AlternatingRowStyle CssClass="table_g" />
                    <PagerTemplate>
 <uc1:PageTemplate ID="PageTemplate1" runat="server" />                   
<%--		<div class="pages">
		    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton" CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    上一页</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton" CommandArgument="Next" CommandName="Page"  Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    下一页</asp:LinkButton>
		</div>          --%>                
                    </PagerTemplate>
            </asp:GridView>
       </td>
	  </tr>
    </table>
  </div>

