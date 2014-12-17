<%@ Import Namespace="SEP.HRMIS.Model"%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchTrainApplicationView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.TrainApplication.SearchTrainApplicationView" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<div class="leftitbor">
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
</div>
<div class="leftitbor2">
    查询培训申请</div>
<div class="edittable">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left" style="width: 2%;">
                </td>
            <td align="left" style="width: 10%;">
                课程名称</td>
            <td align="left" style="width: 39%">
                <asp:TextBox CssClass="input1" ID="txtCourseName" runat="server" Width="60%"></asp:TextBox>
            </td>
            <td align="left" style="width: 10%;">
                被培训人</td>
            <td align="left" style="width: 39%">
                <asp:TextBox CssClass="input1" ID="txtEmployeeName" runat="server" Width="60%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="left">
                </td>
            <td align="left">
               是否有证书
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlCertifacation" runat="server" Width="60%">
                <asp:ListItem Value="-1" Text=""></asp:ListItem>
                       <asp:ListItem Value="0" Text="没有"></asp:ListItem>
                             <asp:ListItem Value="1" Text="有"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td align="left">
                培训类型
            </td>
            <td align="left">
             <asp:DropDownList ID="ddlType" runat="server" Width="60%">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="left">
                </td>
            <td align="left">
                培训状态
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlStatus" runat="server" Width="60%">
                </asp:DropDownList>
            </td>
            <td align="left">培训师
            </td> 
            <td align="left"><asp:TextBox CssClass="input1" ID="txtTrainer" runat="server" Width="60%"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td align="left">
                </td>
            <td align="left">
                培训时间
            </td>
            <td colspan="5" align="left">
                <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="dtpDateFrom"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
                <ajaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="dtpDateTo"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
                <asp:TextBox CssClass="input1" ID="dtpDateFrom" runat="server" Width="170px"></asp:TextBox>
                ---
                <asp:TextBox CssClass="input1" ID="dtpDateTo" runat="server" Width="170px"></asp:TextBox>
                <asp:Label ID="lblApplyDateMsg" runat="server" CssClass="psword_f"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>       
    </table>
</div>
<div class="tablebt">
    <asp:Button ID="btnSearch" runat="server" Text="查  询" CssClass="inputbt" OnClick="btnSearch_Click" />
</div>
<div id="tbSearch" runat="server" class="linetablediv">
    <asp:GridView GridLines="None" Width="100%" ID="gvReimburseList" runat="server" AutoGenerateColumns="false"
        AllowPaging="true" OnPageIndexChanging="gvReimburseList_PageIndexChanging" OnRowCommand="gvReimburseList_RowCommand"
        OnRowDataBound="gvReimburseList_RowDataBound">
        <HeaderStyle Height="28px" CssClass="headerstyleblue" />
        <RowStyle Height="28px" CssClass="GridViewRowLink" />
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
                <ItemStyle Width="14%" />
            </asp:TemplateField>
             <asp:TemplateField HeaderText="申请人">
                <ItemTemplate>
                    <%#Eval("Applicant.Name")%>
                </ItemTemplate>
                <ItemStyle Width="8%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="培训开始时间">
                <ItemTemplate>
                    <%#Eval("StratTime", "{0:yyyy-MM-dd}")%>
                </ItemTemplate>
                <ItemStyle Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="培训结束时间">
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
                <ItemStyle Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="状态">
                <ItemTemplate>
                  <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("TraineeApplicationStatuss.Name")%>'></asp:Label>  
                </ItemTemplate>
                <ItemStyle Width="10%" HorizontalAlign="Left" />
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="被培训人">
                <ItemTemplate>
                            <%#Eval("StudentName")%>
                </ItemTemplate>
                <ItemStyle Width="18%" />
            </asp:TemplateField>
                 <asp:TemplateField >
                <ItemTemplate>
                 <asp:LinkButton ID="btnCreateCourse" runat="server" Text="生成课程" OnCommand="btnCreateCourse_Click" CommandArgument='<%# Eval("PKID")%>' Enabled="false"></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle Width="10%" HorizontalAlign="Left" />
            </asp:TemplateField>
        </Columns>
        <PagerTemplate>
    <uc1:PageTemplate ID="PageTemplate1" runat="server" />        
<%--            <div class="pages">
                <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton"
                    CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    上一页</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton"
                    CommandArgument="Next" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    下一页</asp:LinkButton>
            </div>--%>
        </PagerTemplate>
    </asp:GridView>

</div>