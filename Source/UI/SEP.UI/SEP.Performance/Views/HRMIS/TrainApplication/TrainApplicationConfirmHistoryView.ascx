<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TrainApplicationConfirmHistoryView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.TrainApplication.TrainApplicationConfirmHistoryView" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<asp:HiddenField ID="hfCount" runat="server" Value="0" />
<div id="tbReimburse" runat="server" >
<div class="leftitbor2">   
  <asp:Label ID="lbOperationType" runat="server" >审核的历史</asp:Label>
</div> 
<div  class="linetablediv" >
 <asp:GridView ID="grd" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                   GridLines="None" OnPageIndexChanging="grd_PageIndexChanging" Width="100%" OnRowCommand="grd_RowCommand" OnRowDataBound="grd_RowDataBound">
                   <HeaderStyle CssClass="headerstyleblue" Height="28px" HorizontalAlign="Center" />
                   <RowStyle Height = "28px" CssClass="GridViewRowLink"/>
                   <AlternatingRowStyle CssClass="table_g" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("PKID")%>'
                        CommandName="HiddenPostButtonCommand" runat="server" Text="" Style="display: none;" />
               <asp:HiddenField ID="hfReimburseID" runat="server" Value='<%# Eval("PKID")%>' />                        
                </ItemTemplate>
                <ItemStyle Width="2%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="培训课程名称">
                <ItemTemplate>
                    <%#Eval("CourseName")%>
                </ItemTemplate>
                <ItemStyle Width="15%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="申请人">
                <ItemTemplate>
                    <%#Eval("Applicant.Name")%>
                </ItemTemplate>
                <ItemStyle Width="7%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="开始时间">
                <ItemTemplate>
                    <%#Eval("StratTime", "{0:yyyy-MM-dd}")%>
                </ItemTemplate>
                <ItemStyle Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="结束时间">
                <ItemTemplate>
                    <%#Eval("EndTime", "{0:yyyy-MM-dd}")%>
                </ItemTemplate>
                <ItemStyle Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="是否有证书">
                <ItemTemplate>
            <%#Eval("HasCertifacation").Equals(true)?"有":"没有"%>
                </ItemTemplate>
                <ItemStyle Width="8%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="培训类型">
                <ItemTemplate>
                    <%#Eval("TrainType.Name")%>
                </ItemTemplate>
                <ItemStyle Width="7%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="状态">
                <ItemTemplate>
                    <%#Eval("TraineeApplicationStatuss.Name")%>
                </ItemTemplate>
                <ItemStyle Width="7%" HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="被培训人">
                <ItemTemplate>
                            <%#Eval("StudentName")%>
                </ItemTemplate>
                <ItemStyle Width="30%" />
            </asp:TemplateField>
        </Columns>
                    <PagerTemplate>
<%--		<div class="pages">
		    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton" CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    上一页</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton" CommandArgument="Next" CommandName="Page"  Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    下一页</asp:LinkButton>
		</div>        --%>    
   <uc1:PageTemplate ID="PageTemplate1" runat="server" />		              
                    </PagerTemplate>
               </asp:GridView>
 
</div>
</div>