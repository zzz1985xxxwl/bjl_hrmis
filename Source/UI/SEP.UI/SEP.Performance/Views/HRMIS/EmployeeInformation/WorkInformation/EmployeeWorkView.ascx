<%@ Import Namespace="SEP.HRMIS.Model" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeWorkView.ascx.cs"
    Inherits="SEP.Performance.Views.EmployeeInformation.WorkInformation.EmployeeWorkView" %>
<%@ Register Src="../../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<input id="hidAccountID" class="accountidhidden" type="hidden" runat="server" />
<table cellpadding="0" cellspacing="0" border="0" width="100%">
    <tr>
        <td align="left">
            <table width="100%" border="0" cellpadding="0" style="border-collapse: separate;"
                cellspacing="10">
                <tr>
                    <td>
                        <table width="100%" border="0" cellpadding="0" style="border-collapse: separate;"
                            cellspacing="10">
                            <tr>
                                <td style="width: 2%;">
                                    &nbsp;
                                </td>
                                <td style="width: 11%;">
                                    所属部门
                                </td>
                                <td style="width: 38%;">
                                    <asp:Label ID="lblDept" runat="server"></asp:Label>
                                </td>
                                <td style="width: 11%;">
                                    部门经理
                                </td>
                                <td style="width: 38%;">
                                    <asp:TextBox ID="txtDepLeader" runat="server" Width="60%" CssClass="input1" Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    职位
                                </td>
                                <td>
                                    <asp:Label ID="lblPosition" runat="server"></asp:Label>
                                </td>
                                <td style="visibility: hidden">
                                    聘用岗位
                                </td>
                                <td style="visibility: hidden">
                                    <asp:TextBox ID="txtContractPosition" runat="server" Width="60%" CssClass="input1"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    所属公司&nbsp;<span class="redstar">*</span>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlCompany" runat="server" Width="62%" OnSelectedIndexChanged="ddlCompany_SelectedIndexChanged"
                                        AutoPostBack="True">
                                    </asp:DropDownList>
                                    <asp:Label ID="lblCompanyMsg" runat="server" Text="CompanyMsg"></asp:Label>
                                </td>
                                <td>
                                    门禁卡卡号
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDoorCardNO" runat="server" Width="60%" CssClass="input1"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    入职时间&nbsp;<span class="redstar">*</span>
                                </td>
                                <td>
                                    <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd"
                                        TargetControlID="txtComeDate">
                                    </ajaxToolKit:CalendarExtender>
                                    <asp:TextBox ID="txtComeDate" runat="server" Width="60%" CssClass="input1" size="28"></asp:TextBox>
                                    <asp:Label ID="lblComeDateMsg" runat="server" CssClass="psword_f"></asp:Label>
                                </td>
                                <td>
                                    司龄&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="lbWorkAge" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    工作地点
                                </td>
                                <td>
                                    <asp:TextBox ID="tbWorkPlace" runat="server" CssClass="input1" Width="60%"></asp:TextBox>
                                </td>
                                <td>
                                    社会工龄(天)
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSocietyWorkAge" runat="server" Width="60%" CssClass="input1"></asp:TextBox>
                                    <asp:Label ID="lblSocietyWorkAge" runat="server" CssClass="psword_f"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    职务
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPrincipalShip" runat="server" Width="62%">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    职位等级
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlGrade" runat="server" Width="62%">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    请假流程
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlLeaveRequest" runat="server" Width="62%" ansmessage="#cphCenter_EmployeeView1_EmployeeWorkView1_lblLeaveRequest"
                                        onchange="getprocess(this);">
                                    </asp:DropDownList>
                                    <img src="../../../Pages/image/loading_js.gif" style="display: none;" />
                                </td>
                                <td colspan="2">
                                    <asp:Label ID="lblLeaveRequest" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    外出申请流程
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlOut" runat="server" Width="62%" ansmessage="#cphCenter_EmployeeView1_EmployeeWorkView1_lblOut"
                                        onchange="getprocess(this);">
                                    </asp:DropDownList>
                                    <img src="../../../Pages/image/loading_js.gif" style="display: none;" />
                                </td>
                                <td colspan="2">
                                    <asp:Label ID="lblOut" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    加班申请流程
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlOverTime" runat="server" Width="62%" ansmessage="#cphCenter_EmployeeView1_EmployeeWorkView1_lblOverTime"
                                        onchange="getprocess(this);">
                                    </asp:DropDownList>
                                    <img src="../../../Pages/image/loading_js.gif" style="display: none;" />
                                </td>
                                <td colspan="2">
                                    <asp:Label ID="lblOverTime" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    绩效考核流程
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlAssess" runat="server" Width="62%" ansmessage="#cphCenter_EmployeeView1_EmployeeWorkView1_lblAssess"
                                        onchange="getprocess(this);">
                                    </asp:DropDownList>
                                    <img src="../../../Pages/image/loading_js.gif" style="display: none;" />
                                </td>
                                <td colspan="2">
                                    <asp:Label ID="lblAssess" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <%--	   		   <tr>
	         <td>&nbsp;</td>
	         <td>
                 报销流程</td>
	         <td>
	         <asp:DropDownList ID="ddlReimburse" runat="server" Width="62%" AutoPostBack="True" OnSelectedIndexChanged="DiyProcess_SelectedIndexChanged"></asp:DropDownList>
                 </td>
	         <td colspan="2">
                 <asp:Label ID="lblReimburse" runat="server"></asp:Label></td>
	   </tr>  --%>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    培训申请流程
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlTraineeApplication" runat="server" Width="62%" ansmessage="#cphCenter_EmployeeView1_EmployeeWorkView1_lblTraineeApplication"
                                        onchange="getprocess(this);">
                                    </asp:DropDownList>
                                    <img src="../../../Pages/image/loading_js.gif" style="display: none;" />
                                </td>
                                <td colspan="2">
                                    <asp:Label ID="lblTraineeApplication" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    人事负责人
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlHRPrincipal" runat="server" Width="62%" ansmessage="#cphCenter_EmployeeView1_EmployeeWorkView1_lblHRPrincipal"
                                        onchange="getprocess(this);">
                                    </asp:DropDownList>
                                    <img src="../../../Pages/image/loading_js.gif" style="display: none;" />
                                </td>
                                <td colspan="2">
                                    <asp:Label ID="lblHRPrincipal" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    调休规则
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlAdjustRule" runat="server" Width="62%">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    工作职责
                                </td>
                                <td colspan="3" style="width: 90%;">
                                    <asp:TextBox ID="txtResponsibility" runat="server" CssClass="grayborder" Rows="7"
                                        Height="100px" TextMode="MultiLine" Width="82%"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <div class="nolinetablediv" style="margin: 0">
                            <asp:GridView ID="gvAssessTemplate" GridLines="None" Width="100%" CssClass="linetable"
                                runat="server" AutoGenerateColumns="False" PageSize="5" AllowPaging="True" OnPageIndexChanging="gvAssessTemplate_PageIndexChanging"
                                OnRowDataBound="gvAssessTemplate_RowDataBound">
                                <HeaderStyle Height="28px" CssClass="headerstyleblue" />
                                <RowStyle Height="28px" CssClass="GridViewRowLink" />
                                <AlternatingRowStyle CssClass="table_g" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button ID="btnHiddenPostButton" CommandName="HiddenPostButtonCommand" runat="server"
                                                Text="" Style="display: none;" /></ItemTemplate>
                                        <ItemStyle Width="3%" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Question" HeaderText="绩效考核项" ItemStyle-Width="57%" />
                                    <asp:TemplateField HeaderText="题型">
                                        <ItemTemplate>
                                            <%# Eval("AssessTemplateItemID").ToString() != "-1" ? AssessTemplateItemTypeToString((AssessTemplateItemType)Eval("AssessTemplateItemType")) : ""%>
                                        </ItemTemplate>
                                        <ItemStyle Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="分类">
                                        <ItemTemplate>
                                            <%# Eval("AssessTemplateItemID").ToString() != "-1" ? AssessUtility.ClassficationToString((ItemClassficationEmnu)Eval("Classfication")) : ""%>
                                        </ItemTemplate>
                                        <ItemStyle Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="人力资源项">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chbType" Enabled="false" runat="server" Checked='<%# Eval("AssessTemplateItemID").ToString() != "-1" ? ConvertToBoolIsHr((OperateType)Eval("ItsOperateType")) : false%>' />
                                        </ItemTemplate>
                                        <ItemStyle Width="10%" HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="权重">
                                        <ItemTemplate>
                                            <%#Convert.ToInt32(Convert.ToDecimal(Eval("Weight"))*100)%>%
                                        </ItemTemplate>
                                        <ItemStyle Width="10%" HorizontalAlign="left" />
                                    </asp:TemplateField>
                                </Columns>
                                <PagerTemplate>
                                    <%--		<div class="pages">
		    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton" CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    上一页</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton" CommandArgument="Next" CommandName="Page"  Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    下一页</asp:LinkButton>
		</div>      --%>
                                    <uc1:PageTemplate ID="PageTemplateAssessTemplate" runat="server" />
                                </PagerTemplate>
                            </asp:GridView>
                        </div>
                        <table width="100%" border="0" cellpadding="0" style="border-collapse: separate;"
                            cellspacing="10">
                            <tr>
                                <td style="width: 2%;">
                                    &nbsp;
                                </td>
                                <td style="width: 11%;">
                                    试用期起始日&nbsp;<span class="redstar">*</span>
                                </td>
                                <td style="width: 38%;">
                                    <asp:TextBox ID="txtProbationStartDate" runat="server" CssClass="input1" size="28"
                                        Width="60%"></asp:TextBox>
                                    <asp:Label ID="lblProbationStartDate" runat="server" CssClass="psword_f"></asp:Label>
                                    <ajaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd"
                                        TargetControlID="txtProbationStartDate">
                                    </ajaxToolKit:CalendarExtender>
                                </td>
                                <td style="width: 11%;">
                                    试用期到期日&nbsp;<span class="redstar">*</span>
                                </td>
                                <td style="width: 38%;">
                                    <asp:TextBox ID="txtProbationEndDate" Width="60%" runat="server" CssClass="input1"
                                        size="28"></asp:TextBox>
                                    <asp:Label ID="lblProbationEndDate" runat="server" CssClass="psword_f"></asp:Label>
                                    <ajaxToolKit:CalendarExtender ID="CalendarExtender3" runat="server" Format="yyyy-MM-dd"
                                        TargetControlID="txtProbationEndDate">
                                    </ajaxToolKit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%;">
                                    &nbsp;
                                </td>
                                <td>
                                    合同起始日
                                </td>
                                <td>
                                    <asp:TextBox ID="txtStartDate" Width="60%" runat="server" CssClass="input1" size="28"
                                        Enabled="false"></asp:TextBox>
                                </td>
                                <td>
                                    新合同起始日
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNewConStart" runat="server" Width="60%" CssClass="input1" size="28"
                                        Enabled="false">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    合同到期日
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEndDate" Width="60%" runat="server" CssClass="input1" size="28"
                                        Enabled="false"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellpadding="0" style="border-collapse: separate;"
                            cellspacing="10" runat="server" id="tbContractManage">
                            <tr>
                                <td height="24px">
                                    <asp:Button ID="btnContractManage" runat="server" Text="合同管理" CssClass="inputbt"
                                        OnClick="btnContractManage_Click" />
                                </td>
                            </tr>
                        </table>
                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                            <tr>
                                <td align="center">
                                    <table id="Result" width="100%" class="linetable" runat="server" cellpadding="0"
                                        cellspacing="0" visible="false">
                                        <tr>
                                            <td width="100%">
                                                <asp:GridView ID="WorkGV" GridLines="None" Width="100%" runat="server" AutoGenerateColumns="False"
                                                    PageSize="5" AllowPaging="True" OnPageIndexChanging="WorkGV_PageIndexChanging"
                                                    BorderStyle="None" OnRowDataBound="WorkGV_RowDataBound">
                                                    <HeaderStyle Height="28px" CssClass="headerstyleblue" />
                                                    <RowStyle Height="28px" CssClass="GridViewRowLink" />
                                                    <AlternatingRowStyle CssClass="table_g" />
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("ContractID") %>'
                                                                    CommandName="HiddenPostButtonCommand" runat="server" Text="" Style="display: none;" /></ItemTemplate>
                                                            <ItemStyle Width="2%" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="ContractID" HeaderText="编号" ItemStyle-Width="12%" />
                                                        <asp:TemplateField HeaderText="合同类型" HeaderStyle-Width="12%">
                                                            <ItemTemplate>
                                                                <%# Eval("ContractType.ContractTypeName")%></ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="StartDate" HeaderText="合同开始时间" DataFormatString="{0:yyyy/MM/dd}"
                                                            HtmlEncode="false">
                                                            <ItemStyle Width="12%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="EndDate" HeaderText="合同结束时间" DataFormatString="{0:yyyy/MM/dd}"
                                                            HtmlEncode="false">
                                                            <ItemStyle Width="12%" />
                                                        </asp:BoundField>
                                                        <%--      <asp:BoundField DataField="Attachment" HeaderText="附件" >     
                            <ItemStyle Width="12%" />
                        </asp:BoundField> --%>
                                                        <asp:TemplateField HeaderStyle-Width="12%">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnDownLoad" runat="server" Text="合同下载" CausesValidation="false"
                                                                    CommandArgument='<%# Eval("ContractID") %>' OnCommand="DownLoad_Command" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Remark" HeaderText="备注">
                                                            <ItemStyle Width="12%" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                    <PagerTemplate>
                                                        <%--		<div class="pages">
		    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton" CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    上一页</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton" CommandArgument="Next" CommandName="Page"  Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    下一页</asp:LinkButton>
		</div>           --%>
                                                        <uc1:PageTemplate ID="PageTemplateContract" runat="server" />
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
            </table>
        </td>
    </tr>
</table>
<script type="text/javascript">

    function getprocess(th) {
        var id = $(".accountidhidden").val();
        var diyprocessid = $(th).val();
        if (id != "") {
            var lblid = $(th).attr("ansmessage");
            $(th).next("img").css("display", "inline");
            $.ajax({
                url: "EmployeeBindProcessAjax.aspx",
                cache: false,
                type: "get",
                data: "AccountID=" + id + "&DiyProcessID=" + diyprocessid,
                success: function (data) { $(lblid).html(data); $(th).next("img").css("display", "none"); }
            });
        }

    }

</script>
