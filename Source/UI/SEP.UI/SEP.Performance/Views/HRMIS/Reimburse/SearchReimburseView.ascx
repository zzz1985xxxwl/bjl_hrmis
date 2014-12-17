<%@ Import Namespace="SEP.HRMIS.Model" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchReimburseView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.Reimburse.SearchReimburseView" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<div class="leftitbor">
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
</div>
<div class="leftitbor2">
    ����������</div>
<div class="edittable">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left" style="width: 2%;">
                </td>
            <td align="left" style="width: 8%;">
                ������</td>
            <td align="left" style="width: 41%">
                <asp:TextBox CssClass="input1" ID="txtEmployeeName" runat="server" Width="44%"></asp:TextBox>
            </td>
            <td align="left" style="width: 8%;">
                ���벿��</td>
            <td align="left" style="width: 46%">
                <asp:DropDownList ID="ddlDepartment" runat="server" Width="45%">
                </asp:DropDownList>
            </td>
            
            <%--<td width="232px" align="left">
                <asp:TextBox CssClass="input1" ID="txtEmployeeName" runat="server" Width="170px"></asp:TextBox>
            </td>
            <td colspan="3" width="232px" align="left">
                <asp:DropDownList ID="ddlDepartment" runat="server" Width="182px">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;
            </td>--%>
        </tr>
        <tr>
            <td align="left" style="width: 2%;">
                </td>
            <td align="left" style="width: 8%;">
                ����״̬
            </td>
            <td align="left" style="width: 41%">
                <asp:DropDownList ID="ddlStatus" runat="server" Width="45%">
                </asp:DropDownList>
            </td>
            <td align="left" style="width: 8%;">
                ����״̬
            </td>
            <td align="left" style="width: 41%">
                <asp:DropDownList ID="ddlFinishStatus" runat="server" Width="45%">
                    <asp:ListItem Value="0" Text="δ����"></asp:ListItem>
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
            <td  align="left" style="width: 41%;">
                <asp:DropDownList ID="ddlReimburseCategories" runat="server" Width="45%">
                </asp:DropDownList>

            </td>
             <td align="left" style="width: 8%;">������˾</td>
             <td align="left" style="width: 46%">
              <asp:DropDownList ID="ddCompany" runat="server" Width="45%">
                </asp:DropDownList>
             </td>
        </tr>
        <tr>
            <td align="left" style="width: 2%;">
                </td>
            <td align="left" style="width: 8%;">
                �����ܶ�
            </td>
            <td colspan="5" align="left">
                <asp:TextBox CssClass="input1" ID="txtTotalCostFrom" runat="server" Width="71px"></asp:TextBox>
                ---
                <asp:TextBox CssClass="input1" ID="txtTotalCostTo" runat="server" Width="71px"></asp:TextBox>
                <asp:Label ID="lblTotalCostMsg" runat="server" CssClass="psword_f"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 2%;">
                </td>
            <td align="left" style="width: 8%;">
                ����ʱ��
            </td>
            <td colspan="5" align="left">
                <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="dtpApplyDateFrom"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
                <ajaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="dtpApplyDateTo"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
                <asp:TextBox CssClass="input1" ID="dtpApplyDateFrom" runat="server" Width="170px"></asp:TextBox>
                ---
                <asp:TextBox CssClass="input1" ID="dtpApplyDateTo" runat="server" Width="170px"></asp:TextBox>
                <asp:Label ID="lblApplyDateMsg" runat="server" CssClass="psword_f"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
          <tr>
            <td align="left" style="width: 2%;">
                </td>
            <td align="left" style="width: 8%;">
                ����ʱ��
            </td>
            <td colspan="5" align="left">
                <ajaxToolKit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtBillingFrom"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
                <ajaxToolKit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtBillingTo"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
                 <asp:TextBox CssClass="input1" ID="txtBillingFrom" runat="server" Width="170px"></asp:TextBox>
                ---
                <asp:TextBox CssClass="input1" ID="txtBillingTo" runat="server" Width="170px"></asp:TextBox>
                <asp:Label ID="lblBillingMsg" runat="server" CssClass="psword_f"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
    </table>
