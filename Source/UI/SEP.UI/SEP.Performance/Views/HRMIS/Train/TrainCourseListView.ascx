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
            <asp:TemplateField HeaderText="�γ�����">
                <ItemTemplate>
                    <%#Eval("CourseName")%>
                </ItemTemplate>
                <ItemStyle Width="11%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="��ѵʦ">
                <ItemTemplate>
                    <%#Eval("Trainer")%>
                </ItemTemplate>
                <ItemStyle Width="9%" />
            </asp:TemplateField>
             <asp:TemplateField HeaderText="����ѵ��">
                <ItemTemplate>
                     <%#Eval("TrainFBResult.Trainees")%>
                </ItemTemplate>
                <ItemStyle Width="9%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="��ѵ״̬">
                <ItemTemplate> 
                    <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Status")%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="7%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="��ѵ�ص�">
                <ItemTemplate> 
                    <%#Eval("TrainPlace")%>
                </ItemTemplate>
                <ItemStyle Width="7%" />
            </asp:TemplateField>                
            <asp:TemplateField HeaderText="��ʼʱ��">
                <ItemTemplate> 
                    <%#Eval("ActualST", "{0:yyyy-MM-dd}")%>
                </ItemTemplate>
                <ItemStyle Width="10%" />
            </asp:TemplateField>   
            <asp:TemplateField HeaderText="����ʱ��">
                <ItemTemplate> 
                    <%#Eval("ActualET", "{0:yyyy-MM-dd}")%>
                </ItemTemplate>
                <ItemStyle Width="10%" />
            </asp:TemplateField>     
            <asp:TemplateField HeaderText="��������">
                <ItemTemplate> 
                    <%#Eval("TrainFBResult.FeedBackCount")%>
                </ItemTemplate>
                <ItemStyle Width="7%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ƽ����ֵ">
                <ItemTemplate> 
                    <%#decimal.Round(Convert.ToDecimal(Eval("TrainFBResult.CourseScore").ToString()),2)%>
                </ItemTemplate>
                <ItemStyle Width="7%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                <asp:LinkButton ID="btnUpdate" runat="server" CommandArgument='<%# Eval("CourseID")%>' Enabled='<%# !(Eval("Status").ToString()=="End" || Eval("Status").ToString()=="Interrupt")%>'
                CommandName="BtnUpdateClick" OnCommand="BtnUpdate_Click" Text="�޸�"></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle Width="4%" />
           </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                       <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("CourseID")%>' Enabled='<%# !(Eval("Status").ToString()=="End" || Eval("Status").ToString()=="Interrupt")%>'
                CommandName="BtnInterruptClick" OnCommand="BtnInterrupt_Click" Text="�ж�"></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle Width="4%" />
           </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                <asp:LinkButton ID="btnFinish" runat="server" CommandArgument='<%# Eval("CourseID")%>' Enabled='<%# !(Eval("Status").ToString()=="End" || Eval("Status").ToString()=="Interrupt")%>'
                CommandName="BtnFinishClick" OnCommand="BtnFinish_Click" Text="�����γ�" OnClientClick="Confirmed = confirm('ȷ��Ҫ�����˿γ���'); return Confirmed;"></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle Width="4%" />
           </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                <asp:LinkButton ID="BtnFeedBack" runat="server" CommandArgument='<%# Eval("CourseID")%>'
                CommandName="BtnFeedBackClick" OnCommand="BtnFeedBack_Click" Text="��ط���"></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle Width="4%" />
           </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                <asp:LinkButton ID="BtnFeedBackReport" runat="server" CommandArgument='<%# Eval("CourseID")%>' 
                CourseID='<%# Eval("CourseID")%>'
                CommandName="BtnFeedBackReportClick"
                Text="��������" OnClientClick="FeedBackReport(this);return false;"></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle Width="4%" />
           </asp:TemplateField>

       </Columns>
        <PagerTemplate>
<%--<div class="pages">
<asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton" CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
��һҳ</asp:LinkButton>
<asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton" CommandArgument="Next" CommandName="Page"  Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
��һҳ</asp:LinkButton>
</div>         --%>      
    <uc1:PageTemplate ID="PageTemplate1" runat="server" />           
        </PagerTemplate>
   </asp:GridView>

</div>