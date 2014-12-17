<%@ Import Namespace="SEP.HRMIS.Model" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="GetCurrentAssess.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.AssessActivity.GetCurrentAssess" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<asp:HiddenField ID="hfSelf" runat="server" Value="0" />
<asp:HiddenField ID="hfManager" runat="server" Value="0" />
<asp:HiddenField ID="hfCEO" runat="server" Value="0" />
<asp:HiddenField ID="hfHr" runat="server" Value="0" />
<asp:HiddenField ID="hfSummarizeCommment" runat="server" Value="0" />
<div class="leftitbor">
    <span class="font14b">你共有 </span>
    <asp:Label ID="lblMessage" runat="server" CssClass="fontred"></asp:Label>
    <span class="font14b">个绩效考核未填写</span>
</div>
<div id="tbSelf" runat="server">
    <div class="leftitbor2">
        待员工填写绩效考核</div>
    <div class="linetablediv">

        <asp:GridView GridLines="None" Width="100%" ID="gvSelf" runat="server" AutoGenerateColumns="False"
            AllowPaging="True" OnPageIndexChanging="gvSelf_PageIndexChanging" OnRowCommand="gvSelf_RowCommand"
            OnRowDataBound="gvSelf_RowDataBound">
            <HeaderStyle Height="28px" CssClass="headerstyleblue" />
            <RowStyle Height="28px" CssClass="GridViewRowLink" />
            <AlternatingRowStyle CssClass="table_g" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("AssessActivityID") %>'
                            CommandName="HiddenPostButtonCommand" runat="server" Text="" Style="display: none;" /></ItemTemplate>
                    <ItemStyle Width="2%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="考核对象">
                    <ItemTemplate>
                        <%#Eval("ItsEmployee.Account.Name")%>
                        </a>
                    </ItemTemplate>
                    <ItemStyle Width="17%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="期待员工填写时间">
                    <ItemTemplate>
                        <%#Eval("PersonalExpectedFinish", "{0:yyyy-MM-dd}")%>
                        </a>
                    </ItemTemplate>
                    <ItemStyle Width="29%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="考核性质">
                    <ItemTemplate>
                        <%#AssessActivityUtility.GetCharacterNameByType((AssessCharacterType)Eval("AssessCharacterType"))%>
                        </a>
                    </ItemTemplate>
                    <ItemStyle Width="22%" />
                </asp:TemplateField>
                      <asp:TemplateField HeaderText="个人总分">
                        <ItemTemplate> 
                         <%#Eval("ItsAssessActivityPaper.PersonalScore")%></a>
                        </ItemTemplate>
                        <ItemStyle Width="13%" />
                    </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="btnSelf" Text="填写" OnCommand="btnSelf_Click" CommandName="Fill"
                            runat="server" CommandArgument='<%# Eval("AssessActivityID")%>' />
                    </ItemTemplate>
                    <ItemStyle Width="13%" />
                </asp:TemplateField>
            </Columns>
            <PagerTemplate>
   <%--             <div class="pages">
                    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton"
                        CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    上一页</asp:LinkButton>
                    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton"
                        CommandArgument="Next" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    下一页</asp:LinkButton>
                </div>--%>        <uc1:PageTemplate id="PageTemplateSelf" runat="server">
        </uc1:PageTemplate>
            </PagerTemplate>
        </asp:GridView>
    </div>
</div>
<div id="tbManager" runat="server">
    <div class="leftitbor2">
        待主管填写绩效考核</div>
    <div class="linetablediv">
        <asp:GridView GridLines="None" Width="100%" ID="gvManager" runat="server" AutoGenerateColumns="False"
            AllowPaging="True" OnPageIndexChanging="gvManager_PageIndexChanging" OnRowCommand="gvManager_RowCommand"
            OnRowDataBound="gvManager_RowDataBound">
            <HeaderStyle Height="28px" CssClass="headerstyleblue" />
            <RowStyle Height="28px" CssClass="GridViewRowLink" />
            <AlternatingRowStyle CssClass="table_g" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("AssessActivityID") %>'
                            CommandName="HiddenPostButtonCommand" runat="server" Text="" Style="display: none;" /></ItemTemplate>
                    <ItemStyle Width="2%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="考核对象">
                    <ItemTemplate>
                        <%#Eval("ItsEmployee.Account.Name")%>
                    </ItemTemplate>
                    <ItemStyle Width="15%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="期待主管填写时间">
                    <ItemTemplate>
                        <%#Eval("ManagerExpectedFinish", "{0:yyyy-MM-dd}")%>
                    </ItemTemplate>
                    <ItemStyle Width="15%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="考核性质">
                    <ItemTemplate>
                        <%#AssessActivityUtility.GetCharacterNameByType((AssessCharacterType)Eval("AssessCharacterType"))%>
                    </ItemTemplate>
                    <ItemStyle Width="15%" />
                </asp:TemplateField>
                      <asp:TemplateField HeaderText="个人总分">
                        <ItemTemplate> 
                         <%#Eval("ItsAssessActivityPaper.PersonalScore")%></a>
                        </ItemTemplate>
                        <ItemStyle Width="12%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="主管总分">
                        <ItemTemplate> 
                         <%#Eval("ItsAssessActivityPaper.ManagerScore")%></a>
                        </ItemTemplate>
                        <ItemStyle Width="12%" />
                    </asp:TemplateField>
            <asp:TemplateField HeaderText="总评分">
                <ItemTemplate>
                    <%#Eval("ItsAssessActivityPaper.Score")%>
                </ItemTemplate>
                <ItemStyle Width="12%" />
            </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="btnManager" Text="填写" OnCommand="btnManager_Click" CommandName="Fill"
                            runat="server" CommandArgument='<%# Eval("AssessActivityID")%>' />
                    </ItemTemplate>
                    <ItemStyle Width="10%" />
                </asp:TemplateField>
            </Columns>
            <PagerTemplate>
  <%--              <div class="pages">
                    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton"
                        CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    上一页</asp:LinkButton>
                    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton"
                        CommandArgument="Next" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    下一页</asp:LinkButton>
                </div>--%><uc1:PageTemplate id="PageTemplateManager" runat="server"></uc1:PageTemplate>
            </PagerTemplate>
        </asp:GridView>
    </div>
