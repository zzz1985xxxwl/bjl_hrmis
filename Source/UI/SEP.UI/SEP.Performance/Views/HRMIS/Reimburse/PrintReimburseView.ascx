<%@ Import Namespace="SEP.HRMIS.Model" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PrintReimburseView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.Reimburse.PrintReimburseView" %>
<table id="tbMessage" runat="server" width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td align="center">
            <table width="98%" border="0" cellpadding="10" cellspacing="0">
                <tr>
                    <td align="center">
                        <span style="font-size: 24px; font-weight: bold;">
                            ��������ҵ�Զ������޹�˾</span>
                    </td>
                </tr>
                <tr>
                    <td height="42px" align="center" style="vertical-align: middle;">
                        <asp:Label ID="lblTitle" runat="server" Style="font-size: 16px"></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<table cellpadding="0" cellspacing="0" border="0" width="100%">
    <tr>
        <td height="32px" align="center" valign="middle">
            <table width="98%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <%--        <td height="32px" width="25%" align="left">
            ������˾��  <asp:Label ID="lblCompany" runat="server"></asp:Label>
		</td>--%>
                    <td height="25px" width="33%" align="left">
                        ���ţ�
                        <asp:Label ID="lblDepartment" runat="server"></asp:Label>
                    </td>
                    <td height="25px" width="33%" align="left">
                        �����ˣ�
                        <asp:Label ID="lblApplier" runat="server"></asp:Label>
                    </td>
                    <td height="25px" width="33%" align="right">
                        ����ʱ�䣺
                        <asp:Label ID="lblApplyDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td height="25px" width="33%" align="left">
                        ����������
                        <asp:Label ID="lblPaperCount" runat="server"></asp:Label>
                    </td>
                    <td height="25px" width="33%" align="left" colspan="2">
                        ����ʱ�䣺
                        <asp:Label ID="lblConsumeDate" runat="server"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td  height="25px" colspan="3" align="left">
                        ˵����
                        <asp:Label ID="lblDiscription" runat="server"></asp:Label>
                    </td>
                </tr>
                <%--      <tr id = "isHidden1" runat = "server">
        <td height="25px" width="33%" align="left">
            Ŀ�ĵأ�  <asp:Label ID="lblDestinations" runat="server"></asp:Label>
		</td>
        <td height="25px" width="33%"  align="left">
            �ͻ���  <asp:Label ID="lblCustomerName" runat="server"></asp:Label>
		</td>
        <td height="25px" width="33%"  align="left">
            ��Ŀ��  <asp:Label ID="lblProjectName" runat="server"></asp:Label>
		</td>
      </tr>--%>
            </table>
        </td>
    </tr>
