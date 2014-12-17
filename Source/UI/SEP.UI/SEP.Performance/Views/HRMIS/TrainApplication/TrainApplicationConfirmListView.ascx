<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TrainApplicationConfirmListView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.TrainApplication.TrainApplicationConfirmListView" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<asp:HiddenField ID="hfCount" runat="server" Value="0" />
<div id="tbReimburse" runat="server">
<div class="leftitbor2">
<asp:Label ID="lbOperationType" runat="server">�������ѵ����</asp:Label>
</div>
<div  class="linetablediv">
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
            <asp:TemplateField HeaderText="��ѵ�γ�����">
                <ItemTemplate>
                    <%#Eval("CourseName")%>
                </ItemTemplate>
                <ItemStyle Width="14%" />
            </asp:TemplateField>
           <asp:TemplateField HeaderText="������">
                <ItemTemplate>
                    <%#Eval("Applicant.Name")%>
                </ItemTemplate>
                <ItemStyle Width="7%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="��ʼʱ��">
                <ItemTemplate>
                    <%#Eval("StratTime", "{0:yyyy-MM-dd}")%>
                </ItemTemplate>
                <ItemStyle Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="����ʱ��">
                <ItemTemplate>
                    <%#Eval("EndTime", "{0:yyyy-MM-dd}")%>
                </ItemTemplate>
                <ItemStyle Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="�Ƿ���֤��">
                <ItemTemplate>
              <%#Eval("HasCertifacation").Equals(true)?"��":"û��"%>
                </ItemTemplate>
                <ItemStyle Width="8%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="��ѵ����">
                <ItemTemplate>
                    <%#Eval("TrainType.Name")%>
                </ItemTemplate>
                <ItemStyle Width="7%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="״̬">
                <ItemTemplate>
                    <%#Eval("TraineeApplicationStatuss.Name")%>
                </ItemTemplate>
                <ItemStyle Width="7%" HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="����ѵ��">
                <ItemTemplate>
                            <%#Eval("StudentName")%>
                </ItemTemplate>
                <ItemStyle Width="23%" />
            </asp:TemplateField>

                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnQuickPass" runat="server" Text="����ͨ��" CausesValidation="false"
                                                        CommandArgument='<%# Eval("PKID") %>' OnCommand="QuickPass_Command"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle Width="8%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnApprove" runat="server" Text="���" CausesValidation="false"
                                                        CommandArgument='<%# Eval("PKID") %>' OnCommand="Approve_Command"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle Width="4%" />
                                            </asp:TemplateField>
        </Columns>
                    <PagerTemplate>
    <uc1:PageTemplate ID="PageTemplate1" runat="server" />                    
<%--		<div class="pages">
		    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton" CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    ��һҳ</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton" CommandArgument="Next" CommandName="Page"  Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    ��һҳ</asp:LinkButton>
		</div>         --%>                 
                    </PagerTemplate>
               </asp:GridView>

</div>
</div>