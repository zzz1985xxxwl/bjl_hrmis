<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TrainCourseListView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.Train.TrainCourseListView" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<script type="text/javascript">
function FeedBackReport(linkbtnFeedBack)
{
    var courseID = $(linkbtnFeedBack).attr("CourseID");
    location.href='SearchTrainCourseBack.aspx?operation=FeedBackExport&courseID='+courseID;
}
</script>

<div id="tbCourse" runat="server" class="linetable">
  <asp:GridView ID="grd" runat="server" AllowPaging="True" AutoGenerateColumns="False"
       GridLines="None" OnPageIndexChanging="grd_PageIndexChanging" Width="100%" OnRowDataBound="grd_RowDataBound" OnRowCommand="grd_RowCommand">
       <HeaderStyle CssClass="headerstyleblue" Height="28px" HorizontalAlign="Center" />
       <RowStyle Height = "28px" CssClass="GridViewRowLink"/>
       <AlternatingRowStyle CssClass="table_g" />
       <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("CourseID") %>' 
                    CommandName="HiddenPostButtonCommand" 
                    runat="server" Text="" style=" display:none;"/>
                </ItemTemplate>
                <ItemStyle Width="1%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="课程名称">
                <ItemTemplate>
                    <%#Eval("CourseName")%>
                </ItemTemplate>
                <ItemStyle Width="11%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="培训师">
                <ItemTemplate>
                    <%#Eval("Trainer")%>
                </ItemTemplate>
                <ItemStyle Width="9%" />
            </asp:TemplateField>
             <asp:TemplateField HeaderText="被培训人">
                <ItemTemplate>
                     <%#Eval("TrainFBResult.Trainees")%>
                </ItemTemplate>
                <ItemStyle Width="9%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="培训状态">
                <ItemTemplate> 
                    <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Status")%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="7%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="培训地点">
                <ItemTemplate> 
                    <%#Eval("TrainPlace")%>
                </ItemTemplate>
                <ItemStyle Width="7%" />
            </asp:TemplateField>                
            <asp:TemplateField HeaderText="开始时间">
                <ItemTemplate> 
                    <%#Eval("ActualST", "{0:yyyy-MM-dd}")%>
                </ItemTemplate>
                <ItemStyle Width="10%" />
            </asp:TemplateField>   
            <asp:TemplateField HeaderText="结束时间">
                <ItemTemplate> 
                    <%#Eval("ActualET", "{0:yyyy-MM-dd}")%>
                </ItemTemplate>
                <ItemStyle Width="10%" />
            </asp:TemplateField>     
            <asp:TemplateField HeaderText="反馈人数">
                <ItemTemplate> 
                    <%#Eval("TrainFBResult.FeedBackCount")%>
                </ItemTemplate>
                <ItemStyle Width="7%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="平均分值">
                <ItemTemplate> 
                    <%#decimal.Round(Convert.ToDecimal(Eval("TrainFBResult.CourseScore").ToString()),2)%>
                </ItemTemplate>
                <ItemStyle Width="7%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                <asp:LinkButton ID="btnUpdate" runat="server" CommandArgument='<%# Eval("CourseID")%>' Enabled='<%# !(Eval("Status").ToString()=="End" || Eval("Status").ToString()=="Interrupt")%>'
                CommandName="BtnUpdateClick" OnCommand="BtnUpdate_Click" Text="修改"></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle Width="4%" />
           </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                       <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("CourseID")%>' Enabled='<%# !(Eval("Status").ToString()=="End" || Eval("Status").ToString()=="Interrupt")%>'
                CommandName="BtnInterruptClick" OnCommand="BtnInterrupt_Click" Text="中断"></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle Width="4%" />
           </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                <asp:LinkButton ID="btnFinish" runat="server" CommandArgument='<%# Eval("CourseID")%>' Enabled='<%# !(Eval("Status").ToString()=="End" || Eval("Status").ToString()=="Interrupt")%>'
                CommandName="BtnFinishClick" OnCommand="BtnFinish_Click" Text="结束课程" OnClientClick="Confirmed = confirm('确定要结束此课程吗？'); return Confirmed;"></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle Width="4%" />
           </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                <asp:LinkButton ID="BtnFeedBack" runat="server" CommandArgument='<%# Eval("CourseID")%>'
                CommandName="BtnFeedBackClick" OnCommand="BtnFeedBack_Click" Text="相关反馈"></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle Width="4%" />
           </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                <asp:LinkButton ID="BtnFeedBackReport" runat="server" CommandArgument='<%# Eval("CourseID")%>' 
                CourseID='<%# Eval("CourseID")%>'
                CommandName="BtnFeedBackReportClick"
                Text="反馈导出" OnClientClick="FeedBackReport(this);return false;"></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle Width="4%" />
           </asp:TemplateField>

       </Columns>
        <PagerTemplate>
<%--<div class="pages">
<asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton" CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
上一页</asp:LinkButton>
<asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton" CommandArgument="Next" CommandName="Page"  Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
下一页</asp:LinkButton>
</div>         --%>      
    <uc1:PageTemplate ID="PageTemplate1" runat="server" />           
        </PagerTemplate>
   </asp:GridView>

</div>