</div>
<div id="tbCEO" runat="server">
    <div class="leftitbor2">
        待批阅的绩效考核</div>
    <div class="linetablediv">
        <asp:GridView GridLines="None" Width="100%" ID="gvCeo" runat="server" AutoGenerateColumns="False"
            AllowPaging="True" OnPageIndexChanging="gvCeo_PageIndexChanging" OnRowCommand="gvCeo_RowCommand"
            OnRowDataBound="gvCeo_RowDataBound">
            <HeaderStyle Height="28px" CssClass="headerstyleblue" />
            <RowStyle Height="28px" CssClass="GridViewRowLink" />
            <AlternatingRowStyle CssClass="table_g" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("AssessActivityID") %>'
                            CommandName="HiddenPostButtonCommand" runat="server" Text="" Style="display: none;" /></ItemTemplate>
                    <ItemStyle Width="2%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="考核对象">
                    <ItemTemplate>
                        <%#Eval("ItsEmployee.Account.Name")%>
                        </a></ItemTemplate>
                    <ItemStyle Width="15%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="部  门">
                    <ItemTemplate>
                        <%#Eval("ItsEmployee.Account.Dept.Name")%>
                        </a>
                    </ItemTemplate>
                    <ItemStyle Width="15%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="考核性质">
                    <ItemTemplate>
                        <%#AssessActivityUtility.GetCharacterNameByType((AssessCharacterType)Eval("AssessCharacterType"))%>
                    </ItemTemplate>
                    <ItemStyle Width="15%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="个人总分">
                        <ItemTemplate> 
                         <%#Eval("ItsAssessActivityPaper.PersonalScore")%></a>
                        </ItemTemplate>
                        <ItemStyle Width="12%" />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="主管总分">
                        <ItemTemplate> 
                         <%#Eval("ItsAssessActivityPaper.ManagerScore")%></a>
                        </ItemTemplate>
                        <ItemStyle Width="12%" />
                    </asp:TemplateField>
            <asp:TemplateField HeaderText="总评分">
                <ItemTemplate>
                    <%#Eval("ItsAssessActivityPaper.Score")%>
                </ItemTemplate>
                <ItemStyle Width="12%" />
            </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="btnCeo" Text="填写" OnCommand="btnCeo_Click" CommandName="Fill"
                            runat="server" CommandArgument='<%# Eval("AssessActivityID")%>' />
                    </ItemTemplate>
                    <ItemStyle Width="12%" />
                </asp:TemplateField>
            </Columns>
            <PagerTemplate>
 <%--               <div class="pages">
                    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton"
                        CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    上一页</asp:LinkButton>
                    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton"
                        CommandArgument="Next" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    下一页</asp:LinkButton>
                </div>--%><uc1:PageTemplate id="PageTemplateCEO" runat="server"></uc1:PageTemplate>
            </PagerTemplate>
        </asp:GridView>
    </div>
