<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PrintTravelReimburseView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.Reimburse.PrintTravelReimburseView" %>
<%@ Import Namespace="SEP.HRMIS.Model" %>
<table id="tbMessage" runat="server" width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td align="center">
            <table width="98%" border="0" cellpadding="10" cellspacing="0">
                <tr>
                    <td align="center">
                        <span style="font-size: 24px; font-weight: bold;">贝加莱工业自动化有限公司</span>
                    </td>
                </tr>
                <tr>
                    <td height="42px" align="center">
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
                    <td height="25px" width="33%" align="left">
                        部门：
                        <asp:Label ID="lblDepartment" runat="server"></asp:Label>
                    </td>
                    <td height="25px" width="33%" align="left">
                        申请人：
                        <asp:Label ID="lblApplier" runat="server"></asp:Label>
                    </td>
                    <td height="25px" width="33%" align="right">
                        申请时间：
                        <asp:Label ID="lblApplyDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td height="25px" width="33%" align="left">
                        单据张数：
                        <asp:Label ID="lblPaperCount" runat="server"></asp:Label>
                    </td>
                    <td height="25px" width="33%" align="left" colspan="2">
                        消费时间：
                        <asp:Label ID="lblConsumeDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td height="25px" width="33%" align="left">
                        目的地：
                        <asp:Label ID="lblDestinations" runat="server"></asp:Label>
                    </td>
                    <%-- <td height="25px" width="33%"  align="left">
            客户：  <asp:Label ID="lblCustomerName" runat="server"></asp:Label>
		</td>--%>
                    <td height="25px" width="33%" align="left">
                        项目：
                        <asp:Label ID="lblProjectName" runat="server"></asp:Label>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td  height="25px" colspan="3" align="left">
                        说明：
                        <asp:Label ID="lblDiscription" runat="server"></asp:Label>
                    </td>
                </tr>
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
                                <asp:TemplateField HeaderText="费用类别">
                                    <ItemTemplate>
                                        <%#ReimburseItem.GetReimburseTypeNameByReimburseType((ReimburseTypeEnum)Eval("ReimburseTypeEnum"))%>
                                    </ItemTemplate>
                                    <ItemStyle Width="15%" CssClass="kqfont03" HorizontalAlign="Center" />
                                    <HeaderStyle CssClass="kqfont03" />
                                </asp:TemplateField>
                                <%--                                <asp:TemplateField HeaderText="消费时间">
                                    <ItemTemplate> 
                                        <%# Eval("ConsumeDateFrom", "{0:yyyy-MM-dd}")%>
                                        <%# Eval("ConsumeDateTo", "{0:yyyy-MM-dd}") == Eval("ConsumeDateFrom", "{0:yyyy-MM-dd}") ? "" : (" -- " + Eval("ConsumeDateTo", "{0:yyyy-MM-dd}"))%>
                                    </ItemTemplate>
                                        <ItemStyle Width="13%"  CssClass="kqfont03"/>
                                        <HeaderStyle CssClass="kqfont03" />
                                </asp:TemplateField>--%>
                                <%--                                <asp:TemplateField HeaderText="消费地点">
                                    <ItemTemplate> 
                                        <%# Eval("ConsumePlace").ToString()!=""?Eval("ConsumePlace"):"--"%>                                        
                                    </ItemTemplate>
                                        <ItemStyle Width="16%" CssClass="kqfont03" />
                                        <HeaderStyle CssClass="kqfont03" />
                                </asp:TemplateField>--%>
                                <%--                                <asp:TemplateField HeaderText="消费项目">
                                    <ItemTemplate> 
                                        <%# Eval("ProjectName")%>
                                    </ItemTemplate>
                                        <ItemStyle Width="10%" CssClass="kqfont03" />
                                        <HeaderStyle CssClass="kqfont03" />
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="事由">
                                    <ItemTemplate>
                                        &nbsp;&nbsp;<%# Eval("Reason")%>
                                    </ItemTemplate>
                                    <ItemStyle Width="27%" CssClass="kqfont03" HorizontalAlign="Left" />
                                    <HeaderStyle CssClass="kqfont03" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="客户">
                                    <ItemStyle Width="45%" CssClass="kqfont03" HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        &nbsp;&nbsp;<%# Eval("CustomerName")%>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="kqfont03" />
                                </asp:TemplateField>
                                <%--                                <asp:TemplateField HeaderText="单据张数">
                                    <ItemTemplate> 
                                        <%# Eval("PaperCount")%>
                                    </ItemTemplate>
                                        <ItemStyle Width="7%"  CssClass="kqfont03"/>
                                        <HeaderStyle CssClass="kqfont03" />
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="金额">
                                    <ItemTemplate>
                                        <%#Eval("ExchangeSymbol")%><%#Eval("TotalCost")%>
                                    </ItemTemplate>
                                    <ItemStyle Width="15%" CssClass="kqfont03" HorizontalAlign="Center" />
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
                                    <td height="28px" width="15%" class="kqfont04" style="text-align: center;">
                                        报销总额
                                    </td>
                                    <td width="16%" class="kqfont04" style="text-align: center;">
                                        <asp:Label ID="lblExchangeRateName" runat="server"></asp:Label>（大写）
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
                                    <td width="8%" class="kqfont04" style="text-align: center; border-right: 1px solid #000;">
                                        总计
                                    </td>
                                    <td width="13%" class="kqfont05" style="text-align: center;">
                                        <asp:Label ID="lblExchangeSymbol" runat="server"></asp:Label><asp:Label ID="lblTotalCost"
                                            runat="server"></asp:Label>
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
                        CEO/CFO：
                    </td>
                    <td width="10%" align="left">
                        <asp:Image ID="imgCEO" runat="server" ImageAlign="Left" Width="100px" Height="30px"
                            Visible="false" BorderWidth="0px" BorderColor="#919191" />
                    </td>
                    <td width="15%" align="left">
                        财务审核：
                    </td>
                    <td width="10%" align="left">
                        <asp:Image ID="imgFinance" runat="server" ImageAlign="Left" Width="100px" Height="30px"
                            Visible="false" BorderWidth="0px" BorderColor="#919191" />
                    </td>
                    <td width="15%" align="left">
                        部门经理：
                    </td>
                    <td width="10%" align="left">
                        <asp:Image ID="imgDepartmentLeader" runat="server" ImageAlign="Left" Width="100px"
                            Height="30px" Visible="false" BorderWidth="0px" BorderColor="#919191" />
                    </td>
                    <td width="15%" align="left">
                        领款人：
                    </td>
                    <td width="10%">
                    </td>
                </tr>
                <tr>
                    <td height="32px" align="left" colspan="2">
                        出差天数：
                    </td>
                    <td align="left" colspan="5">
                        出差补贴：
                    </td>
                </tr>
                <tr>
                    <td height="32px" align="left" colspan="7">
                        领款总额：
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<%--<script type="text/javascript">
function document.oncontextmenu(){event.returnValue=false;}//屏蔽鼠标右键 
function document.onkeydown(){ event.returnValue=false;}//屏蔽 onkeydown
</script>
<object  id="WebBrowser"  width="0"  height="0"  classid="CLSID:8856F961-340A-11D0-A96B-00C04FD705A2">     
</object> 
<input type="button" value="打印" class="buttonNoPrint"  onclick="if(confirm('在打印前，请确定是横向打印。你可以点击“打印预览”查看。'))document.all.WebBrowser.ExecWB(6,1);"/>&nbsp;&nbsp;
<input type="button" value="打印预览" class="buttonNoPrint"  onclick="document.all.WebBrowser.ExecWB(7,1);"/>&nbsp;&nbsp;
<input type="button" value="页面设置" class="buttonNoPrint"  onclick="document.all.WebBrowser.ExecWB(8,1);"/>  --%>