</table>
<table cellpadding="0" cellspacing="0" border="0" width="100%">
    <tr>
        <td height="60" align="center">
            <table id="tbReimburseItem" runat="server" width="100%" border="0" cellpadding="0"
                cellspacing="0" style="border-left: 1px solid #000000; border-right: 1px solid #000000;
                border-bottom: 1px solid #000000; border-top: 1px solid #000000;">
                <tr>
                    <td>
                        <asp:GridView GridLines="None" Width="100%" ID="gvReimburseItem" runat="server" AutoGenerateColumns="false"
                            AllowPaging="false">
                            <HeaderStyle Height="28px" HorizontalAlign="Center" />
                            <RowStyle Height="28px" CssClass="GridViewRowLink" />
                            <Columns>
                                <asp:TemplateField HeaderText="�������">
                                    <ItemTemplate>
                                        <%#ReimburseItem.GetReimburseTypeNameByReimburseType((ReimburseTypeEnum)Eval("ReimburseTypeEnum"))%>
                                    </ItemTemplate>
                                    <ItemStyle Width="15%" CssClass="kqfont03" HorizontalAlign="Center"/>
                                    <HeaderStyle CssClass="kqfont03" />
                                </asp:TemplateField>
                                <%--                                <asp:TemplateField HeaderText="����ʱ��">
                                    <ItemTemplate> 
                                        <%# Eval("ConsumeDateFrom", "{0:yyyy-MM-dd}")%>
                                        <%# Eval("ConsumeDateTo", "{0:yyyy-MM-dd}") == Eval("ConsumeDateFrom", "{0:yyyy-MM-dd}") ? "" : (" -- " + Eval("ConsumeDateTo", "{0:yyyy-MM-dd}"))%>
                                    </ItemTemplate>
                                        <ItemStyle Width="13%"  CssClass="kqfont03"/>
                                        <HeaderStyle CssClass="kqfont03" />
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="���ѵص�">
                                    <ItemTemplate>
                                        <%# Eval("ConsumePlace").ToString()!=""?Eval("ConsumePlace"):"--"%>
                                    </ItemTemplate>
                                    <ItemStyle Width="16%" CssClass="kqfont03" HorizontalAlign="Center" />
                                    <HeaderStyle CssClass="kqfont03" />
                                </asp:TemplateField>
                                <%--                                <asp:TemplateField HeaderText="������Ŀ">
                                    <ItemTemplate> 
                                        <%# Eval("ProjectName")%>
                                    </ItemTemplate>
                                        <ItemStyle Width="10%" CssClass="kqfont03" />
                                        <HeaderStyle CssClass="kqfont03" />
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="����">
                                    <ItemTemplate>
                                        &nbsp;&nbsp;<%# Eval("Reason")%>
                                    </ItemTemplate>
                                    <ItemStyle Width="20%" CssClass="kqfont03" HorizontalAlign="Left" />
                                    <HeaderStyle CssClass="kqfont03" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="�ͻ�">
                                    <ItemTemplate>
                                        &nbsp;&nbsp;<%# Eval("CustomerName")%>
                                    </ItemTemplate>
                                    <ItemStyle Width="36%" CssClass="kqfont03" HorizontalAlign="Left" />
                                    <HeaderStyle CssClass="kqfont03" />
                                </asp:TemplateField>
                                <%--                                <asp:TemplateField HeaderText="��������">
                                    <ItemTemplate> 
                                        <%# Eval("PaperCount")%>
                                    </ItemTemplate>
                                        <ItemStyle Width="7%"  CssClass="kqfont03"/>
                                        <HeaderStyle CssClass="kqfont03" />
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="���">
                                    <ItemTemplate>
                                        <%#Eval("ExchangeSymbol")%><%#Eval("TotalCost")%>
                                    </ItemTemplate>
                                    <ItemStyle Width="15%" CssClass="kqfont03" HorizontalAlign="Center"/>
                                    <HeaderStyle CssClass="kqfont03" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div>
                            <table cellspacing="0" border="0" style="width: 100%; border-collapse: collapse;">
                                <tr>
                                    <td height="28px" width="15%" class="kqfont04" style="text-align:center;">
                                        �����ܶ�
                                    </td>
                                    <td width="16%" class="kqfont04">
                                        <asp:Label ID="lblExchangeRateName" runat="server"></asp:Label>����д��
                                    </td>
                                    <td width="48%" class="kqfont04" align="left">
                                        <div style="position: absolute;">
                                            <table>
                                                <tr>
                                                    <td nowrap="nowrap">
                                                        &nbsp;&nbsp;<asp:Label ID="lblTotalCostCH" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        &nbsp;&nbsp;
                                    </td>
                                    <%--                <td Width="17%" class="kqfont06">&nbsp;&nbsp;</td>
                <td Width="5%" class="kqfont06" align="left">&nbsp;&nbsp;</td>--%>
                                    <td width="8%" class="kqfont04" style="text-align:center;border-right:1px solid #000;">
                                        �ܼ�
                                    </td>
                                    <td width="13%" class="kqfont05" style="text-align:center;">
                                        <asp:Label ID="lblExchangeSymbol" runat="server"></asp:Label><asp:Label ID="lblTotalCost" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<table cellpadding="0" cellspacing="0" border="0" width="100%">
    <tr>
        <td height="32px" align="center" valign="middle">
            <table width="98%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td height="32px" width="15%" align="left">
                        CEO/CFO��
                    </td>
                    <td width="10%" align="left">
                        <asp:Image ID="imgCEO" runat="server" ImageAlign="Left" Width="100px" Height="30px"
                            Visible="false" BorderWidth="0px" BorderColor="#919191" />
                    </td>
                    <td width="15%" align="left">
                        ������ˣ�
                    </td>
                    <td width="10%" align="left">
                        <asp:Image ID="imgFinance" runat="server" ImageAlign="Left" Width="100px" Height="30px"
                            Visible="false" BorderWidth="0px" BorderColor="#919191" />
                    </td>
                    <td width="15%" align="left">
                        ���ž���
                    </td>
                    <td width="10%" align="left">
                        <asp:Image ID="imgDepartmentLeader" runat="server" ImageAlign="Left" Width="100px"
                            Height="30px" Visible="false" BorderWidth="0px" BorderColor="#919191" />
                    </td>
                    <td width="15%" align="left">
                        ����ˣ�
                    </td>
                    <td width="10%">
                    </td>
                </tr>
                <%--      <tr id="isHidden2" runat = "server">
        <td height="32px" width="8%" align="left" colspan="2">
            ���������� 
		</td>
        <td height="32px" width="10%"  align="left" colspan="5">
            ������� 
		</td>
      </tr>
      
      <tr id="isHidden3" runat = "server">
        <td height="32px" width="8%" align="left" colspan="7">
            ����ܶ 
		</td>
      </tr>--%>
            </table>
        </td>
    </tr>
</table>
