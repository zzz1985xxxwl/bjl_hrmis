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
                                    ��������
                                </td>
                                <td style="width: 38%;">
                                    <asp:Label ID="lblDept" runat="server"></asp:Label>
                                </td>
                                <td style="width: 11%;">
                                    ���ž���
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
                                    ְλ
                                </td>
                                <td>
                                    <asp:Label ID="lblPosition" runat="server"></asp:Label>
                                </td>
                                <td style="visibility: hidden">
                                    Ƹ�ø�λ
                                </td>
                                <td style="visibility: hidden">
                                    <asp:TextBox ID="txtContractPosition" runat="server" Width="60%" CssClass="input1"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    ������˾&nbsp;<span class="redstar">*</span>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlCompany" runat="server" Width="62%" OnSelectedIndexChanged="ddlCompany_SelectedIndexChanged"
                                        AutoPostBack="True">
                                    </asp:DropDownList>
                                    <asp:Label ID="lblCompanyMsg" runat="server" Text="CompanyMsg"></asp:Label>
                                </td>
                                <td>
                                    �Ž�������
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
                                    ��ְʱ��&nbsp;<span class="redstar">*</span>
                                </td>
                                <td>
                                    <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd"
                                        TargetControlID="txtComeDate">
                                    </ajaxToolKit:CalendarExtender>
                                    <asp:TextBox ID="txtComeDate" runat="server" Width="60%" CssClass="input1" size="28"></asp:TextBox>
                                    <asp:Label ID="lblComeDateMsg" runat="server" CssClass="psword_f"></asp:Label>
                                </td>
                                <td>
                                    ˾��&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="lbWorkAge" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    �����ص�
                                </td>
                                <td>
                                    <asp:TextBox ID="tbWorkPlace" runat="server" CssClass="input1" Width="60%"></asp:TextBox>
                                </td>
                                <td>
                                    ��Ṥ��(��)
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
                                    ְ��
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPrincipalShip" runat="server" Width="62%">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    ְλ�ȼ�
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
                                    �������
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
                                    �����������
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
                                    �Ӱ���������
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
                                    ��Ч��������
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
                 ��������</td>
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
                                    ��ѵ��������
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
                                    ���¸�����
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
                                    ���ݹ���
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
                                    ����ְ��
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
                                    <asp:BoundField DataField="Question" HeaderText="��Ч������" ItemStyle-Width="57%" />
                                    <asp:TemplateField HeaderText="����">
                                        <ItemTemplate>
                                            <%# Eval("AssessTemplateItemID").ToString() != "-1" ? AssessTemplateItemTypeToString((AssessTemplateItemType)Eval("AssessTemplateItemType")) : ""%>
                                        </ItemTemplate>
                                        <ItemStyle Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="����">
                                        <ItemTemplate>
                                            <%# Eval("AssessTemplateItemID").ToString() != "-1" ? AssessUtility.ClassficationToString((ItemClassficationEmnu)Eval("Classfication")) : ""%>
                                        </ItemTemplate>
                                        <ItemStyle Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="������Դ��">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chbType" Enabled="false" runat="server" Checked='<%# Eval("AssessTemplateItemID").ToString() != "-1" ? ConvertToBoolIsHr((OperateType)Eval("ItsOperateType")) : false%>' />
                                        </ItemTemplate>
                                        <ItemStyle Width="10%" HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ȩ��">
                                        <ItemTemplate>
                                            <%#Convert.ToInt32(Convert.ToDecimal(Eval("Weight"))*100)%>%
                                        </ItemTemplate>
                                        <ItemStyle Width="10%" HorizontalAlign="left" />
                                    </asp:TemplateField>
                                </Columns>
                                <PagerTemplate>
                                    <%--		<div class="pages">
		    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton" CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    ��һҳ</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton" CommandArgument="Next" CommandName="Page"  Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    ��һҳ</asp:LinkButton>
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
                                    ��������ʼ��&nbsp;<span class="redstar">*</span>
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
                                    �����ڵ�����&nbsp;<span class="redstar">*</span>
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
                                    ��ͬ��ʼ��
                                </td>
                                <td>
                                    <asp:TextBox ID="txtStartDate" Width="60%" runat="server" CssClass="input1" size="28"
                                        Enabled="false"></asp:TextBox>
                                </td>
                                <td>
                                    �º�ͬ��ʼ��
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
                                    ��ͬ������
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
                                    <asp:Button ID="btnContractManage" runat="server" Text="��ͬ����" CssClass="inputbt"
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
                                                        <asp:BoundField DataField="ContractID" HeaderText="���" ItemStyle-Width="12%" />
                                                        <asp:TemplateField HeaderText="��ͬ����" HeaderStyle-Width="12%">
                                                            <ItemTemplate>
                                                                <%# Eval("ContractType.ContractTypeName")%></ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="StartDate" HeaderText="��ͬ��ʼʱ��" DataFormatString="{0:yyyy/MM/dd}"
                                                            HtmlEncode="false">
                                                            <ItemStyle Width="12%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="EndDate" HeaderText="��ͬ����ʱ��" DataFormatString="{0:yyyy/MM/dd}"
                                                            HtmlEncode="false">
                                                            <ItemStyle Width="12%" />
                                                        </asp:BoundField>
                                                        <%--      <asp:BoundField DataField="Attachment" HeaderText="����" >     
                            <ItemStyle Width="12%" />
                        </asp:BoundField> --%>
                                                        <asp:TemplateField HeaderStyle-Width="12%">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnDownLoad" runat="server" Text="��ͬ����" CausesValidation="false"
                                                                    CommandArgument='<%# Eval("ContractID") %>' OnCommand="DownLoad_Command" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Remark" HeaderText="��ע">
                                                            <ItemStyle Width="12%" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                    <PagerTemplate>
                                                        <%--		<div class="pages">
		    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton" CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    ��һҳ</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton" CommandArgument="Next" CommandName="Page"  Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    ��һҳ</asp:LinkButton>
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
