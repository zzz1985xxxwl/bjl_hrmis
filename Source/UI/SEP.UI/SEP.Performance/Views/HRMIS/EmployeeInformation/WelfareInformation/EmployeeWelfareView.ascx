<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeWelfareView.ascx.cs"
    Inherits="SEP.Performance.Views.EmployeeInformation.WelfareInformation.EmployeeWelfareView" %>
<%@ Register Src="../../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<table cellpadding="0" cellspacing="0" border="0" width="100%">
    <tr>
        <td align="left">
            <table width="100%" border="0" cellpadding="0" style="border-collapse: separate;"
                cellspacing="10">
                <tr>
                    <td style="width: 2%;">
                    </td>
                    <td style="width: 14%;">
                        �ù�����&nbsp;<span class="redstar">*</span>
                    </td>
                    <td style="width: 84%;" align="left" colspan="3">
                        <asp:DropDownList ID="ddlWorkType" runat="server" Width="30%">
                        </asp:DropDownList>
                        <asp:Label ID="MsgWorkType" runat="server" CssClass="psword_f"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        ��ס֤������&nbsp;
                    </td>
                    <td colspan="3">
                        <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd"
                            TargetControlID="txtResidentDate">
                        </ajaxToolKit:CalendarExtender>
                        <asp:TextBox ID="txtResidentDate" Width="29%" runat="server" CssClass="input1"></asp:TextBox><asp:Label
                            ID="lblDateMsg" runat="server" CssClass="psword_f"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        ��ס֤�������&nbsp;
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtResidentOrg" runat="server" CssClass="input1" Width="82%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        ��������&nbsp;
                    </td>
                    <td align="left" colspan="3">
                        <asp:TextBox ID="txtWelfareDescription" runat="server" CssClass="input1" Width="82%"
                            TextMode="MultiLine" Height="150px" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        ���ʿ��ʺ�&nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtSalaryCardNo" runat="server" CssClass="input1" Width="65%"></asp:TextBox>
                    </td>
                    <td>
                        ���ʿ���������&nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtSalaryCardBank" runat="server" CssClass="input1" Width="65%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td style="width: 14%;">
                        �������ʺ�&nbsp;
                    </td>
                    <td style="width: 35%;" align="left">
                        <asp:TextBox ID="txtAccumulationFundAccount" Width="65%" runat="server" CssClass="input1"> </asp:TextBox>
                        <asp:Label ID="lbAccumulationFundAccount" runat="server" CssClass="psword_f"></asp:Label>
                    </td>
                    <td style="width: 14%;">
                        ���乫�����ʺ�&nbsp;
                    </td>
                    <td style="width: 35%;" align="left">
                        <asp:TextBox ID="txtSupplyAccount" Width="65%" runat="server" CssClass="input1"> </asp:TextBox>
                    </td>
                </tr>
                <div runat="server" id="divWelfare">
                    <tr>
                        <td>
                        </td>
                        <td>
                            �籣����&nbsp;
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddSocialSecurityType" Width="67%" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            ���乫�������&nbsp;
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtSupplyBase" Width="65%" runat="server" CssClass="input1"> </asp:TextBox>
                            <asp:Label ID="lblSupplyBase" runat="server" CssClass="psword_f"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            �籣����&nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="txtSocialSecurityBase" Width="60%" runat="server" CssClass="input1"> </asp:TextBox>&nbsp;Ԫ
                            <asp:Label ID="lbSocialSecurityBase" runat="server" CssClass="psword_f"></asp:Label>
                        </td>
                        <td>
                            ��Ч����&nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="txtSocialSecurityYear" runat="server" Width="18%" CssClass="input1"> </asp:TextBox>&nbsp;��
                            <asp:TextBox ID="txtSocialSecurityMonth" runat="server" Width="8%" CssClass="input1"> </asp:TextBox>&nbsp;��
                            <asp:Label ID="lbSocialSecurityYearMonth" runat="server" CssClass="psword_f"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            ���������&nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="txtAccumulationFundBase" Width="60%" runat="server" CssClass="input1"></asp:TextBox>&nbsp;Ԫ
                            <asp:Label ID="lbAccumulationFundBase" runat="server" CssClass="psword_f"></asp:Label>
                        </td>
                        <td>
                            ��Ч����&nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="txtAccumulationFundYear" runat="server" Width="18%" CssClass="input1"> </asp:TextBox>&nbsp;��
                            <asp:TextBox ID="txtAccumulationFundMonth" runat="server" Width="8%" CssClass="input1"> </asp:TextBox>&nbsp;��
                            <asp:Label ID="lbAccumulationFundYearMonth" runat="server" CssClass="psword_f"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            ���Ͻɷѻ���&nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="txtYangLaoBase" Width="60%" runat="server" CssClass="input1"></asp:TextBox>&nbsp;Ԫ
                            <asp:Label ID="lblYangLaoBase" runat="server" CssClass="psword_f"></asp:Label>
                        </td>
                        <td>
                            ʧҵ�ɷѻ���&nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="txtShiYeBase" Width="60%" runat="server" CssClass="input1"></asp:TextBox>&nbsp;Ԫ
                            <asp:Label ID="lblShiYeBase" runat="server" CssClass="psword_f"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            ҽ�ƽɷѻ���&nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="txtYiLiaoBase" Width="60%" runat="server" CssClass="input1"></asp:TextBox>&nbsp;Ԫ
                            <asp:Label ID="lblYiLiaoBase" runat="server" CssClass="psword_f"></asp:Label>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                            <table id="tbWelfareHistory" runat="server" width="100%" border="0" cellpadding="0"
                                cellspacing="0">
                                <tr>
                                    <td height="10" align="center">
                                        <table width="98%" class="linetable" cellpadding="0" cellspacing="0">
                                            <br />
                                            <span class="font14px">�籣������ʷ</span>
                                            <tr>
                                                <td width="100%">
                                                    <asp:GridView ID="gvWelfareHistory" Width="100%" runat="server" AutoGenerateColumns="False"
                                                        AllowPaging="True" OnPageIndexChanging="gvWelfareHistory_PageIndexChanging" BorderStyle="None"
                                                        GridLines="None" OnRowDataBound="gvWelfareHistory_RowDataBound">
                                                        <HeaderStyle Height="28px" CssClass="headerstyleblue" />
                                                        <RowStyle Height="28px" CssClass="GridViewRowLink" />
                                                        <AlternatingRowStyle CssClass="table_g" />
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("EmployeeWelfareHistoryID") %>'
                                                                        CommandName="HiddenPostButtonCommand" runat="server" Text="" Style="display: none;" />
                                                                </ItemTemplate>
                                                                <ItemStyle Width="2%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="�籣����">
                                                                <ItemTemplate>
                                                                    <%#Eval("EmployeeWelfare.SocialSecurity.Type.Name")%></a>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="8%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="�籣����">
                                                                <ItemTemplate>
                                                                    <%#Eval("EmployeeWelfare.SocialSecurity.Base")%></a>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="8%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="��Ч����">
                                                                <ItemTemplate>
                                                                    <%#Eval("EmployeeWelfare.SocialSecurity.EffectiveYearMonth", "{0:yyyy-MM}")%></a>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="8%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="�������ʺ�">
                                                                <ItemTemplate>
                                                                    <%#Eval("EmployeeWelfare.AccumulationFund.Account")%></a>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="8%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="���������">
                                                                <ItemTemplate>
                                                                    <%#Eval("EmployeeWelfare.AccumulationFund.Base")%></a>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="8%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="��Ч����">
                                                                <ItemTemplate>
                                                                    <%#Eval("EmployeeWelfare.AccumulationFund.EffectiveYearMonth", "{0:yyyy-MM}")%></a>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="9%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="���乫�����ʺ�">
                                                                <ItemTemplate>
                                                                    <%#Eval("EmployeeWelfare.AccumulationFund.SupplyAccount")%></a>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="9%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="���乫�������">
                                                                <ItemTemplate>
                                                                    <%#Eval("EmployeeWelfare.AccumulationFund.SupplyBase")%></a>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="9%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="���Ͻɷѻ���">
                                                                <ItemTemplate>
                                                                    <%#Eval("EmployeeWelfare.SocialSecurity.YangLaoBase")%></a>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="8%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="ʧҵ�ɷѻ���">
                                                                <ItemTemplate>
                                                                    <%#Eval("EmployeeWelfare.SocialSecurity.ShiYeBase")%></a>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="8%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="ҽ�ƽɷѻ���">
                                                                <ItemTemplate>
                                                                    <%#Eval("EmployeeWelfare.SocialSecurity.YiLiaoBase")%></a>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="8%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="������">
                                                                <ItemTemplate>
                                                                    <%#Eval("AccountsBackName")%></a>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="9%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="����ʱ��">
                                                                <ItemTemplate>
                                                                    <%#Eval("OperationTime")%></a>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="12%" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <PagerTemplate>
                                                            <%--		<div class="pages">
		    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton" CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    ��һҳ</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton" CommandArgument="Next" CommandName="Page"  Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    ��һҳ</asp:LinkButton>
		</div>        --%>
                                                            <uc1:PageTemplate ID="PageTemplate1" runat="server" />
                                                        </PagerTemplate>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </div>
            </table>
        </td>
    </tr>
</table>