</div>
<div id="tbHr" runat="server">
    <div class="leftitbor2">
        待人力资源部评审的绩效考核
    </div>
    <div class="linetablediv">
        <asp:GridView GridLines="None" Width="100%" ID="gvHr" runat="server"
            AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="gvHr_PageIndexChanging"
            OnRowCommand="gvHr_RowCommand" OnRowDataBound="gvHr_RowDataBound">
            <HeaderStyle Height="28px" CssClass="headerstyleblue" />
            <RowStyle Height="28px" CssClass="GridViewRowLink" />
            <AlternatingRowStyle CssClass="table_g" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("AssessActivityID") %>'
                            CommandName="HiddenPostButtonCommand" runat="server" Text="" Style="display: none;" /></ItemTemplate>
                    <ItemStyle Width="2%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="考核对象">
                    <ItemTemplate>
                        <%#Eval("ItsEmployee.Account.Name")%>
                        </a>
                    </ItemTemplate>
                    <ItemStyle Width="15%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="部  门">
                    <ItemTemplate>
                        <%#Eval("ItsEmployee.Account.Dept.Name")%>
                        </a>
                    </ItemTemplate>
                    <ItemStyle Width="17%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="考核性质">
                    <ItemTemplate>
                        <%#AssessActivityUtility.GetCharacterNameByType((AssessCharacterType)Eval("AssessCharacterType"))%>
                        </a>
                    </ItemTemplate>
                    <ItemStyle Width="15%" />
                </asp:TemplateField>
                      <asp:TemplateField HeaderText="个人总分">
                        <ItemTemplate> 
                         <%#Eval("ItsAssessActivityPaper.PersonalScore")%></a>
                        </ItemTemplate>
                        <ItemStyle Width="15%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="主管总分">
                        <ItemTemplate> 
                         <%#Eval("ItsAssessActivityPaper.ManagerScore")%></a>
                        </ItemTemplate>
                        <ItemStyle Width="15%" />
                    </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="btnHr" runat="server" CommandArgument='<%# Eval("AssessActivityID")%>'
                            CommandName="FillAssess" CausesValidation="false" Text="填写" OnCommand="btnHr_Click" />
                    </ItemTemplate>
                    <ItemStyle Width="15%" />
                </asp:TemplateField>
            </Columns>
            <PagerTemplate>
<%--                <div class="pages">
                    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton"
                        CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    上一页</asp:LinkButton>
                    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton"
                        CommandArgument="Next" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    下一页</asp:LinkButton>
                </div>--%>    <uc1:PageTemplate id="PageTemplateHR" runat="server">
        </uc1:PageTemplate>
            </PagerTemplate>
        </asp:GridView>
    </div>
</div>
<div id="tbSummarizeCommment" runat="server">
    <div class="leftitbor2">
        待终结评语的绩效考核
</div>
    <div class="linetablediv">
        <asp:GridView GridLines="None" Width="100%" ID="gvSummarizeCommment" runat="server"
            AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="gvSummarizeCommment_PageIndexChanging"
            OnRowCommand="gvSummarizeCommment_RowCommand" OnRowDataBound="gvSummarizeCommment_RowDataBound">
            <HeaderStyle Height="28px" CssClass="headerstyleblue" />
            <RowStyle Height="28px" CssClass="GridViewRowLink" />
            <AlternatingRowStyle CssClass="table_g" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("AssessActivityID") %>'
                            CommandName="HiddenPostButtonCommand" runat="server" Text="" Style="display: none;" /></ItemTemplate>
                    <ItemStyle Width="2%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="考核对象">
                    <ItemTemplate>
                        <%#Eval("ItsEmployee.Account.Name")%>
                        </a>
                    </ItemTemplate>
                    <ItemStyle Width="12%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="部  门">
                    <ItemTemplate>
                        <%#Eval("ItsEmployee.Account.Dept.Name")%>
                        </a>
                    </ItemTemplate>
                    <ItemStyle Width="15%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="考核性质">
                    <ItemTemplate>
                        <%#AssessActivityUtility.GetCharacterNameByType((AssessCharacterType)Eval("AssessCharacterType"))%>
                        </a>
                    </ItemTemplate>
                    <ItemStyle Width="15%" />
                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="个人总分">
                        <ItemTemplate> 
                         <%#Eval("ItsAssessActivityPaper.PersonalScore")%></a>
                        </ItemTemplate>
                        <ItemStyle Width="15%" />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="主管总分">
                        <ItemTemplate> 
                         <%#Eval("ItsAssessActivityPaper.ManagerScore")%></a>
                        </ItemTemplate>
                        <ItemStyle Width="15%" />
                    </asp:TemplateField>
            <asp:TemplateField HeaderText="总评分">
                <ItemTemplate>
                    <%#Eval("ItsAssessActivityPaper.Score")%>
                </ItemTemplate>
                <ItemStyle Width="15%" />
            </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="btnHr" runat="server" CommandArgument='<%# Eval("AssessActivityID")%>'
                            CommandName="FillAssess" CausesValidation="false" Text="填写" OnCommand="btnSummarizeCommment_Click" />
                    </ItemTemplate>
                    <ItemStyle Width="10%" />
                </asp:TemplateField>
            </Columns>
            <PagerTemplate>
<%--                <div class="pages">
                    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton"
                        CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    上一页</asp:LinkButton>
                    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton"
                        CommandArgument="Next" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    下一页</asp:LinkButton>
                </div>--%>        <uc1:PageTemplate id="PageTemplateSummarize" runat="server">
        </uc1:PageTemplate>
            </PagerTemplate>
        </asp:GridView>
    </div>
</div>
