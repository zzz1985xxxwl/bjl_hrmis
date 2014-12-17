<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FamilyBasicView.ascx.cs"
    Inherits="SEP.Performance.Views.EmployeeInformation.FamilyInformation.FamilyBasicView" %>
<%@ Register Src="../../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<table cellpadding="0" cellspacing="0" border="0" width="100%">
    <tr>
        <td height="20" align="center">
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td height="200" align="left">
                        <table width="100%" border="0" cellpadding="0" style="border-collapse: separate;"
                            cellspacing="10">
                            <tr>
                                <td align="right" width="2%">
                                </td>
                                <td width="12%">
                                    ��ͥסַ&nbsp;<span class="redstar">*</span>
                                </td>
                                <td width="86%" colspan="3">
                                    <asp:TextBox ID="txtFamilyAddress" runat="server" size="28" CssClass="input1" Width="82%"></asp:TextBox>
                                    <asp:Label ID="lblAddressMessage" runat="server" CssClass="psword_f"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="2%">
                                </td>
                                <td width="12%">
                                    ��ͥ�绰
                                </td>
                                <td width="37%">
                                    <asp:TextBox ID="txtFamilyPhone" runat="server" size="28" CssClass="input1" Width="60%">
                                    </asp:TextBox>
                                </td>
                                <td width="12%">
                                    �ʱ�&nbsp;
                                </td>
                                <td width="37%">
                                    <asp:TextBox ID="txtPostCode" CssClass="input1" Width="60%" size="28" runat="server"></asp:TextBox>
                                    <asp:Label ID="lblPostCodeMessage" runat="server" CssClass="psword_f"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                </td>
                                <td>
                                    ���ڵ�ַ&nbsp;<span class="redstar">*</span>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtRPRAddress" runat="server" size="28" CssClass="input1" Width="82%"></asp:TextBox>
                                    <asp:Label ID="lblRPRAddressMessage" runat="server" CssClass="psword_f"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                </td>
                                <td>
                                    �ʱ�&nbsp;
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPRPPostCode" runat="server" size="28" CssClass="input1" Width="60%"></asp:TextBox>
                                    <asp:Label ID="lblPRPPostCodeMessage" runat="server" CssClass="psword_f"></asp:Label>
                                </td>
                                <td>
                                    ������������&nbsp;
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPRPArea" runat="server" size="28" CssClass="input1" Width="60%"></asp:TextBox>
                                    <asp:Label ID="lblPRPAreaMessage" runat="server" CssClass="psword_f"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                </td>
                                <td>
                                    ���������ֵ�
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtPRPStreet" runat="server" size="28" CssClass="input1" Width="82%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                </td>
                                <td>
                                    �������ڵ�
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtRecordPlace" runat="server" size="28" CssClass="input1" Width="82%">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                </td>
                                <td>
                                    ������ϵ��
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtEmergencyContacts" runat="server" size="28" CssClass="input1"
                                        Width="82%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                </td>
                                <td>
                                    ��������
                                </td>
                                <td>
                                    <asp:TextBox ID="txtChildName" runat="server" Width="60%" CssClass="input1"></asp:TextBox>
                                </td>
                                <td>
                                    ��������
                                </td>
                                <td>
                                    <asp:TextBox ID="txtChildBirthday" runat="server" CssClass="input1" Width="60%"></asp:TextBox>
                                    <asp:Label ID="lblChildBirthdayMessage" runat="server" CssClass="psword_f"></asp:Label>
                                    <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtChildBirthday"
                                        Format="yyyy-MM-dd">
                                    </ajaxToolKit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                </td>
                                <td>
                                    ��������
                                </td>
                                <td>
                                    <asp:TextBox ID="txtChildName2" runat="server" Width="60%" CssClass="input1"></asp:TextBox>
                                </td>
                                <td>
                                    ��������
                                </td>
                                <td>
                                    <asp:TextBox ID="txtChildBirthday2" runat="server" CssClass="input1" Width="60%"></asp:TextBox>
                                    <asp:Label ID="lblChildBirthday2Message" runat="server" CssClass="psword_f"></asp:Label>
                                    <ajaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtChildBirthday2"
                                        Format="yyyy-MM-dd">
                                    </ajaxToolKit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:Button ID="btnAction" CssClass="inputbt" runat="server" Text="������Ա" OnClick="btnAction_Click" />
                                    <asp:Label ID="lblFamilyMemberMessage" runat="server" CssClass="psword_f"></asp:Label>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td width="100%" align="center">
            <div id="Result" runat="server" style="width: 100%;">
                <br />
                <table width="98%">
                    <tr>
                        <td align="left">
                            <span class="font14px">��ͥ��Ա</span>
                        </td>
                    </tr>
                </table>
                <table id="divResult" runat="server" class="linetable" cellpadding="0" cellspacing="0"
                    border="0" width="98%">
                    <tr>
                        <td>
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:GridView ID="grd" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                            GridLines="None" Width="100%" OnPageIndexChanging="grd_PageIndexChanging" OnRowDataBound="grd_RowDataBound">
                                            <HeaderStyle CssClass="headerstyleblue" Height="28px" HorizontalAlign="Center" />
                                            <RowStyle Height="28px" CssClass="GridViewRowLink" />
                                            <AlternatingRowStyle CssClass="table_g" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("Name") %>' CommandName="HiddenPostButtonCommand"
                                                            runat="server" Text="" Style="display: none;" />
                                                    </ItemTemplate>
                                                    <ItemStyle />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="HashCode" HeaderText="Id" Visible="false">
                                                    <ItemStyle Width="0%" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Name" HeaderText="����">
                                                    <ItemStyle Width="12%" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Relationship" HeaderText="��ν">
                                                    <ItemStyle Width="8%" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="��������" HeaderStyle-Width="22%">
                                                    <ItemTemplate>
                                                        <%#Eval("Birthday", "{0:yyyy-MM-dd}")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Age" HeaderText="����">
                                                    <ItemStyle Width="6%" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Company" HeaderText="��˾">
                                                    <ItemStyle Width="17%" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Remark" HeaderText="��ע">
                                                    <ItemStyle Width="17%" HorizontalAlign="Center" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnUpdate" runat="server" CommandArgument='<%# Eval("HashCode")%>'
                                                            CommandName="BtnUpdateClick" OnCommand="BtnUpdate_Click" Text="��    ��"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="7%" HorizontalAlign="Right" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%# Eval("HashCode")%>'
                                                            CommandName="BtnDeleteClick" OnCommand="BtnDelete_Click" Text="ɾ    ��" OnClientClick="Confirmed = confirm('ȷ��Ҫɾ����'); return Confirmed;"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerTemplate>
                                                <%--		<div class="pages">
		    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton" CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    ��һҳ</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton" CommandArgument="Next" CommandName="Page"  Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    ��һҳ</asp:LinkButton>
		</div>      --%>
                                                <uc1:PageTemplate ID="PageTemplate1" runat="server" />
                                            </PagerTemplate>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </td>
    </tr>
    <tr>
        <td style="height: 10px;">
        </td>
    </tr>
</table>
