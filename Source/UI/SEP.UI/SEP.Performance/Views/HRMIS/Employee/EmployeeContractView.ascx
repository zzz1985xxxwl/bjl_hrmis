<%@ Import Namespace="SEP.HRMIS.Model" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="EmployeeContractView.ascx.cs"
    Inherits="SEP.Performance.Views.Employee.EmployeeContractView" %>
<div id="tbNoDataMessage" runat="server" class="leftitbor">
    <asp:Label ID="lblResultMessage" runat="server" Text="" CssClass="font14b" />
</div>
<div class="leftitbor2">
    <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
    <asp:Label ID="lblEmployeeID" runat="server" Visible="false"></asp:Label>
</div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td width="2%" align="left">
            </td>
            <td width="10%" align="left">
                合同类型&nbsp;<span class="redstar">*</span>&nbsp;</td>
            <td align="left" width="88%" >
                <asp:DropDownList ID="listType" runat="server" Width="165px" OnSelectedIndexChanged="listType_SelectedIndexChanged">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td align="left">
            </td>
            <td align="left">
                合同时间&nbsp;<span class="redstar">*</span>&nbsp;</td>
            <td align="left" valign="middle">
                <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtStartTime"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
                <ajaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd"
                    TargetControlID="txtEndTime">
                </ajaxToolKit:CalendarExtender>
                <asp:TextBox ID="txtStartTime" runat="server" CssClass="input1" Width="156px"></asp:TextBox>--<asp:TextBox
                    ID="txtEndTime" runat="server" CssClass="input1" Width="160px"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;<asp:Label ID="lblErrorTime" runat="server" CssClass="psword_f"></asp:Label></td>
        </tr>
<tr id="trBookMark" runat="server" class="green2">
<td colspan="3">
    <table width="100%" id="tbBookMark" runat="server" border="0">
    </table>
</td>
</tr>
        <tr>
            <td>
            </td>
            <td align="left">
                备注</td>
            <td align="left">
                <asp:TextBox ID="txtRemark" runat="server" CssClass="grayborder" Rows="7" TextMode="MultiLine" Height="100px"
                    Width="60%"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="left">
            </td>
            <td align="left" colspan="2">
                <table id="tbCondition" runat="server" width="100%">
                    <tr>
                        <td align="left">
                            <span class="font14px">系统自动发起考核设置</span></td>
                    </tr>
                    <tr>
                        <td align="left">
                            <%--<table width="100%" class="linetable">
                                <tr>
                                    <td>--%>
                            <div id="tbEmployeeGridView" runat="server" class="linetablediv">
                                <asp:GridView GridLines="None" Width="100%" ID="gvCondition" runat="server" AutoGenerateColumns="false"
                                    AllowPaging="true" OnPageIndexChanging="gvAssessActivityList_PageIndexChanging"
                                    OnRowCommand="gvCondition_RowCommand" OnRowDataBound="gvCondition_RowDataBound">
                                    <HeaderStyle Height="28px" CssClass="headerstyleblue" />
                                    <RowStyle Height="28px" CssClass="GridViewRowLink" />
                                    <AlternatingRowStyle CssClass="table_g" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="btnHiddenPostButton" CommandArgument='<%# ((GridViewRow)Container).RowIndex %>'
                                                    CommandName="HiddenPostButtonCommand" runat="server" Text="" Style="display: none;" />
                                            </ItemTemplate>
                                            <ItemStyle Width="2%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="发起时间">
                                            <ItemTemplate>
                                                <%#Eval("ApplyDate", "{0:yyyy-MM-dd}")%>
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="绩效考核性质">
                                            <ItemTemplate>
                                                <%#AssessActivityUtility.GetCharacterNameByType((AssessCharacterType)Eval("ApplyAssessCharacterType"))%>
                                            </ItemTemplate>
                                            <ItemStyle Width="25%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="绩效考核时间段">
                                            <ItemTemplate>
                                                <%#Eval("AssessScopeFrom", "{0:yyyy-MM-dd}")%>
                                                ---
                                                <%#Eval("AssessScopeTo", "{0:yyyy-MM-dd}")%>
                                            </ItemTemplate>
                                            <ItemStyle Width="29%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbModifyCondition" Text="修改" OnClientClick="Confirmed=false;"
                                                    OnCommand="lbModifyCondition_Click" CommandName="ModifyCondition" runat="server"
                                                    CommandArgument='<%# ((GridViewRow)Container).RowIndex %>' />
                                            </ItemTemplate>
                                            <ItemStyle Width="10%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbDeleteCondition" Text="删除" OnCommand="lbDeleteCondition_Click"
                                                    OnClientClick="Confirmed=false;" CommandName="DeleteCondition" runat="server"
                                                    CommandArgument='<%# ((GridViewRow)Container).RowIndex %>' />
                                            </ItemTemplate>
                                            <ItemStyle Width="10%" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerTemplate>
                                        <div class="pages">
                                            <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton"
                                                CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
上一页</asp:LinkButton>
                                            <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton"
                                                CommandArgument="Next" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
下一页</asp:LinkButton>
                                        </div>
                                    </PagerTemplate>
                                </asp:GridView>
                            </div>
                            <%--</td>
                                </tr>
                            </table>--%>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="display: none">
            <td>
            </td>
            <td>
                附件</td>
            <td>
                <asp:TextBox ID="txtAttachment" runat="server" CssClass="grayborder" Rows="7" TextMode="MultiLine"
                    Width="60%"></asp:TextBox></td>
        </tr>
    </table>
</div>
<div class="tablebt">
    <asp:Button ID="btnOk" runat="server" Text="确  定" OnClick="btnOk_Click" CssClass="inputbt" />
    <asp:Button ID="btnCancle" runat="server" Text="取  消" OnClick="btnCancle_Click" CssClass="inputbt" />
    <asp:Button ID="btnGetSystemSet" runat="server" Text="自动生成考核时间" OnClick="btnGetSystemSet_Click"
        CssClass="inputbtlong" />
    <asp:Button ID="btnAddFirstCondition" runat="server" Text="新增考核时间" OnClick="btnAddCondition_Click"
        CssClass="inputbtlong" />
</div>
