<%@ Import Namespace="SEP.HRMIS.Model" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AssessActivityListView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.AssessActivity.AssessActivityListView" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<div class="leftitbor">
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
</div>
<div class="leftitbor2">
    ��ѯ��Ч����
</div>
<%--<div id="trSearch" runat="server" class="linetabledivbg">
    <table width="100%" height="56" border="0" cellpadding="0" cellspacing="0">--%>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td align="left" style="width: 2%;">
            </td>
            <td align="left" style="width: 8%;">
                ���˶���
            </td>
            <td align="left" style="width: 41%">
                <asp:TextBox CssClass="input1" ID="txtEmployeeName" runat="server" Width="58%"></asp:TextBox>
            </td>
            <td align="left" style="width: 8%;">
                ��������
            </td>
            <td align="left" style="width: 41%">                
                <asp:DropDownList ID="ddlDepartment" runat="server" Width="60%">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="left">
            </td>
            <td align="left">
                ����״̬
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlStatus" runat="server" Width="60%">
                </asp:DropDownList>
            </td>
            <td align="left">
                ����״̬
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlFinishStatus" runat="server" Width="60%">
                    <asp:ListItem Value="0" Text="δ����" Selected="True"></asp:ListItem>
                    <asp:ListItem Value="1" Text="�ѽ���"></asp:ListItem>
                    <asp:ListItem Value="-1" Text=""></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 2%;">
            </td>
            <td align="left" style="width: 8%;">
                ��������
            </td>
            <td align="left" style="width: 41%">
                <asp:DropDownList ID="ddlCharacter" runat="server" Width="60%">
                </asp:DropDownList>
            </td>
            <td align="left" style="width: 8%;">
                
            </td>
            <td align="left" style="width: 41%">
            </td>
        </tr>
        <tr>
            <td align="left">
            </td>
            <td align="left">
                ����ʱ��
            </td>
            <td colspan="3" align="left">
                <ajaxToolKit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtScopeFrom"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
                <ajaxToolKit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtScopeTo"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
                <asp:TextBox CssClass="input1" ID="txtScopeFrom" runat="server" Width="150px"></asp:TextBox>
                ---
                <asp:TextBox CssClass="input1" ID="txtScopeTo" runat="server" Width="150px"></asp:TextBox>
                <asp:Label ID="lblScopeMsg" runat="server" CssClass="psword_f"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left">
            </td>
            <td align="left">
                HR��дʱ��
            </td>
            <td colspan="3" align="left">
                <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="dtpHRSubmitTimeFrom"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
                <ajaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="dtpHRSubmitTimeTo"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
                <asp:TextBox CssClass="input1" ID="dtpHRSubmitTimeFrom" runat="server" Width="150px"></asp:TextBox>
                ---
                <asp:TextBox CssClass="input1" ID="dtpHRSubmitTimeTo" runat="server" Width="150px"></asp:TextBox>
                <asp:Label ID="lblHRSubmitTimeMsg" runat="server" CssClass="psword_f"></asp:Label>
            </td>
        </tr>
    </table>
</div>
<div class="tablebt">
    <asp:Button ID="btnSearch" runat="server" Text="��  ѯ" CssClass="inputbt" OnClick="btnSearch_Click" />
    <asp:Button ID="btnExportAnnualAssess" runat="server" Text="�������ռ�Ч����" CssClass="inputbtlong" OnClick="btnExportAnnualAssess_Click" />