</div>
<div class="tablebt">
    <asp:Button ID="btnSearch" runat="server" Text="��  ѯ" CssClass="inputbt" OnClick="btnSearch_Click" />
    <asp:Button ID="btnWaitAudit" runat="server" Text="���������" CssClass="inputbt" OnClientClick="Confirmed = false; return confirm('ȷ��Ҫ�����������ѡ��������');"
        OnClick="btnWaitAudit_Click" />
            <asp:Button ID="btnReturn" runat="server" Text="��  ��" CssClass="inputbt" OnClientClick="Confirmed = false; return confirm('ȷ��Ҫ�˻���ѡ��������');"
        OnClick="btnReturn_Click" />
<%--    <asp:Button ID="btnReimbursed" runat="server" Text="�ѱ���" CssClass="inputbt" OnClick="btnReimbursed_Click"
        OnClientClick="Confirmed = false; return confirm('ȷ��Ҫ������ѡ��������');" />--%>

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
                    <asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("ReimburseID")+"|" +Eval("ApplierID")%>'
                        CommandName="HiddenPostButtonCommand" runat="server" Text="" Style="display: none;" />
                </ItemTemplate>
                <ItemStyle Width="2%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:LinkButton ID="lbChooseAll" runat="server" OnClick="lbChooseAll_Click">ȫѡ</asp:LinkButton>/
                    <asp:LinkButton ID="lbClearAll" runat="server" OnClick="lbClearAll_Click">���</asp:LinkButton>
                </HeaderTemplate>
                <ItemTemplate>
                    <input id="cbChooseReimburse" type="checkbox" runat="server" onclick="javascript:Confirmed = false;" />
                    <asp:HiddenField ID="hfReimburseID" runat="server" Value='<%# Eval("ReimburseID")+"|" +Eval("ApplierID")%>' />
                </ItemTemplate>
                <ItemStyle Width="6%" />
            </asp:TemplateField>
              <asp:TemplateField HeaderText="������">
                <ItemTemplate>
                    <%#Eval("ApplerName")%>
                </ItemTemplate>
                <ItemStyle Width="5%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="��������">
                <ItemTemplate>
                    <%#Eval("ReimburseCategoriesEnum.Name").ToString().Replace("����","")%>
                </ItemTemplate>
                <ItemStyle Width="6%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="���벿��">
                <ItemTemplate>
                    <%#Eval("Department.DepartmentName")%>
                </ItemTemplate>
                <ItemStyle Width="8%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="����ʱ��">
                <ItemTemplate>
                    <%#Eval("ApplyDate", "{0:yyyy-MM-dd}")%>
                </ItemTemplate>
                <ItemStyle Width="8%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="����״̬">
                <ItemTemplate>
                    <asp:Label ID="lblStatus" runat="server" Text='<%#Reimburse.GetReimburseStatusNameByReimburseStatus((ReimburseStatusEnum)Eval("ReimburseStatus"))%>'>
                    </asp:Label></a>
                </ItemTemplate>
                <ItemStyle Width="8%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="�����ܶ�">
                <ItemTemplate>
                     <%#Eval("ExchangeSymbol")%><%#Eval("TotalCost")%>
                </ItemTemplate>
                <ItemStyle Width="9%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="��������">
                <ItemTemplate>
                    <%#Eval("ReimburseContentShow")%>
                </ItemTemplate>
                <ItemStyle Width="39%" HorizontalAlign="Left" />
            </asp:TemplateField>
            
            <asp:TemplateField>
                 <ItemTemplate>
                 <asp:LinkButton ID="btnApprove" runat="server" Text="���" CausesValidation="false" Enabled ="false"
                      CommandArgument='<%# Eval("ReimburseID") %>' OnCommand="Approve_Command"></asp:LinkButton>
                 </ItemTemplate>
                <ItemStyle Width="4%" />
            </asp:TemplateField>
                                            
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="btnReimburse" Text="�ѱ���" runat="server" CausesValidation="false" Enabled ="false" CommandArgument='<%# Eval("ReimburseID")%>'
                        OnCommand="btnReimburse_Click" />
                </ItemTemplate>
                <ItemStyle Width="5%" />
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
    <uc1:PageTemplate ID="PageTemplate1" runat="server" />            
        </PagerTemplate>
    </asp:GridView>
</div>
