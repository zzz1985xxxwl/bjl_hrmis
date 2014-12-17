<%@ Import Namespace="SEP.HRMIS.Model"%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GetMyAssessHistoryView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.AssessActivity.GetMyAssessHistoryView" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<asp:HiddenField ID="hfCount" runat="server" Value="0" />
<div id="tbSelf" runat="server">
<div class="leftitbor2" >�ҵļ�Ч����</div>
<div class="linetablediv" >
            <asp:GridView GridLines="None" Width="100%" ID="dgMyAssessHistorylist" runat="server" AutoGenerateColumns="False"
                AllowPaging="True" OnPageIndexChanging="dgMyAssessHistorylist_PageIndexChanging"  OnRowDataBound="dgMyAssessHistorylist_RowDataBound">
<HeaderStyle Height="28px" CssClass="headerstyleblue"/>
<RowStyle Height = "28px" CssClass="GridViewRowLink"/>
<AlternatingRowStyle CssClass="table_g" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate><asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("AssessActivityID") %>' CommandName="HiddenPostButtonCommand" runat="server" Text="" style=" display:none;"/></ItemTemplate> 
                        <ItemStyle Width="2%" />
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="���˶���">
                      <ItemTemplate>
                          <%#Eval("ItsEmployee.Account.Name")%></a>
                       </ItemTemplate> 
                        <ItemStyle Width="10%" />                       
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="��������">
                      <ItemTemplate> 
                         <%#AssessActivityUtility.GetCharacterNameByType((AssessCharacterType)Eval("AssessCharacterType"))%></a> 
                      </ItemTemplate> 
                        <ItemStyle Width="16%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="����״̬">
                      <ItemTemplate> 
                        <%#AssessActivityUtility.GetAssessStatusNameByStatus((AssessStatus)Eval("ItsAssessStatus"))%></a>
                      </ItemTemplate> 
                        <ItemStyle Width="10%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="��дʱ��">
                      <ItemTemplate>
                        <%#(Eval("ItsAssessActivityPaper.SubmitInfoes[0].SubmitTime", "{0:yyyy-MM-dd}") == "1900-01-01" ? "" : Eval("ItsAssessActivityPaper.SubmitInfoes[0].SubmitTime", "{0:yyyy-MM-dd}"))%></a>
                      </ItemTemplate> 
                        <ItemStyle Width="10%" />
                    </asp:TemplateField> 
                        <asp:TemplateField HeaderText="�����ܷ�">
                        <ItemTemplate> 
                         <%#Eval("ItsAssessActivityPaper.PersonalScore")%></a>
                        </ItemTemplate>
                        <ItemStyle Width="10%" />
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="�����ܷ�">
                        <ItemTemplate> 
                         <%#Eval("IfEmployeeVisible").Equals(true) ? Eval("ItsAssessActivityPaper.ManagerScore") : "--"%></a>
                        </ItemTemplate>
                        <ItemStyle Width="10%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="������">
                        <ItemTemplate> 
                         <%#Eval("IfEmployeeVisible").Equals(true) ? Eval("ItsAssessActivityPaper.Score") : "--"%></a>
                        </ItemTemplate>
                        <ItemStyle Width="10%" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                      <ItemTemplate>
                        <asp:LinkButton ID="btnExportSelf" Text="���������ܽ��" Enabled='<%#Eval("IfHasEmployeeFlow")%>'  OnCommand="btnExportSelf_Click" 
                        CommandName="Interrupt" runat="server" CommandArgument='<%# Eval("AssessActivityID")%>'/>
                      </ItemTemplate>
                            <ItemStyle Width="12%" />
                    </asp:TemplateField>
                     <asp:TemplateField>
                      <ItemTemplate>
                        <asp:LinkButton ID="btnExportAll" Text="����������" OnCommand="btnExportAll_Click"  Enabled='<%#Eval("IfEmployeeVisible")%>'
                        CommandName="Interrupt" runat="server" CommandArgument='<%# Eval("AssessActivityID")%>'/>
                      </ItemTemplate>
                            <ItemStyle Width="10%" />
                    </asp:TemplateField>
                </Columns>
                    <PagerTemplate>
<%--		<div class="pages">
		    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton" CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    ��һҳ</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton" CommandArgument="Next" CommandName="Page"  Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    ��һҳ</asp:LinkButton>
		</div>     --%>    
    <uc1:PageTemplate id="PageTemplate1" runat="server">
    </uc1:PageTemplate>		                 
                    </PagerTemplate>
            </asp:GridView>   
</div>
</div>