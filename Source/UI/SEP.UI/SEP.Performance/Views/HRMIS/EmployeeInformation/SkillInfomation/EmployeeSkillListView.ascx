<%@ Import Namespace="SEP.HRMIS.Model" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeSkillListView.ascx.cs"
    Inherits="SEP.Performance.Views.EmployeeInformation.SkillInfomation.EmployeeSkillListView" %>
<%@ Register Src="../../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<link href="../../CSS/style.css" rel="stylesheet" type="text/css" />
<table width="98%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td height="20" align="center">
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td align="left" style="height: 60px">
                        <table width="100%" border="0" cellpadding="0" style="border-collapse: separate;"
                            cellspacing="10">
                            <tr>
                                <td width="2%" align="right">
                                </td>
                                <td width="41%" colspan="3">
                                    &nbsp;&nbsp;
                                    <asp:Button ID="btnAdd" runat="server" CssClass="inputbt" OnClick="btnAdd_Click"
                                        Text="新  增" />
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
            <div id="Div1" runat="server" style="width: 100%;">
                <br />
                <table width="98%">
                    <tr>
                        <td align="left">
                            <span class="font14px">员工技能</span>
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
                                                        <!--<asp:Button ID="btnHiddenPostButton"  CommandName="HiddenPostButtonCommand" runat="server" Text="" style=" display:none;"/>　!-->
                                                    </ItemTemplate>
                                                    <ItemStyle Width="2%" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="HashCode" HeaderText="Id" Visible="false">
                                                    <ItemStyle Width="0%" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="技能类型">
                                                    <ItemTemplate>
                                                        <%#Eval("Skill.SkillType.Name")%>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="12%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="技能">
                                                    <ItemTemplate>
                                                        <%#Eval("Skill.SkillName")%>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="12%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="技能等级">
                                                    <ItemTemplate>
                                                        <%#AssessActivityUtility.GetLevelNameByType((SkillLevelEnum)Eval("SkillLevel"))%>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="12%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="分数">
                                                    <ItemTemplate>
                                                        <%#Eval("Score")%>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="12%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="备注">
                                                    <ItemTemplate>
                                                        <%#Eval("Remark")%>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="12%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnUpdate" runat="server" CommandArgument='<%# Eval("HashCode")%>'
                                                            CommandName="BtnUpdateClick" OnCommand="BtnUpdate_Click" Text="修    改"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="7%" HorizontalAlign="Right" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%# Eval("HashCode")%>'
                                                            CommandName="BtnDeleteClick" OnCommand="BtnDelete_Click" Text="删    除" OnClientClick="Confirmed = confirm('确定要删除吗？'); return Confirmed;"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerTemplate>
                                                <uc1:PageTemplate ID="PageTemplate1" runat="server" />
                                                <%--		<div class="pages">
		    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton" CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    上一页</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton" CommandArgument="Next" CommandName="Page"  Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    下一页</asp:LinkButton>
		</div>        --%>
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