</div>
<div id="tbSearch" runat="server" class="linetablediv">
    <asp:GridView GridLines="None" Width="100%" ID="gvAssessActivityList" runat="server"
        AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="gvAssessActivityList_PageIndexChanging"
        OnRowCommand="gvAssessActivityList_RowCommand" OnRowDataBound="gvAssessActivityList_RowDataBound">
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
            <asp:TemplateField HeaderText="���˶���">
                <ItemTemplate>
                    <%#Eval("ItsEmployee.Account.Name")%>
                </ItemTemplate>
                <ItemStyle Width="6%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="��������">
                <ItemTemplate>
                    <%#AssessActivityUtility.GetCharacterNameByType((AssessCharacterType)Eval("AssessCharacterType"))%>
                </ItemTemplate>
                <ItemStyle Width="8%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="����״̬">
                <ItemTemplate>
                    <%#AssessActivityUtility.GetAssessStatusNameByStatus((AssessStatus)Eval("ItsAssessStatus"))%>
                </ItemTemplate>
                <ItemStyle Width="8%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="������">
                <ItemTemplate>
                    <%#Eval("AssessProposerName")%>
                </ItemTemplate>
                <ItemStyle Width="6%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ȷ����">
                <ItemTemplate>
                    <%#Eval("HRConfirmerName")%>
                </ItemTemplate>
                <ItemStyle Width="6%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="��Ч���˱�">
                <ItemTemplate>
                    <%#Eval("ItsAssessActivityPaper.PaperName")%>
                </ItemTemplate>
                <ItemStyle Width="8%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="�ڴ�Ա����д">
                <ItemTemplate>
                    <%#Eval("PersonalExpectedFinish", "{0:yyyy-MM-dd}")%>
                    </a>
                </ItemTemplate>
                <ItemStyle Width="6%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="�ڴ�������д">
                <ItemTemplate>
                    <%#Eval("ManagerExpectedFinish", "{0:yyyy-MM-dd}")%>
                </ItemTemplate>
                <ItemStyle Width="6%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="�����ܷ�">
                <ItemTemplate> 
                 <%#Eval("ItsAssessActivityPaper.PersonalScore")%></a>
                </ItemTemplate>
                <ItemStyle Width="4%" />
            </asp:TemplateField>
             <asp:TemplateField HeaderText="�����ܷ�">
                <ItemTemplate> 
                 <%#Eval("ItsAssessActivityPaper.ManagerScore")%></a>
                </ItemTemplate>
                <ItemStyle Width="4%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="������">
                <ItemTemplate>
                    <%#Eval("ItsAssessActivityPaper.Score")%>
                </ItemTemplate>
                <ItemStyle Width="5%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnManualDetail" runat="server" CommandArgument='<%# Eval("AssessActivityID")%>'
                        CommandName="ManualDetail" OnCommand="btnManualDetail_Click" Text="��������" />
                </ItemTemplate>
                <ItemStyle Width="3%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnInterrupt" Text="�ж�" OnCommand="btnInterrupt_Click" OnClientClick="Confirmed = confirm('�˼�Ч���˻�жϺ󣬲��ɽ��������޸Ĳ�����ȷ��Ҫ�ж���'); return Confirmed;"
                        CommandName="Interrupt" runat="server" CommandArgument='<%# Eval("AssessActivityID")%>' />
                </ItemTemplate>
                <ItemStyle Width="3%" />
            </asp:TemplateField>
                        <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnDelete" Text="ɾ��" OnCommand="btnDelete_Click" OnClientClick="Confirmed = confirm('ȷ��Ҫɾ����'); return Confirmed;"
                        CommandName="Delete" runat="server" CommandArgument='<%# Eval("AssessActivityID")%>' />
                </ItemTemplate>
                <ItemStyle Width="3%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnEmployeeVisible"  OnCommand="btnEmployeeVisible_Click"
                        CommandName="Interrupt" runat="server" CommandArgument='<%# Eval("AssessActivityID")%>' />
                </ItemTemplate>
                <ItemStyle Width="4%" />
            </asp:TemplateField>
            <asp:TemplateField Visible="false">
                <ItemTemplate>
                    <asp:LinkButton ID="btnExportSelf" Text="������������" OnCommand="btnExportSelf_Click"
                        Enabled='<%#Eval("ExportSelf")%>'
                        CommandName="Interrupt" runat="server" CommandArgument='<%# Eval("AssessActivityID")%>' />
                </ItemTemplate>
                <ItemStyle Width="5%" />
            </asp:TemplateField>
            <asp:TemplateField Visible="false">
                <ItemTemplate>
                    <asp:LinkButton ID="btnExportLeader" Text="������������" OnCommand="btnExportLeader_Click"
                        Enabled='<%#Eval("ExportLeader")%>'
                        CommandName="Interrupt" runat="server" CommandArgument='<%# Eval("AssessActivityID")%>' />
                </ItemTemplate>
                <ItemStyle Width="5%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnExportEmployeeSummary" Text="���������ܽ��" OnCommand="btnExportEmployeeSummary_Click"
                          Enabled='<%#Eval("ExportSelf")%>' runat="server" CommandArgument='<%# Eval("AssessActivityID")%>' />
                </ItemTemplate>
                <ItemStyle Width="5%" />
            </asp:TemplateField>
          <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnExportAssessForm" Text="����������" OnCommand="btnExportAssessForm_Click"
                          Enabled='<%#Eval("ExportAnnualAndNormal")%>' runat="server" CommandArgument='<%# Eval("AssessActivityID")%>' />
                </ItemTemplate>
                <ItemStyle Width="4%" />
            </asp:TemplateField>
        </Columns>
        <PagerTemplate>
<%--            <div class="pages">
                <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton"
                    CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    ��һҳ</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton"
                    CommandArgument="Next" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    ��һҳ</asp:LinkButton>
            </div>--%>
    <uc1:PageTemplate id="PageTemplate1" runat="server">
    </uc1:PageTemplate>            
        </PagerTemplate>
    </asp:GridView>
</div>
