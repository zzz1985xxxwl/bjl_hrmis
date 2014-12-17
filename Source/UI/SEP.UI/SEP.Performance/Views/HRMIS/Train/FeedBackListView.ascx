<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FeedBackListView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.Train.FeedBackListView" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<div id="tbTable" runat="server" class="linetable">
    <asp:GridView ID="grd" Width="100%" runat="server" AutoGenerateColumns="False" AllowPaging="True"
        OnPageIndexChanging="grd_PageIndexChanging" BorderStyle="None" GridLines="None"
        OnRowCommand="grd_RowCommand" OnRowDataBound="grd_RowDataBound">
        <HeaderStyle Height="28px" CssClass="headerstyleblue" />
        <RowStyle Height="28px" CssClass="GridViewRowLink" />
        <AlternatingRowStyle CssClass="table_g" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("Trainee.Id") %>'
                        CommandName='<%# Eval("CourseId") %>' runat="server" Text="" Style="display: none;" /></ItemTemplate>
                <ItemStyle Width="2%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="" Visible="false">
                <ItemTemplate>
                    <%#Eval("CourseId")%>
                </ItemTemplate>
                <ItemStyle Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="培训课程">
                <ItemTemplate>
                    <%#Eval("CourseName")%>
                </ItemTemplate>
                <ItemStyle Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="计划开始时间">
                <ItemTemplate>
                    <%#Eval("CourseExpectST", "{0:yyyy-MM-dd}")%>
                </ItemTemplate>
                <ItemStyle Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="计划结束时间">
                <ItemTemplate>
                    <%#Eval("CourseExpectET", "{0:yyyy-MM-dd}")%>
                </ItemTemplate>
                <ItemStyle Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="被培训人">
                <ItemTemplate>
                    <%#Eval("Trainee.Name")%>
                </ItemTemplate>
                <ItemStyle Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="反馈状态">
                <ItemTemplate>
                    <%#Eval("FbStatus")%>
                </ItemTemplate>
                <ItemStyle Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="反馈时间">
                <ItemTemplate>
                    <%#Eval("FBTime")%>
                </ItemTemplate>
                <ItemStyle Width="15%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="总评分">
                <ItemTemplate>
                    <%#Eval("Score")%>
                </ItemTemplate>
                <ItemStyle Width="8%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnFeedBack" runat="server" Text="反馈" CausesValidation="false"
                        CommandArgument='<%#Eval("CourseId")+","+Eval("Trainee.Id") %>' OnCommand="FeedBack_Command" />
                </ItemTemplate>
                <ItemStyle Width="5%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnCourse" runat="server" Text="相关课程" CausesValidation="false"
                        CommandArgument='<%# Eval("CourseId") %>' OnCommand="Course_Command" />
                </ItemTemplate>
                <ItemStyle Width="11%" />
            </asp:TemplateField>
        </Columns>
        <PagerTemplate>
            <%--		<div class="pages">
		    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton" CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    上一页</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton" CommandArgument="Next" CommandName="Page"  Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    下一页</asp:LinkButton>
		</div>       --%>
            <uc1:PageTemplate ID="PageTemplate1" runat="server" />
        </PagerTemplate>
    </asp:GridView>
</div>
