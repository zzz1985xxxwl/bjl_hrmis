<%@ Import namespace="SEP.HRMIS.Model.Enum"%>
<%@ Import namespace="SEP.HRMIS.Model.EmployeeAdjustRest"%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeAdjustRestView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.EmployeeAdjustRest.EmployeeAdjustRestView" %>
<div id="tbMessage" runat="server" class="leftitbor" >
<asp:Label ID="lblMessage" runat="server" CssClass = "fontred"></asp:Label>
</div>
<div class="leftitbor2" >
  <asp:Label ID="lblOperation" runat="server" >  
 </asp:Label>
<asp:HiddenField ID="hfAccountID" runat="server" />        
</div>

<div  class="edittable">
<div class="linetable_in" style="margin-top:0px;">
ʣ����ݣ�<span class="fontred1"><asp:Label ID="lblSurplusHours" runat="server"></asp:Label></span>Сʱ
</div>
<div id="Result" runat="server">
<div class="font14px marginepx"  style="text-align:left; margin-bottom:0px;">ʣ����ݱ䶯���</div>
<div class="linetablediv">
    <asp:GridView GridLines="None" Width="100%" ID="gvAdjustRestHistory" runat="server" AutoGenerateColumns="False"
        AllowPaging="True" PageSize="20"
        OnPageIndexChanging="gvAdjustRestHistory_PageIndexChanging" 
        OnRowDataBound="gvAdjustRestHistory_RowDataBound">
        <HeaderStyle Height="28px" CssClass="headerstyleblue" />
        <RowStyle Height="28px" CssClass="GridViewRowLink" />
        <AlternatingRowStyle CssClass="table_g" />
        <Columns>
            <asp:TemplateField HeaderStyle-Width="2%">
                <ItemTemplate>
                    <asp:LinkButton ID="btnHiddenPostButton" runat="server" CommandArgument='<%# Eval("AdjustRestHistoryID") %>'
                        CommandName="HiddenPostButtonCommand"></asp:LinkButton></ItemTemplate>
                <ItemStyle Width="2%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="������">
                <ItemTemplate>
                    <%# Eval("Operator.Name")%>
                </ItemTemplate>
                <ItemStyle Width="8%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="��������">
                <ItemTemplate>
                    <%#AdjustRestUtility.GetAdjustRestHistoryByType((AdjustRestHistoryTypeEnum)Eval("AdjustRestHistoryTypeEnum"))%>
                </ItemTemplate>
                <ItemStyle Width="8%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="����ʱ��">
                <ItemTemplate>
                    <%# Eval("OccurTime")%>
                </ItemTemplate>
                <ItemStyle Width="16%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="�䶯Сʱ">
                <ItemTemplate>
                    <%# Eval("ChangeHours")%>
                </ItemTemplate>
                <ItemStyle Width="8%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="˵��">
                <ItemTemplate>
                    <%# Eval("Remark")%>
                </ItemTemplate>
                <ItemStyle Width="38%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <%# UrlDetail((AdjustRestHistoryTypeEnum)Eval("AdjustRestHistoryTypeEnum"), (int)Eval("RelevantID"))%>
                </ItemTemplate>
                <ItemStyle Width="12%" />
            </asp:TemplateField>
        </Columns>
        <PagerTemplate>
            <div class="pages">
                <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton"
                    CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    ��һҳ</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton"
                    CommandArgument="Next" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    ��һҳ</asp:LinkButton>
            </div>
        </PagerTemplate>
    </asp:GridView>
</div>
</div>
</div>	 
<div class="tablebt">
<input type="button" value="��  ��"  class="inputbt"  onclick="history.go(-1);"/>
</div>